using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Murthy.Web.test
{
    public partial class Default : System.Web.UI.Page
    {
        private static readonly string[] users = new string[] { "admin", "user" };

        private int usertype(string userid)
        {
            if (userid == users[0])
                return 1;
            if (userid == users[1])
                return 2;
            else
                return 0;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string userid = TextBox1.Text.ToString();
            string pwd = TextBox2.Text.ToString();
            Session["UserType"] = usertype(userid);
            switch (Session["UserType"].ToString())
            {
                case "1": Response.Write("Admin");
                    break;
                case "2": Response.Write("User");
                    break;
                default: Response.Write("Wrong!");break;
            }
        }
    }
}