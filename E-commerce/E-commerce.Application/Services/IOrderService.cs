using E_commerce.Models;

namespace E_commerce.Application.Services
{
    public interface IOrderService
    {
        public List<Order> GetAllOrder();
        public void CreateOrder(Order cartItem);
        public void DeleteOrder(Order cartItem);
        public void UpdateOrder(Order cartItem);
        public int SaveOrder();
    }
}
