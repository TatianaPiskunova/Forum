using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics;
using Экзамен.Models;


namespace Экзамен.Controllers
{
    public class HomeController : Controller
    {
        ForumContext db;
        private readonly ILogger<HomeController> _logger;
        IStringLocalizer<HomeController> localizer;

        public HomeController(ILogger<HomeController> logger, ForumContext contextForum, IStringLocalizer<HomeController> localizer)
        {
            _logger = logger;
             db = contextForum;
             this.localizer = localizer;
        }

        public IActionResult Index()
        {
            var tmpList=new List<TopicPost>();
      
            foreach (Topic topic in db.Topics)
            {
                var tmpPosts = db.Posts.Where(p => p.TopicId == topic.Id).ToList();
                var tmpModel = new TopicPost
                {
                    Id= topic.Id,
                    TitleTopic = topic.TitleTopic,
                    Posts = tmpPosts,
                    
                };
                tmpList.Add(tmpModel);
            
            }

            return View(tmpList);
        }
        [HttpGet]
        public IActionResult AddPost(int id)
        {
        
            ViewBag.TopicId = id;
            ViewBag.DateTime = DateTime.Now;
            return View();
        }
        [HttpPost]
        public IActionResult AddPost(Post post)
        {
            
            db.Posts.Add(post);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult AddTopic()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTopic(Topic topic)
        {

            db.Topics.Add(topic);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}