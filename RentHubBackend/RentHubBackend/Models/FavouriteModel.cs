﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentHubBackend.Models
{
    public class FavouriteModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public int ApartmentId { get; set; }
    }
}
