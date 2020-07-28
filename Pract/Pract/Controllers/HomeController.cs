using PagedList;
using Pract.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public ActionResult Article(int? page)
        {
            List<Article> articles;
            using(ArticleContext db=new ArticleContext())
            {
                articles = db.Articles.OrderBy(a=>a.Date).ToList();
            }
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            ViewBag.Articles=articles.ToPagedList(pageNumber, pageSize);
            return View(articles.ToPagedList(pageNumber, pageSize));
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
            if (ModelState.IsValid)
            {
                using (ArticleContext db = new ArticleContext())
                {
                    db.Articles.Add(new Article { Name = model.Name, Date = DateTime.Now, ImageLink = model.ImageLink, Content = model.Content, FirstStr = model.FirstStr });
                    db.SaveChanges();
                }
                return RedirectToAction("Article", "Home");
            }
            return View();
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

        public ActionResult DeleteArticle(int id)
        {
            Article article;
            using(ArticleContext db=new ArticleContext())
            {
                article = db.Articles.Where(a => a.Id == id).FirstOrDefault();
            }
            ViewBag.Article = article;
            return View();
        }

        [HttpPost, ActionName("DeleteArticle")]
        public ActionResult ConfirmedDeleteArticle(int id)
        {
            Article article;
            using(ArticleContext db=new ArticleContext())
            {
                article = db.Articles.Find(id);
                if (article == null)
                    return HttpNotFound();
                db.Articles.Remove(article);
                db.SaveChanges();
                return RedirectToAction("Article");
            }
        }

        public ActionResult ChangeArticle(int id)
        {
            Article article;
            using (ArticleContext db = new ArticleContext())
            {
                article = db.Articles.Where(a => a.Id == id).FirstOrDefault();
            }
            return View(article);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChangeArticle(Article article)
        {
            if (ModelState.IsValid)
            {
                using(ArticleContext db=new ArticleContext())
                {
                    db.Entry(article).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Article", "Home");
            }
            return View(article);
        }
    }
}