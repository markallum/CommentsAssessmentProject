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
        Task<Comment> GetComment(int id);
        Task PostComment(Comment comment);
        Task<int> Vote(int commentId, bool positive);
    }

    public class CommentService : ICommentService
    {
        private DbService _dbService;

        public CommentService(DbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<Comment> GetComment(int id)
        {
            var Comment = await _dbService.Comments.FindAsync(id);

            return Comment;
        }

        public async Task<List<Comment>> GetComments()
        {
            // Get all comments in one db request. Child/parent mapping is done by EF but child comments will be loaded on root level too.
            var Comments = await _dbService.Comments.OrderByDescending(x => x.PostedDateTime).OrderByDescending(x => x.Votes)
                .ToListAsync();
                
            // Remove child comments from root level
            Comments.RemoveAll(x => x.Parent != null);

            return Comments;
        }

        public async Task PostComment(Comment comment)
        {
            _dbService.Comments.Add(comment);
            await _dbService.SaveChangesAsync();
        }

        public async Task<int> Vote(int commentId, bool positive)
        {
            var comment = await _dbService.Comments.FindAsync(commentId);

            if (positive)
            {
                comment.Votes++;
            }
            else
            {
                comment.Votes--;
            }

            _dbService.Update(comment);
            await _dbService.SaveChangesAsync();

            return comment.Votes;
        }

    }
}
