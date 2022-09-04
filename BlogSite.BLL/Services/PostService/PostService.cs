using AutoMapper;
using BlogSite.BLL.Models.DTOs;
using BlogSite.BLL.Models.VMs;
using BlogSite.Core.Entities;
using BlogSite.Core.Enums;
using BlogSite.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.BLL.Services.PostService
{
    public class PostService : IPostService
    {
        private readonly IPostRepository postRepository;
        private readonly IMapper mapper;

        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            this.postRepository = postRepository;
            this.mapper = mapper;
        }
        public async Task Create(CreatePostDTO model)
        {
            var post = mapper.Map<Post>(model);
            await postRepository.Create(post);
        }

        public async Task Delete(int id)
        {
            var post = await postRepository.GetWhere(x => x.Id == id);
            postRepository.Delete(post);
        }

        public async Task<UpdatePostDTO> GetById(int id)
        {
            var post = await postRepository.GetFilteredFirstOrDefault(
                selector: x => new UpdatePostDTO {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    Image = x.Image
                },
                expression: x => x.Id == id && x.Status! != Status.Passive);
            return post;
        }

        public async Task<List<GetPostDetailsVM>> GetPostDetails(int id)
        {
                        var posts = await postRepository.GetFilteredList(
                selector: x => new GetPostDetailsVM
                {
                    Id = id,
                    Title = x.Title,
                    Content = x.Content,
                    Image = x.Image,
                    AuthorFullName = x.AppUser.FullName,
                    AuthorImage = x.AppUser.ImagePath,
                    LikeCount = x.Likes.Count,
                    CommentCount = x.Comments.Count,
                    Comments = x.Comments.Where(x => x.PostId == id).OrderByDescending(x => x.CreationDate).Select(x => new GetCommentVM
                    {
                        Id = x.Id,
                        Text = x.Text,
                        CreationDate = x.CreationDate,
                        UserImage = x.AppUser.ImagePath,
                        UserName = x.AppUser.UserName
                    }).ToList()
                },
                expression: x => x.Status != Core.Enums.Status.Passive,
                orderBy: x => x.OrderByDescending(x => x.CreationDate),
                includes: x => x.Include(x => x.AppUser).ThenInclude(x => x.Comments));
            return posts;
        }

        public async Task<List<GetPostVM>> GetPosts()
        {
            var posts = await postRepository.GetFilteredList(
                selector: x => new GetPostVM
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    Image = x.Image,
                    AuthorFullName = x.AppUser.FullName,
                    AuthorImage = x.AppUser.ImagePath,
                    LikeCount = x.Likes.Count,
                    CommentCount = x.Comments.Count,
                },
                expression: x => x.Status != Core.Enums.Status.Passive,
                orderBy: x => x.OrderByDescending(x => x.CreationDate),
                includes: x => x.Include(x => x.AppUser));
            return posts;
        }

        public void Update(UpdatePostDTO model)
        {
            var post = mapper.Map<Post>(model);
            postRepository.Update(post);
        }
    }
}
