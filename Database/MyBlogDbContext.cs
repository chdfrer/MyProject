using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyBlog.Areas.Blog.Models;
using MyBlog.Areas.Categories.Models;
using MyBlog.Models.Contacts;
using MyBlog.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Database
{
    public class MyBlogDbContext : IdentityDbContext<AppUser>
    {
        public MyBlogDbContext(DbContextOptions<MyBlogDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Remove "AspNet" prefix in tables' name
            foreach(var entityType in builder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }

            //Create Index for Slug column
            builder.Entity<CategoryModel>(entity =>
            {
                entity.HasIndex(c => c.Slug)
                .IsUnique();
            });

            builder.Entity<BlogModel>(entity =>
            {
                entity.HasIndex(b => b.Slug)
                .IsUnique();
            });

            builder.Entity<BlogCategory>(entity =>
            {
                entity.HasKey(bc => new { bc.BlogId, bc.CategoryId });
            });
        }

        public DbSet<ContactModel> Contacts { set; get; }

        public DbSet<CategoryModel> Categories { set; get; }

        public DbSet<BlogModel> Blogs { set; get; }

        public DbSet<BlogCategory> BlogCategory { set; get; }
    }
}
