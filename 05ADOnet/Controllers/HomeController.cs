using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _05ADOnet.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);
        SqlCommand Cmd = new SqlCommand();
        private void executeSql(string sql)
        {
            Cmd.CommandText = sql;
            Cmd.Connection = Conn;

            Conn.Open();
            Cmd.ExecuteNonQuery();
            Conn.Close();
        }

        private  DataTable querysql(string sql)
        {
            SqlDataAdapter adp = new SqlDataAdapter(sql, Conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            return ds.Tables[0];
        }
        // GET: Hone
        public ActionResult Index()
        {
            DataTable dt = querysql("select * from tStudent");

            return View(dt);
        }

        public ActionResult Create()
        {
            

            return View();
        }
        [HttpPost]
        public ActionResult Create(string fStuId, string fName, string fEmail, string fScore)
        {
            string sql = "Insert into tStudent values(@fStuId,@fName,@fEmail,@fScore)";
            
            Cmd.Parameters.AddWithValue("@fStuId", fStuId);
            Cmd.Parameters.AddWithValue("@fName", fName);
            Cmd.Parameters.AddWithValue("@fEmail", fEmail);
            Cmd.Parameters.AddWithValue("@fScore", fScore);

            executeSql(sql);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string fStuId)
        {
            string sql = "delete from tStudent where fStuId=@fStuId";
            Cmd.Parameters.AddWithValue("@fStuId", fStuId);
            executeSql(sql);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(string fStuId)
        {
            Cmd.Parameters.AddWithValue("@fStuId", fStuId);
            DataTable dt = querysql("select * from tStudent where fStuId=@fStuId");
            
            return View(dt);
        }
        [HttpPost]
        public ActionResult Edit(string fStuId, string fName, string fEmail, string fScore)
        {
            string sql = "Update tStudent set fName=@fName,=fEmail=@fEmail,fScore=@fScore,fStuId=@fStuId";

            Cmd.Parameters.AddWithValue("@fStuId", fStuId);
            Cmd.Parameters.AddWithValue("@fName", fName);
            Cmd.Parameters.AddWithValue("@fEmail", fEmail);
            Cmd.Parameters.AddWithValue("@fScore", fScore);

            executeSql(sql);
            return RedirectToAction("Index");
        }
    }
}