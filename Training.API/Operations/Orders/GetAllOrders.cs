using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Training.API.Contracts;

namespace Training.API.Operations.Orders
{
    public class GetAllOrders
    {
        private readonly IOrdersRepository _OrdersRepository;

        public GetAllOrders(IOrdersRepository ordersRepository)
        {
            _OrdersRepository = ordersRepository;
        }

        public async Task<List<DTO.Order>> Execute()
        {
            return await _OrdersRepository.GetAllOrders();
        }
    }
}
