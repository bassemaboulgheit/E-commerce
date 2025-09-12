using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Models
{
    public class Product : BaseModels<int>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string ImagePath { get; set; }
        public int Stock { get; set; } = 0;
        public bool IsDeleted { get; set; } = false;


        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        //public int? CartItemId { get; set; }
        //public CartItem CartItem { get; set; }
    }
}
