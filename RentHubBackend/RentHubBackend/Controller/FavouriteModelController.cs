using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentHubBackend.Context;
using RentHubBackend.Models;
using RentHubBackend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentHubBackend.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class FavouriteModelController : ControllerBase
    {
        private readonly RentHubBackendContext Context;
        private readonly IFavouriteRepository FavouriteRepository;

        public FavouriteModelController(RentHubBackendContext context,
                                           IFavouriteRepository favouriteRepository)
        {
            FavouriteRepository = favouriteRepository;
            Context = context;
        }

        [Authorize]
        [HttpPost("markFavorite")]
        public async Task<IActionResult> MarkAsFavorite(FavouriteModel FavouriteModel)
        {
            var result = await FavouriteRepository.AddFavourite(FavouriteModel);
            if (result == 1)
            {
                return Ok(new
                {
                    Message = "Success"
                });
            }
            else
            {
                return Ok(new
                {
                    Message = "Something went wrong try again"
                });
            }
        }

        [Authorize]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetFavorites(string userId)
        {
            var favorites = await Context.FavouriteModel
                .Where(i => i.UserId == userId)
                .ToListAsync();
            return Ok(favorites);
        }

        [Authorize]
        [HttpDelete("{userId}/{id}")]
        public async Task<IActionResult> RemoveFavourite(string userId, int id)
        {
            var interest = await Context.FavouriteModel
                .Where(i => i.UserId == userId && i.ApartmentId == id)
                .FirstAsync();

            Context.FavouriteModel.Remove(interest);
            await Context.SaveChangesAsync();
            return NoContent();
        }

    }
}