using Autofac;
using Autofac.Extensions.DependencyInjection;
using Dojo.Bakery.BuildingBlocks.EventBus;
using Dojo.Bakery.Transaction.API.Core.Modules;
using Dojo.Bakery.Transaction.Infra.Data;
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
builder.Services.AddSwagger("Transaction", Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
builder.Services.AddClientAuthentication();
builder.Services.Configure<RouteOptions>(config => { config.LowercaseUrls = true; });

string connectionString = builder.Configuration.GetConnectionString("TransactionConnectionString");
builder.Services.AddDbContext<ApplicationDbContext>(
    options =>
    {
        options.UseSqlServer(connectionString);
        options.EnableSensitiveDataLogging(true);
    });
string busConnectionString = builder.Configuration.GetSection("InventoryBusConnection").Value;
builder.Services.AddSingleton(resolver => new EventBusInfo(busConnectionString, "InventoryService"));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dojo Bakery Transaction Service");
        c.RoutePrefix = string.Empty;
    });
}

app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
