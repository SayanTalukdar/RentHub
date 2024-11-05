using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentHubBackend.Models;
using System;
using System.Collections.Generic;
using System.Text.Json;

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

        public DbSet<FavouriteModel> FavouriteModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApartmentModel>()
                .Property(a => a.Amenities)
                .HasConversion(
                    new ValueConverter<List<string>, string>(
                        v => JsonSerializer.Serialize(v, null),
                        v => JsonSerializer.Deserialize<List<string>>(v, null)
                    ));
        }
    }
}
