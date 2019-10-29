﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using _02Controller.Models;

namespace _02Controller.Controllers
{
    public class ComplexBindController : Controller
    {
        // GET: ComplexBind
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Product p)
        {
            ViewBag.PId = p.PId;
            ViewBag.PName = p.PName;
            ViewBag.Price = p.Price;
            return View();
        }
    }
}