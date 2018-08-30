using EFStudy.Web.Core;
using EFStudy.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFStudy.Web.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        /// <summary>
        /// 获取博客列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var blogs = new List<Blog>();
            using (var _context=new EFDbContext())
            {
                blogs = _context.Blogs.AsNoTracking().ToList();
            };
            return View(blogs);
        }

        public ActionResult Search(string Owner)
        {
            var blogs = new List<Blog>();
            using (var _context=new EFDbContext())
            {
                blogs = _context.Blogs.ToList();
                blogs.All(b =>
                {
                    b.Owner = Transfer(b._Owner);
                    return true;
                });
            };
            if (!string.IsNullOrEmpty(Owner))
            {
                blogs = blogs.Where(d => d.Owner.Name == Owner || d.Owner.EnglishName == Owner).ToList();
             
            }
            return View("Index", blogs);
        }
        public ActionResult UpInsert()
        {
            return View();
        }
        Person Transfer(string p)
        {
            return JsonConvert.DeserializeObject<Person>(p);
        }
    }
}