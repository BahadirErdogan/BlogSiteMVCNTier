using BlogSite.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Core.Entities
{
    public class Like : IBaseEntity
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }

        //Relations
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
