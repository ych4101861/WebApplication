using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNET1.Controllers
{
    public class _05hw3Controller : Controller
    {
        // GET: _05hw3
        public void PlayGame()
        {
            string[] poker = new string[52];
            Poker(ref poker);
            Shuffle(ref poker);
            Licensing(ref poker);

        }

        //創一副牌
        public void Poker(ref string[] poker)
        {
           
            for (int i = 0; i < poker.Length; i++) {
                poker[i] = (i + 1).ToString();
            }
        }

        //洗牌
        public void Shuffle(ref string[] poker)
        {
            Random r = new Random();
            int t = 0;
            string tmp = "";
            for (int i = 0; i < poker.Length; i++) {
                t = r.Next(52);
                tmp = poker[i];
                poker[i] = poker[t];
                poker[t] = tmp;
                //Response.Write(poker[i]);
            }
            //for (int i = 0; i < poker.Length; i++)
            //    Response.Write("<img src='../poker_img/" + poker[i] + ".gif' />");
        }

        //發牌
        public void Licensing(ref string[] poker)
        {
            string p1 = "", p2 = "", p3 = "", p4= "";
            string result = "";
            for (int i = 0; i < poker.Length; i++)
            {
                result = "<img src='../poker_img/" + poker[i] + ".gif' />";
                switch (i % 4)
                {
                    case 0:
                        p1 += result;
                        break;
                    case 1:
                        p2 += result;
                        break;
                    case 2:
                        p3 += result;
                        break;
                    case 3:
                        p4 += result;
                        break;
                }
            }
            Response.Write("<h2>player1:" + p1 + "</h2><h2>player2:" + p2 + "</h2><h2>player3:" + p3 + "</h2><h2>player4:" + p4+ "</h2>");
        }     
    }
}