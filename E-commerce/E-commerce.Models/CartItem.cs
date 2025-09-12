using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Models
{
    public class CartItem : BaseModels<int>
    {
        public int Quantity { get; set; }
        public bool IsDeleted { get; set; } = false;


        public int CartId { get; set; }
        public Cart Cart { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
