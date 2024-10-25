using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RentHubBackend.Models;
using RentHubBackend.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RentHubBackend.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<CustomUser> UserManager;
        private readonly SignInManager<CustomUser> SigninManager;
        private readonly IConfiguration Configuration;
        private readonly ISigninService SigninService;


        public UserRepository(UserManager<CustomUser> userManager,
                                SignInManager<CustomUser> signInManager,
                                IConfiguration configuration,
                                ISigninService signInServices)
        {
            UserManager = userManager;
            SigninManager = signInManager;
            Configuration = configuration;
            SigninService = signInServices;
        }

        public async Task<IdentityResult> CreateUserAsync(UserModel userModel)
        {
            var user = new CustomUser()
            {
                UserName = userModel.Email,
                FullName = userModel.FullName,
                MyPassword = userModel.Password,
                EmailAddress = userModel.Email,
            };
            var result = await UserManager.CreateAsync(user, userModel.Password);
            return result;
        }

        public async Task<string[]> SignInAsync(SigninModel signInModel)
        {
            var result = await SigninManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, false, false);
            if (!result.Succeeded)
                return null;

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, signInModel.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                    issuer: Configuration["JWT:ValidIssuer"],
                    audience: Configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddDays(1),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256Signature)
                 );
            var userId = SigninService.GetUserId(signInModel.Email);
            var resToken = new JwtSecurityTokenHandler().WriteToken(token);
            string[] data = { resToken, userId, signInModel.Email };
            return data;

        }
    }
}
