using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentHubBackend.Context;
using RentHubBackend.Models;
using RentHubBackend.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RentHubBackend.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentModelController : ControllerBase
    {
        private readonly RentHubBackendContext Context;
        private readonly IApartmentRepository dataRepository;

        public ApartmentModelController(RentHubBackendContext context,
                                            IApartmentRepository repository)
        {
            dataRepository = repository;
            Context = context;
        }

        // GET: api/ApartmentModels
        [Authorize]
        [HttpGet("alldata")]
        public async Task<ActionResult<IEnumerable<ApartmentModel>>> GetApartmentModel()
        {
            return await Context.ApartmentModel.ToListAsync();
        }


        [Authorize]
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<ApartmentModel>>> GetApartmentByUser(string userId)
        {
            return await Context.ApartmentModel.Where(x => x.UserId == userId).ToListAsync();
        }

        // GET: api/ApartmentModels/:id
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<ApartmentModel>> GetApartmentModel(int id)
        {
            var ApartmentModel = await Context.ApartmentModel.FindAsync(id);

            if (ApartmentModel == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                ApartmentModel
            });
        }

        // PUT: api/ApartmentModels/:id
        [Authorize]
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> PutApartmentModel(int id, ApartmentModel ApartmentModel)
        {
            if (id != ApartmentModel.Id)
            {
                return BadRequest();
            }

            Context.Entry(ApartmentModel).State = EntityState.Modified;

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApartmentModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(new
            {
                Message = "Updated Successfully"
            });
        }


        // POST: api/ApartmentModels
        [HttpPost]
        [Authorize]
        [Route("create")]
        public async Task<ActionResult<ApartmentModel>> Create(ApartmentModel ApartmentModel)
        {

            var result = await dataRepository.CreateData(ApartmentModel);
            if (result == 1)
            {
                return Ok(new
                {
                    Message = "Added Successfully"
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

        // DELETE: api/ApartmentModels/:id
        [Authorize]
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<ApartmentModel>> DeleteApartmentModel(int id)
        {
            var ApartmentModel = await Context.ApartmentModel.FindAsync(id);
            if (ApartmentModel == null)
            {
                return NotFound();
            }

            Context.ApartmentModel.Remove(ApartmentModel);
            await Context.SaveChangesAsync();

            return Ok(new
            {
                Message = "Deleted"
            });
        }

        private bool ApartmentModelExists(int id)
        {
            return Context.ApartmentModel.Any(e => e.Id == id);
        }

        [HttpPost("upload"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadImg()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
