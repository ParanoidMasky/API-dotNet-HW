using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Training.API.Operations.Orders;
using Training.API.Operations.Users;
using Training.Data.Models;
using Training.DTO;

namespace Training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IServiceProvider _IoC;

        public UsersController(IServiceProvider services)
        {
            _IoC = services;
        }

        [HttpGet]
        [Authorize(Roles="administrador")]
        public async Task<List<DTO.User>> GetUsers()
        {
            return await _IoC.GetService<GetAll>().Execute();
        }

        [HttpPost]
        [Route("signup")]
        [AllowAnonymous]
        public async Task<DTO.User> SignUp(UserCredentials user)
        {
            return await _IoC.GetService<SignUp>().Execute(user);
        }

        [HttpPost]
        [Route("signin")]
        [AllowAnonymous]
        public async Task<DTO.UserAuthorization> SignIn(UserCredentials user)
        {
            return await _IoC.GetService<SignIn>().Execute(user);
        }
    }
}