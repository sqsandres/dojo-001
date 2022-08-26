using Autofac;
using Autofac.Extensions.DependencyInjection;
using Dojo.Bakery.BuildingBlocks.EventBus;
using Dojo.Bakery.BuildingBlocks.WebCommons;
using Dojo.Bakery.Inventory.API.Core.Modules;
using Dojo.Bakery.Inventory.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
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
builder.Services.AddSwagger("Inventory", Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
builder.Services.AddClientAuthentication();
builder.Services.Configure<RouteOptions>(config => { config.LowercaseUrls = true; });

string connectionString = builder.Configuration.GetSection("InventoryConnectionString").Value;
builder.Services.AddDbContext<ApplicationDbContext>(
    options =>
    {
        options.UseSqlServer(connectionString);
        options.EnableSensitiveDataLogging(true);
    });
string busConnectionString = builder.Configuration.GetSection("InventoryBusConnection").Value;
builder.Services.AddSingleton(resolver => new EventBusInfo(busConnectionString, "InventoryService"));
/*
//builder.Services.AddSingleton(resolver => new EventBusServiceBus(new EventBusInfo(busConnectionString, "InventoryService")));
ServiceProvider serviceProvider = builder.Services.BuildServiceProvider(new ServiceProviderOptions
{
    ValidateOnBuild = true
});
EventBusServiceBus ev = serviceProvider.GetService<EventBusServiceBus>();
ev.Subscribe(GeneralJobHandler.MessageHandler);
*/
WebApplication app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dojo Bakery Inventory Service");
        c.RoutePrefix = string.Empty;
    });
}

app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
