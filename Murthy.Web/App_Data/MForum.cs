using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Murthy.Web
{
    public class MForum
    {
        public static SqlConnection MForumConnection()
        {
            return new SqlConnection("Data Source=.\\SQLEXPRESS; AttachDbFilename= F:\\programs\\dotnetLessonDesign\\MForum\\Murthy.Web\\App_Data\\MForum.mdf;" +
                "Integrated Security=TRUE; User Instance=TRUE");
        }
        
        public static DataTable ExecSel(String sql)
        {
            //建立连接
            SqlConnection con = MForum.MForumConnection();
            con.Open();

            //查询命令
            SqlCommand com = new SqlCommand(sql, con);

            //建立适配器
            SqlDataAdapter oda = new SqlDataAdapter();

            //建立dataset
            DataSet ds = new DataSet();
            oda.SelectCommand = com;

            //传递查询结果
            oda.Fill(ds);
            con.Close();
            return ds.Tables[0];
        }
        public static int ExecSql(String sql)
        {
            int affectRow = 0;
            SqlConnection con = MForum.MForumConnection();
            con.Open();
            try
            {
                SqlCommand com = new SqlCommand(sql, con);
                affectRow = com.ExecuteNonQuery();
                
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            con.Close();
            return affectRow;
        }

        public static Boolean IFSqlExist(string sql)
        {
            Boolean result = false;
            SqlConnection con = MForum.MForumConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand(sql, con);
            object res = cmd.ExecuteScalar();
            if (res != null)
            {
                result = true;
            }

            con.Close();
            return result;
        }

        public static string SqlOneResult(string sql)
        {
            string result = null;

            SqlConnection con = MForum.MForumConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand(sql, con);
            object res = cmd.ExecuteScalar();
            if (res != null)
            {
                result = res.ToString();
            }

            con.Close();
            return result;
        }

        //public static SqlDataReader SqlRecResult(string sql)
        //{
        //    SqlDataReader result = null;
        //    SqlConnection con = MForum.MForumConnection();
        //    con.Open();

        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    result = cmd.ExecuteReader();
        //    return result;
        //}

        /**
         * 函数名:SqlRecResult
         * 输入: sql语句
         * 输出: 结果集为二维字符串
         * */
        public static List<string[]> SqlArray(string sql)
        {
            SqlConnection con = MForum.MForumConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();

            List<string[]> res = new List<string[]>();
            try
            {
                while (reader.Read())
                {
                    string[] str = new string[reader.FieldCount + 1];
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        str[i] = reader.GetValue(i).ToString();
                    }
                    res.Add(str);
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            reader.Close();
            con.Close();

            return res;
        }


    }

   
}