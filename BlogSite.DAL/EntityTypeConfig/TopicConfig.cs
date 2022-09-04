using BlogSite.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.DAL.EntityTypeConfig
{
    public class TopicConfig : BaseEntityConfig<Topic>
    {
        public override void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            base.Configure(builder);
        }
    }
}
