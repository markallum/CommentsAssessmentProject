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
        public PartialViewResult Post()
        {
            Comment comment = new Comment();

            return PartialView("_AddComment");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Comment comment)
        {
            comment.PostedDateTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                await _commentService.PostComment(comment);
                return RedirectToAction("Index");
            }
            else
            {
                // This will only be hit if user has JS turned off
                return RedirectToAction("Error");
            }
            
            
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
