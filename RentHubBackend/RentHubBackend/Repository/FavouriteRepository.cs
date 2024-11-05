using RentHubBackend.Context;
using RentHubBackend.Models;
using RentHubBackend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentHubBackend.Repository
{
    public class FavouriteRepository : IFavouriteRepository
    {
        private readonly RentHubBackendContext Context;
        private readonly ISigninService SigninService;

        public FavouriteRepository(RentHubBackendContext context,
            ISigninService signinService)
        {
            Context = context;
            SigninService = signinService;
        }

        public async Task<int> AddFavourite(FavouriteModel dataModel)
        {

            var data = new FavouriteModel
            {
                UserId = SigninService.GetUserId(dataModel.Email),
                Email = dataModel.Email,
                ApartmentId = dataModel.ApartmentId,
            };
            Context.FavouriteModel.Add(data);
            var result = await Context.SaveChangesAsync();
            return result;
        }
    }
}
