using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Models
{
    public class OrderItem : BaseModels<int>
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public bool IsDeleted { get; set; } = false;


        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
