using AutoMapper;
using BlogSite.BLL.Models.DTOs;
using BlogSite.Core.Entities;
using BlogSite.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.BLL.Services.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository commentRepository;
        private readonly IMapper mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            this.commentRepository = commentRepository;
            this.mapper = mapper;
        }
        public async Task Create(CreateCommentDTO model)
        {
            var comment = mapper.Map<Comment>(model);
            await commentRepository.Create(comment);
        }

        public async Task Delete(int id)
        {
            var comment = await commentRepository.GetWhere(x => x.Id == id);
            commentRepository.Delete(comment);
        }
    }
}
