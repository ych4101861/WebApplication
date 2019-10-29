﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _04EF.Models;


namespace _04EF.Controllers
{
    public class LinqController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();

        public object SqlMethods { get; private set; }

        // GET: Linq
        public string ShowEmployee()
        {
            //Linq擴充方法寫法
            var result = db.員工;

            //Linq查詢運算式寫法
            //var result = from m in db.員工
                         //select m;

            string show = "";
            foreach (var m in result)
            {
                show += "員工編號:"+m.員工編號+"<br />";
                show += "姓名:" + m.姓名 + "<br />";
                show += "職稱:" + m.職稱 + "<hr>";
            }
            return show;
        }

        public string ShowCustomerByAddress(string keyword)
        {
            //Linq擴充方法寫法  //Contains: like '%'+keyword+'%'
            //var result = db.客戶.Where(m=>m.地址.Contains(keyword));

            //StartsWith: like keyword+'%'
            //var result = db.客戶.Where(m => m.地址.StartsWith(keyword));

            //EndsWith: like '%'+keyword
            //var result = db.客戶.Where(m => m.地址.EndsWith(keyword));

            //Linq查詢運算式寫法
            var result = from m in db.客戶
                         where m.地址.Contains(keyword)                         
                         select m;


            string show = "";

            foreach (var m in result)
            {
                show += "公司：" + m.公司名稱 + "<br />";
                show += "姓名：" + m.連絡人 + m.連絡人職稱 + "<br />";
                show += "地址：" + m.地址 + "<hr>";
            }
            return show;
        }

        public string ShowProduct()
        {
            //Linq擴充方法寫法  //Contains: like '%'+keyword+'%'
            //var result = db.產品資料.Where(m=>m.單價>30).OrderBy(m=>m.單價).ThenByDescending(m=>m.庫存量);



            //Linq查詢運算式寫法
            var result = from m in db.產品資料
                         where m.單價 > 30
                         orderby m.單價 ascending, m.庫存量 descending
                         select m;

            string show = "";

            foreach (var m in result)
            {
                show += "公司：" + m.產品 + "<br />";
                show += "姓名：" + m.單價 + "<br />";
                show += "地址：" + m.庫存量 + "<hr>";
            }
            return show;
        }

        public string ShowProductInfo()
        {
            //Linq擴充方法寫法
            var result = db.產品資料;

            //Linq查詢運算式寫法
            //var result = from m in db.產品資料     
            //             select m;

            string show = "";
                      
                show += "平均單價：" + result.Average(m=>m.單價) + "<br />";
                show += "單價總和：" + result.Sum(m=>m.單價) + "<br />";
                show += "產品比數：" + result.Count() + "<hr>";
                show += "最低單價：" + result.Min(m => m.單價) + "<hr>";
                show += "最高單價：" + result.Max(m => m.單價) + "<hr>";
            
            return show;
        }
    }
}
