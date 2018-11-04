using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
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
    }
}