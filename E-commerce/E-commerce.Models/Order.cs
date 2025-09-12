using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Models
{
    public class Order : BaseModels<int>
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount => OrderItems.Sum(oi => oi.Quantity * oi.UnitPrice);

        public OrderStatus orderStatus = OrderStatus.Pending;

        public bool IsDeleted { get; set; } = false;

        public int UserId { get; set; }
        public User User { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }

    public enum OrderStatus
    {
        Pending = 1,
        Shipped = 2,
        Delivered = 3
    }

}

