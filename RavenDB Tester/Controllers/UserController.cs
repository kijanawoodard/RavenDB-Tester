﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RavenDB_Tester.Models;

namespace RavenDB_Tester.Controllers
{
    public class UserController : RavenController
    {
        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(UserInfo user)
        {
            RavenSession.Store(user);
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var users = RavenSession.Query<UserInfo>().ToList<UserInfo>();
            return View(users);
        }

    }
}
