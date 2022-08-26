using Dojo.Bakery.BuildingBlocks.Commons;
using IdentityServer4;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
//using System.Diagnostics;

namespace Dojo.Bakery.BuildingBlocks.WebCommons
{
    public static class ConfigurationHelper
    {
        public static void AddServerAuthentication<TContext, TUser, TRole>(this IServiceCollection service,
            ConfigurationManager configurationManager,
            string connectionString)
            where TContext : DbContext
            where TUser : class
            where TRole : class
        {
            string azureADConfigurationAuthority = configurationManager["AzureAD_Authority"];
            string azureADConfigurationClientId = configurationManager["AzureAD_ClientId"];
            string azureADConfigurationPrompt = configurationManager["AzureAD_Prompt"];
            string azureADConfigurationClientSecret = configurationManager["AzureAD_ClientSecret"];
            string azureADConfigurationResponseType = configurationManager["AzureAD_ResponseType"];

            service.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddOpenIdConnect("oidc", "Azure AD", options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                    options.SignOutScheme = IdentityServerConstants.SignoutScheme;
                    options.Authority = azureADConfigurationAuthority;
                    options.ClientId = azureADConfigurationClientId;
                    options.CallbackPath = "/signin-microsoft";
                    options.Prompt = azureADConfigurationPrompt; // login, consent

                    options.ClientSecret = azureADConfigurationClientSecret;
                    options.ResponseType = azureADConfigurationResponseType;
                    //options.Scope.Add("profile");
                    //options.Scope.Add("email");
                    options.SignInScheme = "Identity.External";

                    options.RequireHttpsMetadata = false;
                    //options.SaveTokens = true;

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        NameClaimType = "name",
                        IssuerSigningKey = SecurityHelper.PrivateKey,
                    };
                    //options.Events.OnRemoteFailure = context => { if (context.Failure.Message.Contains("Correlation failed")){ context.Response.Redirect("/"); } else { context.Response.Redirect("/Error"); } context.HandleResponse(); return Task.CompletedTask; };
                })
                .AddJwtBearer(options =>
                {
                    options.IncludeErrorDetails = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = false,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = false,
                        ValidateTokenReplay = false,
                        ValidateActor = false,
                        NameClaimType = "name",
                        IssuerSigningKey = SecurityHelper.PrivateKey,
                    };
                });

            service.AddIdentity<TUser, TRole>().AddEntityFrameworkStores<TContext>();
            service.AddIdentityServer(o => o.IssuerUri = azureADConfigurationAuthority)
                .AddSigningCredential(SecurityHelper.PrivateKey, SecurityHelper.Algorithm)
                .AddConfigurationStore(options =>
                {
                    options.DefaultSchema = "Security";
                    options.ConfigureDbContext = builder =>
                        builder.UseSqlServer(connectionString, optionsBuilder =>
                            optionsBuilder.MigrationsAssembly("Dojo.Bakery.Security.Infra.Data"));
                })
                .AddOperationalStore(options =>
                {
                    options.DefaultSchema = "Security";
                    options.ConfigureDbContext = builder =>
                        builder.UseSqlServer(connectionString,
                            sql => sql.MigrationsAssembly("Dojo.Bakery.Security.Infra.Data"));
                    options.EnableTokenCleanup = true;
                    options.TokenCleanupInterval = 30;
                })
                .AddAspNetIdentity<TUser>();

            Action<HttpContext, CookieOptions> CheckSameSite = new Action<HttpContext, CookieOptions>((httpContext, options) =>
            {
                if (options.SameSite == SameSiteMode.None)
                {
                    var userAgent = httpContext.Request.Headers["User-Agent"].ToString();
                    if (userAgent.Contains("CPU iPhone OS 12") || userAgent.Contains("iPad; CPU OS 12") || (userAgent.Contains("Macintosh; Intel Mac OS X 10_14") &&
                            userAgent.Contains("Version/") && userAgent.Contains("Safari")) || userAgent.Contains("Chrome/5") || userAgent.Contains("Chrome/6"))
                    {
                        // For .NET Core < 3.1 set SameSite = (SameSiteMode)(-1)
                        options.SameSite = SameSiteMode.Unspecified;
                    }
                }
            });
            service.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.Lax;
                options.OnAppendCookie = cookieContext => CheckSameSite(cookieContext.Context, cookieContext.CookieOptions);
                options.OnDeleteCookie = cookieContext => CheckSameSite(cookieContext.Context, cookieContext.CookieOptions);
            });
        }
        public static void AddClientAuthentication(this IServiceCollection service)
        {
            service.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        NameClaimType = "name",
                        IssuerSigningKey = SecurityHelper.PrivateKey,
                    };
                    options.Events = new JwtBearerEvents()
                    {
                        OnAuthenticationFailed = (context) =>
                        {
                            context.Response.Headers.Add("access-control-allow-origin", "*");
                            return Task.CompletedTask;
                        }
                    };
                    options.Events.OnAuthenticationFailed = context =>
                    {
                        //Debug.WriteLine(context.Exception.Message);
                        return Task.CompletedTask;
                    };
                    options.Events.OnChallenge = context =>
                    {
                        //Debug.WriteLine(context.AuthenticateFailure?.Message);
                        return Task.CompletedTask;
                    };
                    options.Events.OnForbidden = context =>
                    {
                        //Debug.WriteLine(context.Result);
                        return Task.CompletedTask;
                    };
                    options.Events.OnMessageReceived = context =>
                    {
                        //Debug.WriteLine(context.Token);
                        return Task.CompletedTask;
                    };
                });
        }
        public static void AddSwagger(this IServiceCollection service, string name, string xmlPath)
        {
            service.AddSwaggerGen(c =>
             {
                 c.SwaggerDoc("v1", new OpenApiInfo
                 {
                     Version = "0.0.0.4",
                     Title = $"Dojo Bakery {name} Service",
                     Description = $"Dojo Bakery {name} Services - BE API endpoints",
                     Contact = new OpenApiContact
                     {
                         Name = "dojo-globant",
                         Email = "dojo001@globant.com",
                         Url = new Uri("https://www.globant.com/")
                     }
                 });
                 c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                 {
                     Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                     Name = "Authorization",
                     In = ParameterLocation.Header,
                     Type = SecuritySchemeType.ApiKey,
                     BearerFormat = "JWT",
                     Scheme = "Bearer"
                 });
                 c.AddSecurityRequirement(new OpenApiSecurityRequirement() {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },
                        new List<string>()
                      }
                    });
                 c.IncludeXmlComments(xmlPath);
             });
        }
    }
}
