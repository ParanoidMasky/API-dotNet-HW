namespace Training.Data.Extensions
{
    public static class OrderExtension
    {
        public static DTO.Order ToDTO(this Models.Order u)
        {
            return new DTO.Order
            {
                Id = u.Id.ToString(),
                UserId = u.UserId.ToString()
            };
        }
    }
}