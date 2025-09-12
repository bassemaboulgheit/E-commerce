using E_commerce.Models;

namespace E_commerce.Application.Services
{
    public interface IOrderItemService
    {
        public List<OrderItem> GetAllOrderItem();
        public void CreateOrderItem(OrderItem cartItem);
        public void DeleteOrderItem(OrderItem cartItem);
        public void UpdateOrderItem(OrderItem cartItem);
        public int SaveOrderItem();
    }
}
