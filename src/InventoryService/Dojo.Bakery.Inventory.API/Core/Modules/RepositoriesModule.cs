using Autofac;
using Dojo.Bakery.BuildingBlocks.Commons.Repositories;
using Dojo.Bakery.Inventory.Infra.Data;
using Dojo.Bakery.Inventory.Infra.Data.Repositories;
using Dojo.Bakery.Inventory.Infra.DataContract;
using System;

namespace Dojo.Bakery.Inventory.API.Core.Modules
{
    public class RepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork<ApplicationDbContext>>().As<IUnitOfWork>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();

            builder.RegisterType<StoreRepository>().As<IStoreRepository>();
            builder.RegisterType<DocumentTypeRepository>().As<IDocumentTypeRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<UnitRepository>().As<IUnitRepository>();
            builder.RegisterType<BrandRepository>().As<IBrandRepository>();
            builder.RegisterType<InventoryRepository>().As<IInventoryRepository>();
        }
    }
}
