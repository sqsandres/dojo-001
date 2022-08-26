using Dojo.Bakery.BuildingBlocks.Commons;

namespace Dojo.Bakery.Inventory.Domain.Entities
{
    public class Inventory: AggregateRoot
    {
        public int Stock { get; private set; }
        public Guid ProductId { get; private set; }
        public Guid StoreId { get; private set; }

        private Inventory() { }

        public Inventory(Guid productId, Guid storeId, int stock)
        {
            DomainExceptionValidation.When(stock < 0, "The stock cannot be less than zero");
            DomainExceptionValidation.When(productId == Guid.Empty, $"{nameof(productId)} The productId cannot be empty");
            DomainExceptionValidation.When(storeId == Guid.Empty, $"{nameof(storeId)} The storeId cannot be empty");
            ProductId = productId;  
            StoreId = storeId;  
            Stock = stock;
            Id = IdentityGenerator.NewSequentialGuid();
        }

        /// <summary>
        /// Increase the stock
        /// </summary>
        /// <param name="stock"></param>
        public void IncreaseStock(int quantity)
        {
            Stock += quantity;
        }

        /// <summary>
        /// Decrease the stock
        /// </summary>
        /// <param name="quantity"></param>
        public void DecreaseStock(int quantity)
        {
            DomainExceptionValidation.When(Stock < 1, "There is not products in the inventory");
            DomainExceptionValidation.When(Stock < quantity, "There is not enough products in the inventory for the operation");
            Stock -= quantity;
        }

        public void ChangeProductId(Guid productId)
        {
            ProductId = productId;
        }

        public void ChangeStoreId(Guid storeId)
        {
            StoreId = storeId;
        }

        #region private methods

        private void ValidateStock(int stock)
        {

        }

        #endregion
    }
}
