using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFDI.Core.Data;
using EFDI.DI.Models.Dto;
using EFDI.Service;

namespace EFDI.DI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var users = _userService.GetUsers().ProjectTo<UserDto>().ToList();
            return View(users);
        }
        [HttpGet]
        public ActionResult CreateEditUser(int? id)
        {
            var model=new UserDto();
            if (id.HasValue&&id.Value>0)
            {
                User userEntity = _userService.GetUser(id.Value);
                model = Mapper.Map<User, UserDto>(userEntity);
            }
            return View(model);
        }

        public ActionResult CreateEditUset(UserDto model)
        {
            if (model.ID<=0)
            {
                var userEntity = Mapper.Map<UserDto, User>(model);
                userEntity.IP = Request.UserHostAddress;
                userEntity.CreatedTime=DateTime.Now;
                userEntity.ModifiedTime=DateTime.Now;
                userEntity.UserProfile.CreatedTime=DateTime.Now;
                userEntity.UserProfile.ModifiedTime=DateTime.Now;
                _userService.InsertUser(userEntity);
                if (userEntity.ID>0)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                User userEntity = _userService.GetUser(model.ID);
                Mapper.Map(model, userEntity);
                userEntity.ModifiedTime=DateTime.Now;
                userEntity.IP = Request.UserHostAddress;
                userEntity.UserProfile.ModifiedTime = DateTime.Now;
                if (userEntity.ID>0)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

        public ActionResult DetailUser(int? id)
        {
            var model=new UserDto();
            if (id.HasValue&&id>0)
            {
                var userEnttity = _userService.GetUser(id.Value);
                model = Mapper.Map<UserDto>(userEnttity);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult DeleteUser(int? id)
        {
   
            if (id.HasValue && id > 0)
            {
                var userEnttity = _userService.GetUser(id.Value);
                _userService.DeleteUser(userEnttity);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}