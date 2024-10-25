using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentHubBackend.Models;
using System;

namespace RentHubBackend.Context
{
    public class RentHubBackendContext : IdentityDbContext<CustomUser>
    {
        public RentHubBackendContext(DbContextOptions<RentHubBackendContext> options)
            : base(options)
        {
        }

        public DbSet<UserModel> UserModel { get; set; }

        public DbSet<ApartmentModel> ApartmentModel { get; set; }

        public DbSet<CommentsModel> CommentsModel { get; set; }
    }
}
