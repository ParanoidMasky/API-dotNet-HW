using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Training.API.Operations.Orders;
using Training.DTO;

namespace Training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IServiceProvider _IoC;
        public OrdersController(IServiceProvider services)
        {
            _IoC = services;
        }

        // GET: api/Orders
        [HttpGet]
        [Authorize(Roles = "administrador")]
        public async Task<List<DTO.Order>> GetOrders()
        {
            return await _IoC.GetService<GetAllOrders>().Execute();
        }

        // Post th orders from API
        [HttpPost]
        public async Task<Order> PostAsync([FromBody] Order order)
        {
            return await _IoC.GetService<AddOrder>().Execute(order);
        }

        [HttpGet]
        [Route("getMyOrders")]
        public async Task<List<Order>> GetOrdersByUser()
        {
            User user = new User()
            {
                Id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value,
                Email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value,
            };

            //execute order
            return await _IoC.GetService<GetOrdersByUser>().Execute(user);
        }
    }
}
