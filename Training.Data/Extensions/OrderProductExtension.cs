using System.Collections.Generic;

namespace Training.Data.Extensions
{
    public static class OrderProductExtension
    {
        public static List<DTO.OrderProduct> ToDTO(this List<Models.OrderProduct> orderProducts)
        {
            List<DTO.OrderProduct> OrderProductToDTO = new List<DTO.OrderProduct>();

            foreach (Models.OrderProduct orderProduct in orderProducts)
            {
                OrderProductToDTO.Add(orderProduct.ToDTO());
            }

            return OrderProductToDTO;
        }

        public static DTO.OrderProduct ToDTO(this Models.OrderProduct orderProduct)
        {
            return new DTO.OrderProduct
            {
                Id = orderProduct.Id.ToString(),
                Quantity = orderProduct.Quantity,
                Product = orderProduct.Product.ToDTO()
            };
        }
    }
}
