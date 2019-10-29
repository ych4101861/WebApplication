using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _02TODO.Models;

namespace _02TODO.Controllers
{
    public class TODO1Controller : Controller
    {
        private TODOContext db = new TODOContext();

        // GET: TODO1
        public ActionResult Index()
        {
            return View(db.TODO1.ToList());
        }

        // GET: TODO1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TODO1 tODO1 = db.TODO1.Find(id);
            if (tODO1 == null)
            {
                return HttpNotFound();
            }
            return View(tODO1);
        }

        // GET: TODO1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TODO1/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,title,Image,Date")] TODO1 tODO1)
        {
            if (ModelState.IsValid)
            {
                db.TODO1.Add(tODO1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tODO1);
        }

        // GET: TODO1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TODO1 tODO1 = db.TODO1.Find(id);
            if (tODO1 == null)
            {
                return HttpNotFound();
            }
            return View(tODO1);
        }

        // POST: TODO1/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,title,Image,Date")] TODO1 tODO1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tODO1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tODO1);
        }

        // GET: TODO1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TODO1 tODO1 = db.TODO1.Find(id);
            if (tODO1 == null)
            {
                return HttpNotFound();
            }
            return View(tODO1);
        }

        // POST: TODO1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TODO1 tODO1 = db.TODO1.Find(id);
            db.TODO1.Remove(tODO1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
