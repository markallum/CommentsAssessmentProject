using CommentsAssessmentProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommentsAssessmentProject.Services
{
    public interface ICommentsService
    {
        Task<List<Comment>> GetComments();
    }

    public class CommentService : ICommentsService
    {
        private DbService _dbService;

        public CommentService(DbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<List<Comment>> GetComments()
        {
            List<Comment> Comments = await _dbService.Comments.OrderByDescending(x => x.PostedDateTime).ToListAsync();
            return Comments;
        }

    }
}
