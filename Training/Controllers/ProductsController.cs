using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Training.API.Operations.Products;

namespace Training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IServiceProvider _IoC;

        public ProductsController(IServiceProvider services)
        {
            _IoC = services;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<List<DTO.Product>> GetProducts()
        {
            return await _IoC.GetService<GetAllProducts>().Execute();
        }
    }
}
