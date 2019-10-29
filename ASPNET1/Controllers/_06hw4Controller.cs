using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNET1.Controllers
{
    
    public class _06hw4Controller : Controller
    {
        
        // GET: _06hw4
        const string eng = "ABCDEFGHJKLMNPQRSTUVXYWZIO";
        public void CheckId(string id)
        {
            if (!IdLength(ref id))
                Response.Write("格式有誤");
            else if (!AlphabetCheck(ref id))
                Response.Write("格式有誤");
            else if (!GenderCheck(ref id))
                Response.Write("格式有誤");
            else if (!NumCheck(ref id))
                Response.Write("格式有誤");
            else if (!LegalityCheck(ref id))
                Response.Write("此身分證字號不正確");
            else
                Response.Write("這是合法的身分證字號");
        }

        //判斷id長度
        public bool IdLength(ref string id)
        {
            if (id.Length == 10)
                return true;
            return false;
        }

        //判斷第一碼大寫英文字母
        public bool AlphabetCheck(ref string id)
        {
            string[] eng = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "U", "V", "X", "Y", "W", "Z", "I", "O" };
            string t = id.Substring(0, 1);
            for (int i = 0; i < eng.Length; i++)
            {
                if (eng[i] == t)
                {
                    return true;
                }
            }
            return false;
        }

        //判斷身分證字號第二碼為數字1或2
        public bool GenderCheck(ref string id)
        {
            string gender = id.Substring(1, 1);

            if (gender == "1" || gender == "2")
                return true;
            return false;
        }

        //判斷身分證字號後8碼為0~9的數字
        public bool NumCheck(ref string id)
        {
            try
            {
                for (int i = 2; i < 10; i++)
                {
                    Convert.ToInt16(id.Substring(i, 1));
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        //判斷該身分證字號是否合法
        public bool LegalityCheck(ref string id)
        {
            string t = id.Substring(0, 1);
            int intEng = eng.IndexOf(t) + 10;

            int n1 = intEng / 10;
            int n2 = intEng % 10;

            int[] x = new int[9];
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = Convert.ToInt16(id.Substring(i + 1, 1));
            }

            int sum = n1 + n2 * 9 + x[0] * 8 + x[1] * 7 + x[2] * 6 + x[3] * 5 + x[4] * 4 + x[5] * 3 + x[6] * 2 + x[7] + x[8];

            if (sum % 10 == 0)
                return true;
            return false;
        }
    }
}
