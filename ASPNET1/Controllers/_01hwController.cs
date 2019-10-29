using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPnet.Controllers
{
    public class _01hwController : Controller
    {
        // GET: _01hw
        public void NO1()
        {
            int a = 42;
            float b = 2.5f;
            float result = 0;
            result = a + b;
            Response.Write("a + b=" + result);
            Response.Write("<hr>");

            result = a - b;
            Response.Write("a - b=" + result);
            Response.Write("<hr>");

            result = a * b;
            Response.Write("a * b=" + result);
            Response.Write("<hr>");

            result = a / b;
            Response.Write("a / b=" + result);
            Response.Write("<hr>");

            result = a % b;
            Response.Write("a % b=" + result);
            Response.Write("<hr>");
        }
        
        public double NO2(string tempCelsius)
        {
            double celsius = Double.Parse(tempCelsius);
            return (celsius * 9 / 5) + 32;
        }
        public void NO3(int X, int Y) {
            X = X + Y;
            Y = X - Y;
            X = X - Y;
            Response.Write("交換後X=" + X + ",Y=" + Y);
        }
        public string NO4(int score)
        {
            int result = score / 10;
            string level="";
            switch (result)
            {
                case 10:
                case 9:
                    level="優等";
                    break;
                case 8:
                    level ="甲等";
                    break;
                case 7:
                    level ="乙等";
                    break;
                case 6:
                    level ="丙等";
                    break;
                default:
                    level ="丁等";
                    break;
            }
             return level;
        }
        public void NO5(int m)
        {
            for (int i = 1; i <= m; i++)
            { if (i % 5 != 0)
                    Response.Write(i + "");
             }
        }
        public void NO6(int n)
        {
            decimal sum = 0;
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 != 0)
                    sum += i;
                    }
            Response.Write(sum);
        }
        public void NO7(int n)
        {
            int i = 1;
            string r="";
            while (i <= n) {
                r+= "*";
                i++;
                Response.Write(r+"<br>"); 
            }
        }
        public void NO8()
        {
            for (int i = 1; i <= 9; i++) {
                for (int j = 1; j <= 9; j++)
                Response.Write(i+"*"+j+"="+i*j+ "<br>");
                Response.Write("<br>");
            }
            Response.Write( "<br>");
        }
       
    }
    }
