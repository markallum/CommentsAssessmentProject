using CommentsAssessmentProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommentsAssessmentProject.Services
{
    public interface ICommentService
    {
        Task<List<Comment>> GetComments();
        Task PostComment(Comment comment);
    }

    public class CommentService : ICommentService
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

        public async Task PostComment(Comment comment)
        {
            _dbService.Comments.Add(comment);
            await _dbService.SaveChangesAsync();
        }

    }
}
