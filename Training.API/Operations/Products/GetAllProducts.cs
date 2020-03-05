using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Training.API.Contracts;

namespace Training.API.Operations.Products
{
    public class GetAllProducts
    {
        private readonly IProductsRepository _ProductsRepository;

        public GetAllProducts(IProductsRepository productsRepository)
        {
            _ProductsRepository = productsRepository;
        }

        public async Task<List<DTO.Product>> Execute()
        {
            return await _ProductsRepository.GetAllProducts();
        }
    }
}
