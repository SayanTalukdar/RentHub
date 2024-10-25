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
    public class CommentModelController : ControllerBase
    {
        private readonly RentHubBackendContext Context;
        private readonly ICommentRepository dataRepository;

        public CommentModelController(RentHubBackendContext context,
                                            ICommentRepository repository)
        {
            dataRepository = repository;
            Context = context;
        }

        [HttpGet("{apartmentId}")]
        public async Task<IActionResult> GetCommentsForApartment(int apartmentId)
        {
            var comments = await Context.CommentsModel
                .Where(c => c.ApartmentId == apartmentId)
                .ToListAsync();
            return Ok(comments);
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddComment(CommentsModel commentModel)
        {
            var result = await dataRepository.CreateComment(commentModel);
            return CreatedAtAction(nameof(GetCommentsForApartment), new { apartmentId = commentModel.ApartmentId }, commentModel);
        }
    }
}
