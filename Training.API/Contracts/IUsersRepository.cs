using System.Collections.Generic;
using System.Threading.Tasks;
using Training.DTO;

namespace Training.API.Contracts
{
    public interface IUsersRepository
    {
        Task<List<User>> GetAll();

        UserCredentials GetUserCredentialsByEmail(string email);

        Task<User> Create(UserCredentials user);

        Task<bool> Exists(UserCredentials user);

        Task<UserCredentials> Update(UserCredentials user);
    }
}
