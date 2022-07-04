using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class UserController : Controller
    {
        UserDal context = new UserDal();
        private int res;
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(IFormCollection form)
        {
            User us = new User();
            us.FullName = form["fullname"].ToString();
            us.Emailid = form["emailid"].ToString();
            us.password = form["password"].ToString();
            us.RoleId = 2;
            int res = context.Save(us);
            if(res==1)
            {
                return RedirectToAction("Create");
            }
            return View();
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(IFormCollection form)
        {
            User us = new User();
            us.Emailid = form["emailid"].ToString();
            us.password = form["password"].ToString();
            int res = context.Check(us.Emailid,us.password);
            if(res==1)
            {
                return RedirectToAction("List", "Product");
            }
            else
            {
                ViewBag.Message = "Invalid Emailid and Password";
            }
            return View();
        }

        
    }
}
