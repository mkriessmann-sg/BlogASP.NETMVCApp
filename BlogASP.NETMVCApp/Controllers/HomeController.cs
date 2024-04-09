using BlogASP.NETMVCApp.Data;
using BlogASP.NETMVCApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogASP.NETMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly BlogPostsDbContext _blogPostsDbContext;


        public HomeController(ILogger<HomeController> logger, BlogPostsDbContext context)
        {
            _logger = logger;
            _blogPostsDbContext = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction("BlogPosts");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult BlogPosts()
        {
            return View();
        }
        public IActionResult CreateEditPosts()
        {

            return View();
        }
        public IActionResult EditBlogPost(int id)
        {
            var postInDB = _blogPostsDbContext.BlogPosts.SingleOrDefault(BlogPost => BlogPost.Id == id);

            return View(postInDB);
        }
        public IActionResult DeleteBlogPost(int id)
        {
            var postInDB = _blogPostsDbContext.BlogPosts.SingleOrDefault(BlogPost => BlogPost.Id == id);
        _blogPostsDbContext.BlogPosts.Remove(postInDB);
            _blogPostsDbContext.SaveChanges();
            return RedirectToAction("BlogPosts");
        }

        public IActionResult CreateEditPostForm(BlogPost blogPost)
        {
            if (blogPost.Content != null || blogPost.Title != null)
            {

            
            // look for first free index and override the index with that data, add a date and thens save to the database
            int maxIdInUse = _blogPostsDbContext.BlogPosts.Any() ? _blogPostsDbContext.BlogPosts.Max(p => p.Id) : 0;
            bool _IdSet = false;
            // Check for the first gap in the sequence of IDs
            for (int i = 1; i <= maxIdInUse + 1; i++)
            {
                if (!_blogPostsDbContext.BlogPosts.Any(p => p.Id == i))
                {
                    blogPost.Id = i;
                    _IdSet = true;
                }
            }
            if (!_IdSet) { blogPost.Id = maxIdInUse + 1; };

            blogPost.PostDate = DateOnly.FromDateTime(DateTime.Today);

            _blogPostsDbContext.Add(blogPost);
            _blogPostsDbContext.SaveChanges();
            }


            return RedirectToAction("BlogPosts");
        }
        public IActionResult EditPostForm(BlogPost blogPost)
        {
            if (blogPost.Content == null || blogPost.Title == null)
            {
                var blogPostToUpdate = _blogPostsDbContext.BlogPosts.FirstOrDefault(p => p.Id == blogPost.Id);

                blogPostToUpdate.Title = blogPost.Title;
                blogPostToUpdate.Content = blogPost.Content;
                _blogPostsDbContext.Update(blogPostToUpdate);
                _blogPostsDbContext.SaveChanges();

            }
            return RedirectToAction("BlogPosts");
            
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
