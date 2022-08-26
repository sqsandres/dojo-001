using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo.Bakery.Inventory.Application.DTOs.Inventory
{
    public class InventoryDto
    {
        public int Stock { get; set; }
        public Guid ProductId { get; set; }
        public Guid StoreId { get; set; }
    }
}
