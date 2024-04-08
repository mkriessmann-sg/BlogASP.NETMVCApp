using BlogASP.NETMVCApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlogASP.NETMVCApp.Data
{
    public class BlogPostsDbContext : DbContext

    {
        public BlogPostsDbContext(DbContextOptions<BlogPostsDbContext> options) : base(options)
        {

        }


        public DbSet<BlogPost> BlogPosts { get; set; }


    //    public string DbPath { get; }

    //    public BlogPostsDbContext()
    //    {
    //        var folder = Environment.SpecialFolder.LocalApplicationData;
    //        var path = Environment.GetFolderPath(folder);
    //        DbPath = Path.Join(path, "product.db");
    //    }


    //    protected override void OnConfiguring(DbContextOptionsBuilder options)
    //=> options.UseSqlite($"Data Source={DbPath}");
    }
}

