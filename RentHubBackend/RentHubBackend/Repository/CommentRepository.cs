using RentHubBackend.Context;
using RentHubBackend.Models;
using RentHubBackend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentHubBackend.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly RentHubBackendContext Context;
        private readonly ISigninService SigninService;

        public CommentRepository(RentHubBackendContext context,
            ISigninService signinService)
        {
            Context = context;
            SigninService = signinService;
        }

        public async Task<int> CreateComment(CommentsModel commentModel)
        {
            var comment = new CommentsModel
            {
                UserId = SigninService.GetUserId(commentModel.Email),
                Email = commentModel.Email,
                ApartmentId = commentModel.ApartmentId,
                CommentMade = commentModel.CommentMade,
                Date = DateTime.Now
            };

            Context.CommentsModel.Add(comment);
            var result = await Context.SaveChangesAsync();
            return result;
        }
    }
}
