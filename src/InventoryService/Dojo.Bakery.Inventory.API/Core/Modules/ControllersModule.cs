using Autofac;
using Microsoft.AspNetCore.Mvc;

namespace Dojo.Bakery.Inventory.API.Core.Modules
{
    public class ControllersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var controllerTypesInAssembly = typeof(Program).Assembly.GetExportedTypes()
                .Where(type => typeof(ControllerBase).IsAssignableFrom(type)).ToArray();
            builder.RegisterTypes(controllerTypesInAssembly);
        }
    }
}
