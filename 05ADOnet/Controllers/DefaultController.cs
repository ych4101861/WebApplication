using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;



namespace _05ADOnet.Controllers
{
    public class DefaultController : Controller
    {

        SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        public DataTable querySql(string sql)
        {
            SqlDataAdapter adp = new SqlDataAdapter(sql, Conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            return ds.Tables[0];
        }

        // GET: Default
        public string ShowEmployee()
        {
            
            string sql = "select 員工編號,姓名,稱呼,職稱 from 員工";
            DataTable dt = querySql(sql);
            string str = "";

            //寫法一
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                str += "員工編號:" + dt.Rows[i]["員工編號"] + "<br>";
                str += "姓名:" + dt.Rows[i]["姓名"] + "<br>";
                str += "稱呼:" + dt.Rows[i]["稱呼"] + "<br>";
                str += "職稱:" + dt.Rows[i]["職稱"] + "<hr>";
            }
            ////寫法二
            //foreach (DataRow row in dt.Rows)
            //{
            //    str += "員工編號:" + row["員工編號"] + "<br>";
            //    str += "姓名:" + row["姓名"] + "<br>";
            //    str += "稱呼:" + row["稱呼"] + "<br>";
            //    str += "職稱:" + row["職稱"] + "<hr>";
            //}

            return str;
        }

        public string ShowProuduct()
        {
            
            string sql = "select 產品,單價,庫存量 from 產品資料 where 單價>30 order by 單價,庫存量 desc";
          
            DataTable dt = querySql(sql);
            string str = "";

            ////寫法一
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    str += "產品:" + dt.Rows[i]["產品"] + "<br>";
            //    str += "單價:" + dt.Rows[i]["單價"] + "<br>";
            //    str += "庫存量:" + dt.Rows[i]["庫存量"] + "<hr>";
                
            //}

            ////寫法二
            foreach (DataRow row in dt.Rows)
            {
                str += "產品:" + row["產品"] + "<br>";
                str += "單價:" + row["單價"] + "<br>";
                str += "庫存量:" + row["庫存量"] + "<hr>";
            }

            return str;
        }

        public string ShowCustomerByAddress(string keyword)
        {
            
            string sql = "select 公司名稱,連絡人,連絡人職稱,地址 from　客戶 where 地址 like @keyword";//sql不跟變數寫在一起
            SqlDataAdapter adp = new SqlDataAdapter(sql, Conn);
            adp.SelectCommand.Parameters.AddWithValue("@keyword", "%" + keyword + "%");


            DataSet ds = new DataSet();
            adp.Fill(ds);

            DataTable dt = ds.Tables[0];
            string str = "";

            //寫法一
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                str += "公司名稱:" + dt.Rows[i]["公司名稱"] + "<br>";
                str += "連絡人:" + dt.Rows[i]["連絡人"] + "<br>";
                str += "連絡人職稱:" + dt.Rows[i]["連絡人職稱"] + "<br>";
                str += "地址:" + dt.Rows[i]["地址"] + "<hr>";

            }

            //////寫法二
            //foreach (DataRow row in dt.Rows)
            //{
            //    str += "公司名稱:" + row["公司名稱"] + "<br>";
            //    str += "連絡人:" + row["連絡人"] + "<br>";
            //    str += "連絡人職稱:" + row["連絡人職稱"] + "<br>";
            //    str += "地址:" + row["地址"] + "<hr>";
            //}

            return str;
        }
    }
}