using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNET1.Controllers
{
    public class _01StatementrController : Controller
    {
        // GET: _01Var
        public string Index()
        {
            //字串
            string w = "Hello World";
            w = "123456789";
            return w;
        }
        public string boolIndex(bool gender)
        {
            //布林
            bool w = gender;
            if (w)
                return "男生";

            return "女生";
        }
        public string stringIndex(string name, bool gender)
        {
            //字串
            string g = "";
            if (gender)
                g = "男";
            else
                g = "女";


            return "<h1>" + name + "您好!!您的性別是" + g + "生!!</h1>";
        }

        public void numberIndex()
        {
            //數值
            byte a = 123;  //0~255整數值(8位元正整數)
            sbyte b = 127; //-128~+127含正負數的8位元整數
            short c = 123; //含正負數的16位元整數(-32768~+32767)
            int d = 234;  //含正負數的32位元整數(-2147483648~+2147483647)
            long e = 453256; //含正負數的64位元整數

            ///////////////////////////////////////////
            ushort f = 123;// 0~65535整數值(16位元整數)
            uint g = 123;// (32位元正整數)
            ulong h = 123;// 整數值(64位元正整數)

            ////////////////////////////
            float i = 123.23f; //單精準度浮點數
            double j = 123.4569877788; //雙精準度浮點數
        }

    }
}