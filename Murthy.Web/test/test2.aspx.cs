using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Murthy.Web.test
{
    public partial class test2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button2_Click(object sender, EventArgs e)
        {

            if (this.TextBox2.Text.ToString().Trim() == Session["CheckCode2"].ToString())
            {
                Response.Write("<script lauguage='javascript'>alert('验证成功');</script>");
            }
        }
    }
}