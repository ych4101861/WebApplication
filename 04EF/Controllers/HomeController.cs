using _04EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _04EF.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string ShowArrayDesc()
        {
            int[] score = {78,77,55,66,22,44,66,88 };
            string show = "";

            //第一種方法
            //Linq查詢運算式
            //var result = from m in score
            //             orderby m descending
            //             select m;

            //第二種方法
            //Linq擴充方法寫法
            var result = score.OrderByDescending(m=>m);

            //第三種方法
            //SQL select
            //select score from table1
            //order by score desc

            show = "遞減排序:";
            foreach (var m in result)
            {
                show += m + ",";
            }
            show += "<br />";
            show += "總和:" + result.Sum();
            return show;
        }

        public string ShowArrayAsc()
        {
            int[] score = { 78, 77, 55, 66, 22, 44, 66, 88 };
            string show = "";

            //第一種方法
            //Linq查詢運算式
            //var result = from m in score
                         //orderby m ascending
                         //select m;

            //第二種方法
            //Linq擴充方法寫法
            var result = score.OrderBy(m => m);

            //第三種方法
            //SQL select
            //select score from table1
            //order by score desc

            show = "遞增排序:";
            foreach (var m in result)
            {
                show += m + ",";
            }
            show += "<br />";
            show += "平均:" + result.Average();
            return show;
        }

        public string LoginMember(string uid,string pwd)
        {
            Member[] member = new Member[]
                {
                    new Member{ UId="tom",Pwd="123",Name="湯姆"},
                    new Member{ UId="JSPER",Pwd="456",Name="加斯柏"},
                    new Member{ UId="MARY",Pwd="789",Name="馬力"}
                };

            //select * from members
            //where Uid=@uid and Pwd=@pwd

            //Linq擴充方法寫法
            //var result = member.Where(m => m.UId == uid && m.Pwd == pwd).FirstOrDefault();

            var result = (from m in member
                          where m.UId == uid && m.Pwd == pwd
                          select m).FirstOrDefault();
            string show = "";

            if (result != null)
            {
                show = result.Name + "歡迎進入系統";
            }
            else
            {
                show = "帳號密碼錯誤";
            }
            return show;
        }

    }
}