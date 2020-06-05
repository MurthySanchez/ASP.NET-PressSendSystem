using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Murthy.Web.test
{
    public partial class testForButton : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnLog_Click(object sender, EventArgs e)
        {
            string inputUserName = Request.Form["txtUserName"].ToString();
            string inputPasswd = Request.Form["txtUserPasswd"].ToString();

            if (String.IsNullOrEmpty(inputUserName) == true)
            {
                //Response.Write("You should input your id!");
                string script = "alert('You should input your id!');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "waring", script,true);
                return;
            }

            Response.Write("login! username is: "+inputUserName+" passwd is: "+inputPasswd);

        }
        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Response.Write("Reset!");

            //if (String.IsNullOrEmpty(txtUserID.Text) == true) return;

        }
    }
}