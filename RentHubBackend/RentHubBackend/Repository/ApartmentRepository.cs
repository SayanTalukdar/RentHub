using RentHubBackend.Context;
using RentHubBackend.Models;
using RentHubBackend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentHubBackend.Repository
{
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly RentHubBackendContext Context;
        private readonly ISigninService SigninService;

        public ApartmentRepository(RentHubBackendContext context,
            ISigninService signinService)
        {
            Context = context;
            SigninService = signinService;
        }

        public async Task<int> CreateData(ApartmentModel dataModel)
        {

            var data = new ApartmentModel
            {
                UserId = SigninService.GetUserId(dataModel.Email),
                Email = dataModel.Email,
                ApartName = dataModel.ApartName,
                IsShared = dataModel.IsShared,
                ApartLocation = dataModel.ApartLocation,
                ApartDetails = dataModel.ApartDetails,
                StayType = dataModel.StayType,
                ExpectedRent = dataModel.ExpectedRent,
                IsNegotiable = dataModel.IsNegotiable,
                IsFurnished = dataModel.IsFurnished,
                DescpTitle = dataModel.DescpTitle,
                Descp = dataModel.Descp,
                CreatedBy = dataModel.CreatedBy,
                Contact = dataModel.Contact,
                ApartmentImagePath = dataModel.ApartmentImagePath,
                CreatedAt = dataModel.CreatedAt,
                Amenities = dataModel.Amenities,
                Comments = dataModel.Comments

            };
            Context.ApartmentModel.Add(data);
            var result = await Context.SaveChangesAsync();
            return result;
        }
    }
}
