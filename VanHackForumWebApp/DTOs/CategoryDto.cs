using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VanHackForumWebApp.DTOs
{
    public class CategoryDto
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public int Amount { get; set; }
    }
}