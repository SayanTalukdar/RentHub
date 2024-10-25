using RentHubBackend.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentHubBackend.Services
{
    public class SigninService : ISigninService

    {
        private readonly RentHubBackendContext Context;

        public SigninService(RentHubBackendContext context)
        {
            Context = context;
        }

        public string GetUserId(string email)
        {
            var res = Context.Users.FirstOrDefault(x => x.UserName == email);
            return res.Id;
        }
    }
}
