using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02Controller.Controllers
{
    public class HomeController : Controller
    {
        public string ShowAry()
        {
            int[] score = { 77, 88, 30, 45, 68 };
            string show = "";
            int sum = 0;
            foreach (var m in score)
            {
                show += m + ",";
                sum += m;
            }
            show += "<hr>";
            show += "總和:" + sum;
            return show;
        }
        public string ShowImages()
        {
          
            string show = "";

            for (int i= 1;i<=8; i++)
            {
                show += "<img src='../images/"+i+".jpg' width='200' />";
            }
            
            return show;
        }
        public string ShowImagesIndex(int index)
        {

            string[] name = { "櫻桃鴨", "鴨油高麗菜", "鴨油麻婆豆腐", "櫻桃鴨握壽司", "片皮鴨捲三星蔥", "三杯鴨", "櫻桃鴨片肉", "慢火白菜燉鴨湯" };
            string show = string.Format("<p align='center'><img src ='../images/{0}.jpg'/><br>{1}</p>",index,name[index-1]);
            return show;
        }
        public string ShowSortAry()
        {
            int[] score = { 77, 88, 30, 45, 68 };
            score = MySort(score);
            string show = "";            
            foreach (var m in score)
            {
                show += m + ",";                
            }            
            return show;
        }
        int[] MySort(int[] arrScore)
        {
            int tmp = 0;
            for (int i = arrScore.Length - 1;i>=0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arrScore[j] >arrScore[j + 1])
                    {
                        tmp = arrScore[j];
                        arrScore[j] = arrScore[j + 1];
                        arrScore[j + 1] = tmp;

                    }
                }
            }

           return arrScore;
        }
        public string ShowSortAry2()
        {
            int[] score = { 77, 88, 30, 45, 68 };

            //linq
            var s = from m in score
                    orderby m descending
                    select m;



            string show = "";
            foreach (var m in s)
            {
                show += m + ",";
            }
            return show;
        }
    }
}