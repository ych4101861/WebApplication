using _00MVC_CRUD_Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _00MVC_CRUD_Products.Controllers
{
    public class HomeController : Controller
    {
        //_00MVC_CRUD_Products.Models.dbProductEntities///命名空間
        dbProductEntities db = new dbProductEntities();


        // GET: Home
        public ActionResult Index()
        {
            return View(db.tProduct.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string fId,string fName,decimal fPrice,HttpPostedFileBase fImg)
        {
            //處理圖檔上傳
            string fileName = "";
            if (fImg != null)
            {
                if (fImg.ContentLength > 0)
                {

                    fileName=System.IO.Path.GetFileName(fImg.FileName);//取得檔案的檔名
                    fImg.SaveAs(Server.MapPath("~/images/"+fileName));//江檔案存到images資料夾下
                }
            }
            //處理圖檔上傳end


            tProduct product = new tProduct();
            product.fId = fId;
            product.fName = fName;
            product.fPrice = fPrice;
            product.fImg = fileName;

            db.tProduct.Add(product);
            db.SaveChanges();

            return RedirectToAction("Index");//導向Index的Action方法
        }
      

        public ActionResult Delete(string fId)//fId自取，跟欄位一樣
        {
            var product = db.tProduct.Where(m => m.fId == fId).FirstOrDefault();
            string fileName = product. fImg;
            if (fileName != "")
            {
                System.IO.File.Delete(Server.MapPath("~/images/" + fileName));
            }

            db.tProduct.Remove(product);//從models移除
            db.SaveChanges();//儲存改變後的

            return RedirectToAction("Index");
        }
        public ActionResult Edit(string fId)
        {
            var product = db.tProduct.Where(m => m.fId == fId).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        public ActionResult Create(string fId, string fName, decimal fPrice, HttpPostedFileBase fImg,string oldImg)
        {
            //處理圖檔上傳
            string fileName = "";
            if (fImg != null)
            {
                if (fImg.ContentLength > 0)
                {
                    System.IO.File.Delete(Server.MapPath("~/images/" + oldImg));
                    fileName = System.IO.Path.GetFileName(fImg.FileName);//取得檔案的檔名
                    fImg.SaveAs(Server.MapPath("~/images/" + fileName));//江檔案存到images資料夾下
                }
                else
                {
                    fileName = oldImg;
                }
            }
            //處理圖檔上傳end
            var product = db.tProduct.Where(m => m.fId == fId).FirstOrDefault();

            
            product.fId = fId;
            product.fName = fName;
            product.fPrice = fPrice;
            product.fImg = fileName;

            db.tProduct.Add(product);
            db.SaveChanges();

            return RedirectToAction("Index");//導向Index的Action方法
        }
    }
}