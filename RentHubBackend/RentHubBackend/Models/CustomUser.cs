using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentHubBackend.Models
{
    public class CustomUser : IdentityUser
    {
        public string EmailAddress { get; set; }
        public string MyPassword { get; set; }

        public string FullName { get; set; }
    }
}
