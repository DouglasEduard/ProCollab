using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using VanHackForumWebApp.Models;
using VanHackForumWebApp.ViewModels;
using Microsoft.AspNet.Identity;
using VanHackForumWebApp.DTOs;
using System.Data.Entity.Validation;

namespace VanHackForumWebApp.Controllers
{
    public class PostsController : Controller
    {
        private ApplicationDbContext _context;

        public PostsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Posts
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewPost()
        {            
            var Categories = _context.Categories.ToList();

            var ViewModel = new PostDetail
            {
                Categories = Categories
            };

            return View("PostForm", ViewModel);
        }

        private PostDetail GetPostDetails(int Id, bool bLoadCategories, out bool bNotFound)
        {
            bNotFound = false;

            var post = _context
                                .Posts.Include(c => c.Category).Include(u => u.User)
                                .SingleOrDefault(c => c.Id == Id);

            if (post == null)
            {
                bNotFound = true;
                return new PostDetail();
            }

            PostDetail ResultView = new PostDetail();

            if (bLoadCategories)
            {
                var Categories = _context.Categories.ToList();

                ResultView = new PostDetail
                {
                    Categories = Categories
                };
            }

            AutoMapper.Mapper.Map(post, ResultView);

            ResultView.EditionAllowed = post.User.Id == User.Identity.GetUserId();

            return ResultView;
        }

        public ActionResult EditPost(int Id)
        {
            bool bNotFound = false;

            PostDetail postDetail = GetPostDetails(Id, true, out bNotFound);

            if (!postDetail.EditionAllowed)
                return RedirectToAction("NotAllowed", "Posts");
            else
                return View("PostForm", postDetail);
        }

        public ActionResult Details(int Id)
        {
            bool bNotFound = false;

            PostDetail ResultView = GetPostDetails(Id, false, out bNotFound);

            if (bNotFound)
                return HttpNotFound();

            return View(ResultView);
        }

        public ActionResult NotAllowed()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(PostDto postDTO)
        {
            if (!ModelState.IsValid)
            {
                PostDetail post = new PostDetail();

                post.Categories = _context.Categories.ToList();

                return View("PostForm", post);
            }

            try
            {
                string sUserID = User.Identity.GetUserId();

                if (postDTO.Id == 0) //New posto
                {
                    var Post = AutoMapper.Mapper.Map<PostDto, Post>(postDTO);

                    Post.User = _context.Users.Select(u => u).Where(w => w.Id == sUserID).Single();
                    Post.UserNickName = Post.User.NickName; //Avoid query in users table when showing up posts list

                    Post.Category = _context.Categories.Select(c => c).Where(w => w.ID == postDTO.Category_ID).Single();

                    _context.Posts.Add(Post);
                }
                else //Post editing
                {
                    var PostInDb = _context.Posts.Single(c => c.Id == postDTO.Id);

                    AutoMapper.Mapper.Map(postDTO, PostInDb);
                }

                _context.SaveChanges();

            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Index", "Posts");
        }
    }
}