using System;

namespace Training.Data.Extensions
{
    public static class UserExtension
    {
        public static DTO.User ToDTO(this Models.User u){
            return new DTO.User
            {
                Id = u.Id.ToString(),
                Email = u.Email,
                FullName = u.FullName,
                Gender = u.Gender
            };
        }

        public static DTO.UserCredentials ToCredentialsDTO(this Models.User u)
        {
            return new DTO.UserCredentials
            {
                Id = u.Id.ToString(),
                Email = u.Email,
                FullName = u.FullName,
                Gender = u.Gender,
                Password = u.Password,
                Role = u.Role
            };
        }

        public static Models.User ToDatabaseModel(this DTO.UserCredentials u)
        {
            return new Models.User
            {
                Id = Guid.Parse(u.Id),
                Email = u.Email,
                FullName = u.FullName,
                Gender = u.Gender,
                Password = u.Password,
                RefreshToken = u.RefreshToken,
                Role = u.Role
            };
        }
    }
}
