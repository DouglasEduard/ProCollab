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
    public class PostsController : ApiController
    {
        private ApplicationDbContext _context;

        public PostsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/posts
        public IHttpActionResult GetPosts(string query = null)
        {
            var PostQuery = _context
                                    .Posts
                                    .Include(c => c.Category);

            if (!String.IsNullOrWhiteSpace(query))
                PostQuery = PostQuery.Where(c => c.Title.Contains(query));

            var PostsDTO =
                    PostQuery
                            .ToList()
                            .Select(AutoMapper.Mapper.Map<Post, PostDto>);

            return Ok(PostsDTO);
        }
    }
}
