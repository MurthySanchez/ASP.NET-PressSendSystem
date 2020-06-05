using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;

namespace Murthy.Web.Account
{
    public partial class Login : System.Web.UI.Page, IHttpHandler, IRequiresSessionState
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            //ifCodeInput.Text = Session["ValidateNum"].ToString();
            txtUserID.Text = Session["username"].ToString();
        }


        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = Request.Form["txtUserID"].ToString();
            string passwd = Request.Form["txtPasswd"].ToString();
            string vf = Request.Form["txtCode"].ToString();

            string alert_wrongPwd = "alert('Password is wrong!');";
            string alert_login = "alert('Successful login!');";
            string alert_errorUsername = "alert('Wrong username!');";


            //Response.Write(username+passwd);
            if ((String.IsNullOrEmpty(username)) || (username == "User id"))
            {
                string script = "alert('You should input your id!');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "warning", script, true);
                return;
            }

            if (String.IsNullOrEmpty(vf))
            {
                ifCodeInput.Text = "请输入验证码";
                return;
            }
            else
            {
                if (vf != Session["ValidateNum"].ToString())
                {
                    ifCodeInput.Text = "验证码有误, 请重新输入!";
                    return;
                }
            }

            string sqlSearchId = "select * from mf_user where Email = '" + username + "'or Account = '"
                + username + "'";


            Boolean resultId = MForum.IFSqlExist(sqlSearchId);
            if (resultId)
            {
                string sqlSearchPwd = "select * from mf_user where Passwd = '" + passwd + "' and (Email = '" + username + "' or Account = '" + username + "')";
                string userid = MForum.SqlOneResult(sqlSearchId);
                Boolean resultPwd = MForum.IFSqlExist(sqlSearchPwd);
                if (resultPwd)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "warning", alert_login, true);
                    Session["username"] = username;
                    Session["userid"] = userid;
                    Response.Redirect("../News/Console.aspx");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "warning", alert_wrongPwd, true);
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "warning", alert_errorUsername, true);
                return;

            }



            //Response.Write("Login!");
        }
    }

}