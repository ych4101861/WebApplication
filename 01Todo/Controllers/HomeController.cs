using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using _01Todo.Models;

namespace _01Todo.Controllers
{
    public class HomeController : Controller
    {
        TodoContext db = new TodoContext();

        // GET: Home
        public ActionResult Index()
        {
            
            var todoes = db.ToDoes.OrderBy(m=>m.Date).ToList();
            //跟上面一行一樣，語法不一樣
            //linq語法:不是資料庫專用語法
            //var todoes2 = from t in db.ToDoes
            //             orderby t.Date
            //             select t; 


            return View(todoes);
            //return View(todoes2.ToList);
        }

        //沒標的都是用get
        //回應空表單
        public ActionResult Create()
        {
            return View();
        }
        //存資料
        [HttpPost]
        public ActionResult Create(string Title,string Image,DateTime Date)
        {
            ToDo todo = new ToDo();
            //ID不用寫，自動產生號碼
            todo.Title = Title ;
            todo.Image = Image;
            todo.Date = Date;

            
            db.ToDoes.Add(todo);
            db.SaveChanges();

            //ViewBag是動態型別
            ViewBag.Title2 = Title;
            ViewBag.Image = Image;
            ViewBag.Date = Date;
            return View();
            //return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var todo =db.ToDoes.Where(m => m.ID == id).FirstOrDefault();
            //意思同上
            //var todo2 = from t in db.ToDoes
            //            where t.ID == id
            //            select t;

            db.ToDoes.Remove(todo);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var todo = db.ToDoes.Where(m => m.ID == id).FirstOrDefault();//抓資料
            return View(todo);
        }
        [HttpPost]
        public ActionResult  Edit(int ID,string Title, string Image, DateTime Date)
        {
            var todo = db.ToDoes.Where(m => m.ID == ID).FirstOrDefault();
            todo.Title = Title;
            todo.Image = Image;
            todo.Date = Date;

            db.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}