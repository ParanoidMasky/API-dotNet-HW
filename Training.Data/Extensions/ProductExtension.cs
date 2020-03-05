using System;
using System.Collections.Generic;
using System.Text;

namespace Training.Data.Extensions
{
    public static class ProductExtension
    {
        public static DTO.Product ToDTO(this Models.Product u)
        {
            return new DTO.Product
            {
                Id = u.Id.ToString(),
                Name = u.Name,
                Price = u.Price
            };
        }
    }
}
