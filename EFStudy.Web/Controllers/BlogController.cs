﻿using EFStudy.Web.Core;
using EFStudy.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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
            using (var _context = new EFDbContext())
            {
                blogs = _context.Blogs.AsNoTracking().ToList();
            };
            return View(blogs);
        }
        //public async Task<ActionResult> Index()
        //{
        //    Task allTasks = MultipleAsyncQuery();
        //    await allTasks;
        //    return View(allTasks);
        //}
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
        /// <summary>
        /// 获取单个博客实体 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Get(int? id)
        {
            if (ReferenceEquals(id,null)||id.Value<=0)
            {
                return Content("<script type='text/javascript'>alert('提交参数不正确!');location.href='/'</script>");
            }
            using (var _context=new EFDbContext())
            {
                var blog = await _context.Blogs.FindAsync(id);
                if (ReferenceEquals(blog,null))
                {
                    return Content("<script type='text/javascript'>alert('该博客不存在!');location.href='/'</script>");
                }
                return View("UpInsert", blog);
            }
        }
        /// <summary>
        /// 删除单个博客
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Delete(int? id)
        {
            if (ReferenceEquals(id, null) || id.Value <= 0)
            {
                return Content("<script type='text/javascript'>alert('提交参数不正确!');location.href='/'</script>");
            }
            using (var _context = new EFDbContext())
            {
                var dbBlog = await _context.Blogs.FindAsync(id);
                if (ReferenceEquals(dbBlog, null))
                {
                    return Content("<script type='text/javascript'>alert('该博客不存在!');location.href='/'</script>");
                }
                else
                {
                    _context.Blogs.Remove(dbBlog);
                    var result = _context.SaveChanges();
                    if (result>0)
                    {
                        return View("Index");
                    }
                    return Content("<script type='text/javascript'>alert('删除失败!');location.href='/'</script>");
                }
            }
        }

        public async Task<ActionResult> UpInserts(Blog blog)
        {
            //if (ModelState.IsValid)
            //{
                using (var _context=new EFDbContext())
                {
                    if (blog.Id<=0)
                    {
                        _context.Blogs.Add(blog);
                        blog.CreateTime = DateTime.Now;
                        blog.ModifiedTime = DateTime.Now;
                    }
                    else
                    {
                        var dbBlog = await _context.Blogs.FindAsync(blog.Id);
                        if (ReferenceEquals(blog,null))
                        {
                            return Content("<script type='text/javascript'>alert('提交参数不正确!');location.href='/'</script>");
                        }
                        else
                        {
                            dbBlog.Owner = blog.Owner;
                            dbBlog.Tags = blog.Tags;
                            dbBlog.Url = blog.Url;
                            dbBlog.ModifiedTime = DateTime.Now;
                        }
                    }
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            //}
            //return View("UpInsert");
        }

        //async Task MultipleAsyncQuery()
        //{
        //    using (var efDbContext=new EFDbContext())
        //    {
        //        List<Task> task = new List<Task>
        //        {
        //            efDbContext.Blogs.ToListAsync(),
        //             efDbContext.Blogs.ToListAsync()
        //        };
        //        await Task.WhenAll(task);
        //    }
        //}
    }
}