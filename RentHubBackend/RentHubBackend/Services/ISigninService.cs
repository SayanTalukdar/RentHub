using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentHubBackend.Services
{
    public interface ISigninService
    {
        string GetUserId(string email);
        string GetUserName(string email);
    }
}
