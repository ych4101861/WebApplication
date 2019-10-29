using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _06ViewModel.Models;

using System.Data.Entity;

namespace _06ViewModel.Controllers
{
    public class HomeController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        // GET: Home
        public ActionResult Index()
        {
            //Linq
            //1.資料庫沒關聯時
            var aa = from b in db.職稱
                     join c in db.員工
                     on b.職稱代碼 equals c.職稱
                     select new { c.員工編號, c.姓名, b.職稱1, c.出生日期 };
            return View(db.員工.ToList());

            //2.在資料庫中已有關聯時
            //var aa = from b in db.職稱
            //         from c in db.員工
            //         select new { c.員工編號, c.姓名, b.職稱1, c.出生日期 };
            //return View(aa.ToList());

            //3.在資料庫中已有關聯時
            //var aa = db.員工;
            //return View(aa.ToList());

            //4.資料庫有關連時
            //var bb = db.員工.Include(m => m.職稱1);
            //var cc = db.員工.Join(db.職稱, 員 => 員.職稱, 職 => 職.職稱代碼, (員, 職) => 員.職稱);
            //return View(bb.ToList());

            //5.
            //var aa = from b in db.職稱
            //         join c in db.員工
            //         on b.職稱代碼 equals c.職稱
            //         select new { c.員工編號, c.姓名, b.職稱1, c.出生日期 };
            //ViewBag.aa = aa.ToList();
            //return View(db.員工.ToList());



        }

        public ActionResult Create()
        {
            //ViewBag.職稱 =db.職稱.ToList();

            ViewBag.職稱 = new SelectList(db.職稱,"職稱代碼","職稱1");
            return View();
        }
        [HttpPost]
        public ActionResult Create(員工 員工)
        {
            db.員工.Add(員工);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}