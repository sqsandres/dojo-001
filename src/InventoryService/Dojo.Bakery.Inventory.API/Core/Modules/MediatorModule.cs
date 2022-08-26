using Autofac;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;
using System.Reflection;

namespace Dojo.Bakery.Inventory.API.Core.Modules
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterMediatR(typeof(Program).Assembly);
            builder.RegisterMediatR(Assembly.Load("Dojo.Bakery.Inventory.Application"));
        }
    }
}
