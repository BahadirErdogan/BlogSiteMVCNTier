using BlogSite.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Core.Entities
{
    public class Post : IBaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public PostStatus PostStatus { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }

        //Relations

        public int TopicId { get; set; }
        public Topic Topic { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }


        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; }
    }
}
