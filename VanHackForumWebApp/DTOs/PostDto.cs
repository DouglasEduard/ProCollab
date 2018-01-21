using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using VanHackForumWebApp.Models;

namespace VanHackForumWebApp.DTOs
{
    public class PostDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Title.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter Details.")]
        public string Details { get; set; }

        [Required(ErrorMessage = "Please enter Category.")]
        public byte Category_ID { get; set; }

        public CategoryDto Category { get; set; }
    }
}