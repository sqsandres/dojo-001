using Autofac;
using Dojo.Bakery.BuildingBlocks.Commons.Repositories;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dojo.Bakery.Security.API.Core.Modules
{
    public class RepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<UnitOfWork<ApplicationDbContext>>().As<IUnitOfWork>();
        }
    }
}
