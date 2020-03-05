using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Training.API.Contracts;
using Training.DTO;

namespace Training.API.Operations.Orders
{
    public class AddOrder
    {
        private readonly IOrdersRepository _OrdersRepository;

        public AddOrder(IOrdersRepository ordersRepository)
        {
            _OrdersRepository = ordersRepository;
        }

        public async Task<DTO.Order> Execute(Order order)
        {
            return await _OrdersRepository.Create(order);
        }
    }
}
