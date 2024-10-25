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
            //string fileName = UploadFile(dataModel);

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
                IsFavourited = dataModel.IsFavourited,
                ApartmentImagePath = dataModel.ApartmentImagePath,
                CreatedAt = dataModel.CreatedAt,
            
            };
            Context.ApartmentModel.Add(data);
            var result = await Context.SaveChangesAsync();
            return result;
        }

        /*private string UploadFile(ReimbursmentModel dataModel)
        {
            string fileName = null;
            if (dataModel.ReceiptImage != null)
            {

                if (!Directory.Exists(_webHostEnvironment.WebRootPath+ "\\Upload\\"))
                {
                    Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Upload\\");
                }

                using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.WebRootPath + "\\Upload\\" + dataModel.ReceiptImage.FileName))
                {
                    dataModel.ReceiptImage.CopyTo(fileStream);
                    fileStream.Flush();
                    return "\\Upload\\" + dataModel.ReceiptImage.FileName;
                }

*//*                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "ReImbursmentPortalBackend/Data/Images/");
                fileName = Guid.NewGuid().ToString() + dataModel.ReceiptImage.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    dataModel.ReceiptImage.CopyTo(fileStream);
                }*//*
            }
            return fileName;
        }*/
    }
}
