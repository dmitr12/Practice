using Pract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace Pract.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Article()
        {
            List<Article> articles;
            using(ArticleContext db=new ArticleContext())
            {
                articles = db.Articles.OrderBy(a=>a.Date).ToList();
            }
            ViewBag.Articles = articles;
            return View();
        }

        public ActionResult CreateArticle()
        {
            if (User.Identity.IsAuthenticated)
                return View();
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateArticle(Article model)
        {
            using(ArticleContext db=new ArticleContext())
            {
                db.Articles.Add(new Article { Name = model.Name, Date = model.Date, ImageLink = model.ImageLink, Content = model.Content });
                db.SaveChanges();
            }
            return RedirectToAction("Article", "Home");
        }

        public ActionResult MoreArticleInfo(int id)
        {
            Article article;
            using(ArticleContext db=new ArticleContext())
            {
                article = db.Articles.Where(a => a.Id == id).FirstOrDefault();
            }
            ViewBag.Article = article;
            return View();
        }
    }
}