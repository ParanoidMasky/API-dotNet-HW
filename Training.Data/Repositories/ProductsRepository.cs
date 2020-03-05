using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.API.Contracts;
using Training.Data.Extensions;
using Training.DTO;

namespace Training.Data.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly StoreContext _StoreContext;

        public ProductsRepository(StoreContext storeContext)
        {
            _StoreContext = storeContext;
        }

        public async Task<List<DTO.Product>> GetAllProducts()
        {
            var products = await _StoreContext.Products.ToListAsync();
            var productsDTOList = products.Select(x => x.ToDTO()).ToList();
            return productsDTOList;
        }
    }
}
