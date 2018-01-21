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
            //Post
            Mapper.CreateMap<Post, PostDto>();
            Mapper.CreateMap<PostDto, Post>();
            Mapper.CreateMap<Post, PostDetail>();
            Mapper.CreateMap<PostDetail, Post>();
            Mapper.CreateMap<PostDetail, PostDto>();
            Mapper.CreateMap<PostDto, PostDetail>();

            //Category
            Mapper.CreateMap<Category, CategoryDto>();
            Mapper.CreateMap<CategoryDto, Category>();

            //PostComment
            Mapper.CreateMap<PostComment, PostCommentDto>();
            Mapper.CreateMap<PostCommentDto, PostComment>();
        }
    }
}