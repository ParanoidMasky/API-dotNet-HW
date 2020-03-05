using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Training.API.Contracts;
using Training.DTO;

namespace Training.API.Operations.Orders
{
    public class GetOrdersByUser
    {
        private readonly IOrdersRepository _OrdersRepository;

        public GetOrdersByUser(IOrdersRepository ordersRepository)
        {
            _OrdersRepository = ordersRepository;
        }

        public async Task<List<DTO.Order>> Execute(User user)
        {
            return await _OrdersRepository.GetOrdersByUser(user);
        }
    }
}
