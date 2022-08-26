using Dojo.Bakery.Inventory.Application.Commands.Inventory;
using Dojo.Bakery.Inventory.Application.DTOs.Inventory;
using Dojo.Bakery.Inventory.Application.Handlers.Inventory;

namespace Dojo.Bakery.Inventory.Application.Tests.Fakes
{
    internal class InventoryItemCommandFakeData
    {
        public static CreateInventoryItemCommand CreateInventoryItemCommand {
            get { 
                var obj = new InventoryDto
                {
                    Stock = 20,
                    ProductId = new Guid("1e4e73bb-1469-42e9-9a69-1a14ce70bf7b"),
                    StoreId = new Guid("9f411f76-42d9-4f1f-ad0c-5d8c06cabaea")
                };
                return new CreateInventoryItemCommand { 
                    Item = obj
                };
            } 
        }
    }
}
