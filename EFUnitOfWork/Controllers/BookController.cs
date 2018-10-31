using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EF.Core.Common;
using EF.Core.Helper;
using EF.Core.Model;
using EF.Data;
using EFUnitOfWork.Models.Dto;

namespace EFUnitOfWork.Controllers
{
    public class BookController : Controller
    {
        private static object _lock=new object();
        private UnitOfWork unitOfWork=new UnitOfWork();

        private Repository<Book> bookRepository;

        public BookController()
        {
            bookRepository = unitOfWork.Repository<Book>();
        }
        // GET: Book
        public ActionResult Index()
        {
            var books = bookRepository.Table.ProjectTo<BookDTO>().ToList();
            return View(books);
        }

        public ActionResult CreateEditBook(int? id)
        {
            var bookDto=new BookDTO();
            if (id.HasValue)
            {
                var entity = bookRepository.GetById(id.Value);
                bookDto = Mapper.Map<Book, BookDTO>(entity);
            }

            return View(bookDto);
        }
        [HttpPost]
        public ActionResult CreateEditBook(BookDTO bookDTO)
        {
            if (bookDTO.ID==0)
            {
                var model = Mapper.Map<BookDTO, Book>(bookDTO);
                model.ModifiedTime=DateTime.Now;
                model.CreatedTime=DateTime.Now;
                model.Url = string.Empty;
                model.IP = Request.UserHostAddress;

                bookRepository.Insert(model);
                unitOfWork.Commit();

            }
            else
            {
                var editModel = bookRepository.GetById(bookDTO.ID);
                Mapper.Map(editModel, bookDTO);
                bookRepository.Update(editModel);
                unitOfWork.Commit();
            }

            if (bookDTO.ID>0)
            {
                return View("Upload", bookDTO);
            }

            return RedirectToAction("Index");
        }

        [HttpPost,ActionName("Upload")]
        public ActionResult Upload(Int64 id)
        {
            if (Request.Files.Count<=0)
            {
                return Json(new {status = false, msg = "请选择要上传的书籍"});
            }
            HandleUploadFiles(Request.Files,id);
            return Json(new { status = true});
        }

        public void HandleUploadFiles(HttpFileCollectionBase files, Int64 id)
        {
            foreach (string file in Request.Files)
            {
                var fileDataContent = Request.Files[file];
                var stream = fileDataContent.InputStream;
                var fileName = Path.GetFileName(fileDataContent.FileName);
                var uploadPath = Server.MapPath("~/App_Data/uploads");
                if (!FileHelper.ExistDirectory(uploadPath))
                {
                    FileHelper.CreateDirectory(uploadPath);
                }

                var path = Path.Combine(uploadPath, fileName);

                PollyHelper.WaitAndRetry<IOException>(() =>
                {
                    if (FileHelper.Exist(path))
                    {
                        FileHelper.Delete(path);
                    }

                    using (var fileStream=System.IO.File.Create(path))
                    {
                        stream.CopyTo(fileStream);
                    }

                    var ut = new Utils();
                    var storeFileName = string.Empty;
                    var result = false;
                    ut.MergeFile(path, out result, out storeFileName);
                    if (result)
                    {
                        var model = bookRepository.GetById(id);
                        model.Url = storeFileName;
                        bookRepository.Update(model);
                        unitOfWork.Commit();
                    }
                });
            }
        }

        public ActionResult Download(Int64? id)
        {
            if (!id.HasValue)
            {
                return View("Index");
            }

            var book = bookRepository.GetById(id.Value);
            if (ReferenceEquals(book,null))
            {
                return RedirectToAction("Index");
            }

            var fileName = book.Url;
            if (string.IsNullOrEmpty(fileName))
            {
                return RedirectToAction("Index");
            }

            var uploadPath = Server.MapPath("~/App_Data/uploads");
            var fullPath = uploadPath + Path.DirectorySeparatorChar + fileName;
            if (!FileHelper.Exist(fullPath))
            {
                return Content("<script type='text/javaScript'>alert('未上传或已删除');location.href='/';</script>");
            }

            return File(new FileStream(fullPath, FileMode.Open, FileAccess.Read), "text/plain", fileName);
        }

        public ActionResult DeleteBook(int id)
        {
            var entity = bookRepository.GetById(id);
            if (ReferenceEquals(entity,null))
            {
                return RedirectToAction("Index");
            }

            var model = Mapper.Map<Book, BookDTO>(entity);
            return View(model);
        }

        public ActionResult ConfirmDeleteBook(int id)
        {
            var model = bookRepository.GetById(id);
            bookRepository.Delete(model);
            unitOfWork.Commit();
            return RedirectToAction("Index");
        }

        public ActionResult DetailBook(int id)
        {
            var model = bookRepository.GetById(id);
            var bookDTO = Mapper.Map<Book, BookDTO>(model);
            return View(bookDTO);
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}