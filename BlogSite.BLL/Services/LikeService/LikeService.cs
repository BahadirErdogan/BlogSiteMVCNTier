using AutoMapper;
using BlogSite.BLL.Models.DTOs;
using BlogSite.Core.Entities;
using BlogSite.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.BLL.Services.LikeService
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository likeRepository;
        private readonly IMapper mapper;

        public LikeService(ILikeRepository likeRepository, IMapper mapper)
        {
            this.likeRepository = likeRepository;
            this.mapper = mapper;
        }
        public async Task Create(CreateLikeDTO model)
        {
            var like = mapper.Map<Like>(model);
            await likeRepository.Create(like);
        }

        public async Task Delete(int id)
        {
            var like = await likeRepository.GetWhere(x => x.Id == id);
            likeRepository.Delete(like);
        }
    }
}
