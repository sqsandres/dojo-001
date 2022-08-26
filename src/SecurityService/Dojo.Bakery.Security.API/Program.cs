using Autofac;
using Autofac.Extensions.DependencyInjection;
using Dojo.Bakery.BuildingBlocks.WebCommons;
using Dojo.Bakery.Security.API.Core.Modules;
using Dojo.Bakery.Security.Domain;
using Dojo.Bakery.Security.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Host
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new ControllersModule());
        builder.RegisterModule(new RepositoriesModule());
        builder.RegisterModule(new MediatorModule());
    });
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplicationInsightsTelemetry(builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"]);
builder.Services.AddSwagger("Security", Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
string connectionString = builder.Configuration.GetConnectionString("SecurityConnectionString");
builder.Services.AddServerAuthentication<ApplicationDbContext, ApplicationUser, ApplicationRole>(builder.Configuration, connectionString);
builder.Services.Configure<RouteOptions>(config => { config.LowercaseUrls = true; });
builder.Services.AddDbContext<ApplicationDbContext>(options =>{
    options.UseSqlServer(connectionString, x => { x.MigrationsHistoryTable("EFMigration", "Security"); });
        options.EnableSensitiveDataLogging(true);
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dojo Bakery Security Service");
        c.RoutePrefix = string.Empty;
    });
}

app.UseIdentityServer();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();