using Microsoft.AspNetCore.Mvc;
using RentHubBackend.Context;
using RentHubBackend.Models;
using RentHubBackend.Repository;
using RentHubBackend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentHubBackend.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserModelController : ControllerBase
    {
        private readonly RentHubBackendContext Context;
        private readonly IUserRepository userRepository;

        public UserModelController(RentHubBackendContext context,
                                    IUserRepository repository)
        {
            Context = context;
            userRepository = repository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUserModel(int id)
        {
            var userModel = await Context.UserModel.FindAsync(id);

            if (userModel == null)
            {
                return NotFound();
            }

            return userModel;
        }

        // POST: api/UserModels
        [Route("signup")]
        [HttpPost]
        public async Task<ActionResult<UserModel>> Signup([FromBody] UserModel userModel)
        {
            if (Context.Users.Where(u => u.EmailAddress == userModel.Email).FirstOrDefault() != null)
            {
                return Ok(new
                {
                    Message = "Already Exists"
                });
            }
            var result = await userRepository.CreateUserAsync(userModel);
            if (!result.Succeeded)
            {
                return Ok(result.Errors);
            }
            return Ok(new
            {
                Message = "Success"
            });
        }

        [Route("signin")]
        [HttpPost]
        public async Task<IActionResult> SignIn(SigninModel signInModel)
        {

            var result = await userRepository.SignInAsync(signInModel);
            if (result == null)
            {
                return Ok(new
                {
                    Message = "Failure"
                });
            }
            return Ok(new
            {
                Token = result[0],
                UserId = result[1],
                Email = result[2],
                Message = "Success"
            });
        }
    }
}
