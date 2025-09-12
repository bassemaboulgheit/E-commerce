using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Models
{
    public class User : BaseModels<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = "customer"; 


        public List<Order> Orders { get; set; } = new List<Order>();

        //public int? CartId { get; set; }
        public Cart? Carts { get; set; }
    }
}
