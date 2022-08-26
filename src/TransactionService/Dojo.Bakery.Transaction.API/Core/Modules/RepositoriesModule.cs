using Autofac;
using Dojo.Bakery.BuildingBlocks.Commons.Repositories;
using Dojo.Bakery.Transaction.Infra.Data;
using Dojo.Bakery.Transaction.Infra.Data.Repositories;
using Dojo.Bakery.Transaction.Infra.DataContract;

namespace Dojo.Bakery.Transaction.API.Core.Modules
{
    public class RepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork<ApplicationDbContext>>().As<IUnitOfWork>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<UnitRepository>().As<IUnitRepository>();
            builder.RegisterType<ClientRepository>().As<IClientRepository>();
            builder.RegisterType<BrandRepository>().As<IBrandRepository>();
            builder.RegisterType<SupplierRepository>().As<ISupplierRepository>();

            builder.RegisterType<StoreRepository>().As<IStoreRepository>();
            builder.RegisterType<DocumentTypeRepository>().As<IDocumentTypeRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<SellRepository>().As<ISellRepository>();
            builder.RegisterType<SellItemRepository>().As<ISellItemRepository>();

            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<OrderDetailRepository>().As<IOrderDetailRepository>();
        }
    }
}
