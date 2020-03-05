using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Training.API.Contracts;
using Training.API.Contracts.Services;
using Training.DTO;
using Training.Exceptions;

namespace Training.API.Operations.Users
{
    public class SignIn
    {
        private readonly IUsersRepository _UsersRepository;
        private readonly IPasswordHasher _PasswordHasher;
        private readonly ITokenService _TokenService;

        public SignIn(IUsersRepository usersRepository, IPasswordHasher passwordHasher, ITokenService tokenService)
        {
            _UsersRepository = usersRepository;
            _PasswordHasher = passwordHasher;
            _TokenService = tokenService;
        }


        public async Task<DTO.UserAuthorization> Execute(UserCredentials user)
        {
            var userDb = _UsersRepository.GetUserCredentialsByEmail(user.Email);
            if (userDb == null)
            {
                throw new ObjectDoesNotExistException("Invalid Credentials");
            }
            ValidatePassword(user, userDb);
            UserAuthorization userAuthorization = GenerateSessionClaims(userDb);

            userDb.RefreshToken = _TokenService.GenerateRefreshToken();

            await _UsersRepository.Update(userDb);

            return userAuthorization;
        }

        private UserAuthorization GenerateSessionClaims(UserCredentials user)
        {
            var usersClaims = new[]
                        {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            };
            var userAuthorization = new UserAuthorization()
            {
                AccessToken = _TokenService.GenerateAccessToken(usersClaims)
            };
            return userAuthorization;
        }

        private void ValidatePassword(UserCredentials user, UserCredentials userDb)
        {
            if(!_PasswordHasher.VerifyIdentityV3Hash(user.Password, userDb.Password))
            {
                throw new InvalidCredentialsException("Invalid Credentials");
            }
        }

    }
}
