using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02Controller.Controllers
{
    public class MultiFileUploadController : Controller
    {
        // GET: MultiFileUpload
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase[] photo)
        {
            string fileName = "";
            for (int i= 0;i < photo.Length;i++)
            {
                HttpPostedFileBase f = photo[i];
                if (f != null)
                {
                    if (f.ContentLength > 0)
                    { 
                    //fileName = f.FileName;
                    //fileName = Path.GetFileName(fileName);
                    fileName = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace("　", "").Replace("上午", "").Replace("下午", "") + (i + 1).ToString() + ".jpg";
                    f.SaveAs(Server.MapPath("~/Photos/" + fileName));
                    }
                }
            }
            
            return RedirectToAction("ShowPhotos");
        }
        public string ShowPhotos()
        {
            string show = "";
            DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/Photos"));
            FileInfo[] fInfo = dir.GetFiles();
            foreach (FileInfo result in fInfo)
            {
                show += "<a href='../Photos/" + result.Name + "'><img src='../Photos/" + result.Name + "' width='100' height='90' /></a>";
            }
            show += "<p><a href='Create'>返回</a></p>";
            return show;
        }
    }
}