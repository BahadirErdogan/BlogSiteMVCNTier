using BlogSite.Core.Entities;
using BlogSite.DAL.EntityTypeConfig;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AppUserConfig());
            builder.ApplyConfiguration(new CommentConfig());
            builder.ApplyConfiguration(new TopicConfig());
            builder.ApplyConfiguration(new LikeConfig());
            builder.ApplyConfiguration(new PostConfig());
            base.OnModelCreating(builder);
        }
    }
}
