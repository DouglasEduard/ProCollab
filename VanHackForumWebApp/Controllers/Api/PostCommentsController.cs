using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VanHackForumWebApp.Models;
using VanHackForumWebApp.DTOs;
using Microsoft.AspNet.Identity;

namespace VanHackForumWebApp.Controllers.Api
{
    public class PostCommentsController : ApiController
    {
        private ApplicationDbContext _context;

        public PostCommentsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/postcomments
        public IHttpActionResult GetPostComments(string query = null)
        {
            var PostCommentsQuery = _context.PostComments
                                            .Include(c => c.Post);

            if (!String.IsNullOrWhiteSpace(query))
                PostCommentsQuery = PostCommentsQuery.Where(c => c.Comment.Contains(query));

            var PostCommentsDTO =
                    PostCommentsQuery.ToList()
                                     .Select(AutoMapper.Mapper.Map<PostComment, PostCommentDto>);

            return Ok(PostCommentsDTO);
        }

        [HttpPost]
        public IHttpActionResult CreateNewComments(PostCommentDto NewComment)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (String.IsNullOrEmpty(NewComment.Comment))
                return BadRequest("Comment must be filled.");

            string sUserID = User.Identity.GetUserId();
            ApplicationUser user = _context.Users.Select(u => u).Where(w => w.Id == sUserID).Single();

            Post post = _context.Posts.Select(p => p).Where(w => w.Id == NewComment.Post_ID).Single();

            var PostComment = new PostComment
            {
                Date = DateTime.Now,
                UserNickName = user.NickName,
                Comment = NewComment.Comment,
                User = user,
                Post = post
            };

            _context.PostComments.Add(PostComment);

            _context.SaveChanges();

            return Ok();
        }
    }
}
