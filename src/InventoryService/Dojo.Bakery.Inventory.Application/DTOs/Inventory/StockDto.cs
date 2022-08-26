using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo.Bakery.Inventory.Application.DTOs.Inventory
{
    public enum OperationType { 
        Increase,
        Decrease
    }
    public class StockDto
    {
        public OperationType Operation { get; set; }
        public int Value { get; set; }
    }
}
