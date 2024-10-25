using RentHubBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentHubBackend.Repository
{
    public interface IApartmentRepository
    {
        Task<int> CreateData(ApartmentModel dataModel);
    }
}
