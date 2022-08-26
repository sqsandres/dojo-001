using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;
using System.Reflection;

namespace Dojo.Bakery.Security.API.Core.Modules
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterMediatR(typeof(Program).Assembly);
            builder.RegisterMediatR(Assembly.Load("Dojo.Bakery.Security.Application"));
        }
    }
}
