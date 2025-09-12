using E_commerce.Application.Contracts;
using E_commerce.Models;

namespace E_commerce.Application.Services
{
    public class OrderItemService : IOrderItemService
    {
        //ICategoryRepository _CategoryRepo;
        IGenericRepository<OrderItem, int> _orderitemRepo;

        public OrderItemService(IGenericRepository<OrderItem, int> orderitemrepo)
        {
            _orderitemRepo = orderitemrepo;
        }
        public List<OrderItem> GetAllOrderItem()
        {
            //IQueryable<Category> allcategoriesquery = _CategoryRepo.GetAll();
            //var allcats = allcategoriesquery.Where(c => c.Products.Count > 0)
            //    .Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList()
            //.Adapt<List<Category>>();
            //return allcats;
            return _orderitemRepo.GetAll().ToList();
        }

        public void CreateOrderItem(OrderItem orderitem)
        {
            OrderItem OrderIte = new OrderItem()
            {
                Quantity = orderitem.Quantity,
                UnitPrice = orderitem.UnitPrice
            };
            //Category newcat = category.Adapt<Category>();
            _orderitemRepo.create(OrderIte);
        }

        public void DeleteOrderItem(OrderItem orderitem)
        {
            if (orderitem != null)
            {
                orderitem.IsDeleted = true;
            }
            else
            {
                throw new Exception("OrderItem not found");
            }
            _orderitemRepo.delete(orderitem);
        }

        public void UpdateOrderItem(OrderItem orderitem)
        {
            _orderitemRepo.Update(orderitem);
        }

        public int SaveOrderItem()
        {
            return _orderitemRepo.Save();
        }
    }
}
