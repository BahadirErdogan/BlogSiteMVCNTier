using BlogSite.BLL.Extensions;
using BlogSite.BLL.Models.VMs;
using BlogSite.Core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.BLL.Models.DTOs
{
    public class CreatePostDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        [FileExt]
        public IFormFile UploadPath { get; set; }
        public DateTime CreationDate => DateTime.Now;
        public Status Status => Status.Active;
        public PostStatus PostStatus { get; set; }
        public List<GetTopicVM> Topics { get; set; }

    }
}
