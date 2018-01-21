using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VanHackForumWebApp.Models;
using VanHackForumWebApp.ViewModels;
using VanHackForumWebApp.DTOs;

namespace VanHackForumWebApp.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Post, PostDto>();
            Mapper.CreateMap<PostDto, Post>();
            Mapper.CreateMap<PostDetail, PostDto>();
            Mapper.CreateMap<PostDto, PostDetail>();
            Mapper.CreateMap<Category, CategoryDto>();
            Mapper.CreateMap<CategoryDto, Category>();
        }
    }
}