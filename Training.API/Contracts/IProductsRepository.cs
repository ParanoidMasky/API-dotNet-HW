using System.Collections.Generic;
using System.Threading.Tasks;
using Training.DTO;

namespace Training.API.Contracts
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetAllProducts();

    }
}
