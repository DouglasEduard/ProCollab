using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using VanHackForumWebApp.Models;

namespace VanHackForumWebApp.ViewModels
{
    public class PostDetail
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Title's post.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter Details' post.")]
        public string Details { get; set; }

        [Display(Name = "Category")]
        public byte Category_ID { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}