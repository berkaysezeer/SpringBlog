using SpringBlog.Models;
using SpringBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using X.PagedList;

namespace SpringBlog.Controllers
{
    public class HomeController : BaseController
    {
        [Route("", Order = 2, Name = "HomeDefault")]
        [Route("c/{cid}/{slug}", Order = 1)]
        public ActionResult Index(string q, int? cid, string slug, int page = 1) //aramadan gelen string q, tiklanan kategori int? cid
        {
            var pageSize = 10; //sayfada bukunacak post sayisi

            IQueryable<Post> posts = db.Posts; //tum postlar gelir
            Category category = null;

            if (q != null) //eger girilen kelime bos degilse
            {
                posts = posts.Where(x => x.Category.CategoryName.Contains(q) //bu kelimeyi iceren postlari at
                || x.Title.Contains(q)
                );
            }

            if (cid != null && q == null) //kategoriye gore filtreleme
            {
                category = db.Categories.Find(cid);
                if (category == null) return HttpNotFound();

                posts = posts.Where(x => x.CategoryId == cid);
            }

            var vm = new HomeIndexViewModel
            {
                Posts = posts.OrderByDescending(x => x.CreationTime).ToPagedList(page, pageSize),
                Category = category,
                SearchTerm = q,
                CategoryId = cid
            };
            return View(vm);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CategoriesPartial()
        {
            var cats = db.Categories.OrderBy(x => x.CategoryName).ToList();
            ; return PartialView("_CategoriesPartial", cats);
        }
    }
}