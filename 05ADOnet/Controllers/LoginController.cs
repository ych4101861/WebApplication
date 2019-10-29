using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;


namespace _05ADOnet.Controllers
{
    public class LoginController : Controller
    {
        
        SqlConnection Conn=new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string id,string pwd)
        {
            string sql = "select * from tStudent where fEmail=@fEmail and fStuId=@fStuId";
            SqlCommand cmd = new SqlCommand(sql,Conn);
            cmd.Parameters.AddWithValue("@fEmail", id);
            cmd.Parameters.AddWithValue("@fStuId", pwd);
            SqlDataReader rd;

            Conn.Open();
            rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                Session["id"] = rd["fStuId"].ToString();

                Conn.Close();
                return RedirectToAction("Index","Home");
            }
           
                Conn.Close();
                ViewBag.LoginErr = "帳號或密碼有誤";
                return View();
  
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index","Home");
        }
    }
}