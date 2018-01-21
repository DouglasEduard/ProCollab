using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VanHackForumWebApp.Models;
using VanHackForumWebApp.DTOs;

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
    }
}
