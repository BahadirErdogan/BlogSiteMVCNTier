using BlogSite.BLL.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.BLL.Services.CommentService
{
    public interface ICommentService
    {
        Task Create(CreateCommentDTO model);
        Task Delete(int id);
    }
}
