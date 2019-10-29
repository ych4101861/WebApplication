using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPnet.Controllers
{
    public class _02hwController : Controller
    {
        // GET: _02hw
        public void No1(int n)
        {
            bool result = false;
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0 )
                {
                    result =true;
                    break;
                }  
            }
            if (result)
            {
                Response.Write(n + "不是質數");
            }
            else
            {
                Response.Write(n + "是質數");
            }

        }
        public void No2(int x, int y)
        {
            int k = 0; int xx = x; int yy = y;
            while (xx % yy != 0)
            {
                k = xx % yy;
                xx = yy;
                yy = k;
            }
            Response.Write(x + "與" + y + "的最大公因數:"+yy);
        }

        public void No3(int m)
        {
            int k = 0; int q = 0; int mm = m;int result = 0;
            do
            {
                k = mm % 10;
                result += k;
                q = mm / 10;
                mm = q;
                if (q != 0)
                {
                    result *= 10;
                }
                else
                {
                    break;
                }
            } while (q != 0);

            if (result == m)
                Response.Write(m + "是迴文");
            else
                Response.Write(m + "不是迴文");
        }
        public void Statement3(int x)
        {
            int xx = x;
            int y = 0;
            while (xx > y)
            {
                y = y * 10 + xx % 10;
                xx = xx / 10;
            }

            if (xx == y || xx == y / 10)
                Response.Write(x + "是迴文");
            else
                Response.Write(x + "不是迴文");
        }





    }
 }


















