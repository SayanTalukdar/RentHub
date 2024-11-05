using RentHubBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentHubBackend.Repository
{
   public  interface IFavouriteRepository
    {
        Task<int> AddFavourite(FavouriteModel dataModel);
    }
}
