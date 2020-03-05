using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.API.Contracts;
using Training.Data.Extensions;
using Training.DTO;

namespace Training.Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly StoreContext _StoreContext;

        public UsersRepository(StoreContext storeContext)
        {
            _StoreContext = storeContext;
        }

        public async Task<List<DTO.User>> GetAll()
        {
            var users = await _StoreContext.Users.ToListAsync();
            var usersDTOList = users.Select(x => x.ToDTO()).ToList();
            return usersDTOList;
        }

        public async Task<DTO.User> Create(DTO.UserCredentials user)
        {
            Models.User userDb = new Models.User()
            {
                Email = user.Email,
                FullName = user.FullName,
                Gender = user.Gender,
                Password = user.Password,
                Role = user.Role
            };

            var d = await _StoreContext.AddAsync(userDb);
            await _StoreContext.SaveChangesAsync();
            return d.Entity.ToDTO();
        }

        public async Task<bool> Exists(DTO.UserCredentials user)
        {
            return await _StoreContext.Users.AnyAsync(x => x.Email == user.Email);
        }

        public UserCredentials GetUserCredentialsByEmail(string email)
        {
            var user = _StoreContext.Users.Where(x => x.Email == email).AsNoTracking().FirstOrDefault();
            return user.ToCredentialsDTO();
        }

        public async Task<UserCredentials> Update(UserCredentials user)
        {
            var databaseModel = user.ToDatabaseModel();
            _StoreContext.Users.Update(databaseModel);
            
            await _StoreContext.SaveChangesAsync();
            return databaseModel.ToCredentialsDTO();
        }
    }
}
