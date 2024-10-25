using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentHubBackend.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please enter your full name")]
        public string FullName { get; set; }


        [Required(ErrorMessage = "Please enter a strong password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
