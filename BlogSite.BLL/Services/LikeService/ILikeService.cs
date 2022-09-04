using BlogSite.BLL.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.BLL.Services.LikeService
{
    public interface ILikeService
    {
        Task Create(CreateLikeDTO model);
        Task Delete(int id);
    }
}
