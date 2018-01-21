using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VanHackForumWebApp.DTOs
{
    public class PostCommentDto
    {
        public int Id { get; set; }

        public Nullable<DateTime> Date { get; set; }

        [StringLength(30)]
        public string UserNickName { get; set; }
        
        [Required(ErrorMessage = "Please enter Comment.")]
        public string Comment { get; set; }

        [Required]
        public int Post_ID { get; set; }
    }
}