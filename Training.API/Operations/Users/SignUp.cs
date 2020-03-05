using System;
using System.Threading.Tasks;
using Training.API.Contracts;
using Training.API.Contracts.Services;
using Training.DTO;
using Training.Exceptions;

namespace Training.API.Operations.Users
{
    public class SignUp
    {
        private readonly IUsersRepository _UsersRepository;
        private readonly IPasswordHasher _PasswordHasher;

        public SignUp(IUsersRepository usersRepository, IPasswordHasher passwordHasher)
        {
            _UsersRepository = usersRepository;
            _PasswordHasher = passwordHasher;

        }

        public async Task<DTO.User> Execute(UserCredentials user)
        {
            await ValidateUserExists(user);
            user.Role = "Default";
            user.Password = _PasswordHasher.GenerateIdentityV3Hash(user.Password);
            return await _UsersRepository.Create(user);
        }

        private async Task ValidateUserExists(UserCredentials user)
        {
            if (await _UsersRepository.Exists(user))
            {
                throw new PreconditionFailedException("User Already Exists");
            }
        }
    }
}
