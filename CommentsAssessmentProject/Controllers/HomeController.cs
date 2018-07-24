using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CommentsAssessmentProject.Models;
using CommentsAssessmentProject.Services;

namespace CommentsAssessmentProject.Controllers
{
    public class HomeController : Controller
    {
        private ICommentService _commentService;

        public HomeController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _commentService.GetComments());
        }


        [HttpGet]
        public PartialViewResult Post(int ParentId = 0)
        {
            Reply reply = new Reply();
            reply.ParentId = ParentId;

            return PartialView("_AddComment");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Reply reply)
        {
            if (ModelState.IsValid)
            {
                Comment comment = new Comment();

                comment.Author = reply.Author;
                comment.CommentContent = reply.CommentContent;
                comment.PostedDateTime = DateTime.Now;
                if (reply.ParentId != 0)
                {
                    // Reply not a root comment, get parent and save comment as child
                    comment.Parent = await _commentService.GetComment(reply.ParentId);
                    comment.Parent.Children.Add(comment);
                }

                await _commentService.PostComment(comment);
                return RedirectToAction("Index");
            }
            else
            {
                // This will only be hit if user has JS turned off
                return RedirectToAction("Error");
            }
        }

        [HttpPost]
        public async Task<int> Vote(int commentId, bool positive = true)
        {
            int newVoteCount = await _commentService.Vote(commentId, positive);
            return newVoteCount;
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
