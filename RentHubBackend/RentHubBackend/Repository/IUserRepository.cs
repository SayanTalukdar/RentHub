using Microsoft.AspNetCore.Identity;
using RentHubBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentHubBackend.Repository
{
    public interface IUserRepository
    {
        Task<IdentityResult> CreateUserAsync(UserModel userModel);
        Task<string[]> SignInAsync(SigninModel signInModel);
    }
}
