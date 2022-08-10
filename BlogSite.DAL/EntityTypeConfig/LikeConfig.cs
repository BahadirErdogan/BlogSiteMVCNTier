using BlogSite.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.DAL.EntityTypeConfig
{
    public class LikeConfig : BaseEntityConfig<Like>
    {
        public override void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.HasOne(x => x.AppUser).WithMany(x => x.Likes).HasForeignKey(x => x.AppUserId);
            builder.HasOne(x => x.Post).WithMany(x => x.Likes).HasForeignKey(x => x.PostId);
            builder.HasOne(x => x.Comment).WithMany(x => x.Likes).HasForeignKey(x => x.CommentId);
            base.Configure(builder);
        }
    }
}
