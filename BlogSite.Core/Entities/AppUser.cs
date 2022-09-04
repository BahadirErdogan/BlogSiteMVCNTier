using BlogSite.Core.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Core.Entities
{
    public class AppUser : IdentityUser, IBaseEntity
    {
        public string FullName { get; set; }
        public string ImagePath { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender? Gender { get; set; }
        public string ShortBio { get; set; }
        public string Url { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }


        //Relations

        public List<Post> Posts { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; }
    }
}
