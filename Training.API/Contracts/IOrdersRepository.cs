using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Training.DTO;

namespace Training.API.Contracts
{
    public interface IOrdersRepository
    {
        Task<List<Order>> GetAllOrders();
        Task<Order> Create(Order order);
        Task<List<Order>> GetOrdersByUser(User user);

    }
}
