using System.Collections.Generic;
using System.Threading.Tasks;
using Training.API.Contracts;

namespace Training.API.Operations.Users
{
    public class GetAll
    {
        private readonly IUsersRepository _UsersRepository;

        public GetAll(IUsersRepository usersRepository)
        {
            _UsersRepository = usersRepository;
        }

        public async Task<List<DTO.User>> Execute()
        {
            return await _UsersRepository.GetAll();
        }

    }
}
