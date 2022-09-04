using BlogSite.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.DAL.EntityTypeConfig
{
    public class PostConfig : BaseEntityConfig<Post>
    {
        public override void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Content).IsRequired();
            builder.HasOne(x => x.AppUser).WithMany(x => x.Posts).HasForeignKey(x => x.AppUserId);
            builder.HasOne(x => x.Topic).WithMany(x => x.Posts).HasForeignKey(x => x.TopicId);

            base.Configure(builder);
        }
    }
}
