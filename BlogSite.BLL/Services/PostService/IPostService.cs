using BlogSite.BLL.Models.DTOs;
using BlogSite.BLL.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.BLL.Services.PostService
{
    public interface IPostService
    {
        Task Create(CreatePostDTO model);
        void Update(UpdatePostDTO model);
        Task<UpdatePostDTO> GetById(int id);
        Task Delete(int id);
        Task<List<GetPostVM>> GetPosts();
        Task<List<GetPostDetailsVM>> GetPostDetails(int id);
    }
}
