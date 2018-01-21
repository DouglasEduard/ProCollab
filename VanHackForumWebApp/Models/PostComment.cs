using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VanHackForumWebApp.Models
{
    public class PostComment
    {
        public int Id { get; set; }

        public Nullable<DateTime> Date { get; set; }

        [StringLength(30)]
        public string UserNickName { get; set; }

        public string Comment { get; set; }

        public ApplicationUser User { get; set; }

        public Post Post { get; set; }
    }
}