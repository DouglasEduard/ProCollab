using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VanHackForumWebApp.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public string Details { get; set; }

        public Category Category { get; set; }
        
        public ApplicationUser User { get; set; }

        [StringLength(30)]
        public string UserNickName { get; set; }
    }
}