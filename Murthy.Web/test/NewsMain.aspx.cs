using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Murthy.Web.News
{
    public partial class NewsMain : System.Web.UI.Page
    {
        private string URL;
        protected void Page_Load(object sender, EventArgs e)
        {
            string sqlSearchURL = "SELECT URL FROM mf_news WHERE Catalogue=N'今日头条'";
            string sqlSearchTitle = "SELECT TITLE FROM mf_news WHERE Catalogue=N'今日头条'";
            string title = MForum.SqlOneResult(sqlSearchTitle);
            URL = MForum.SqlOneResult(sqlSearchURL);

            linkHotSpots.Text = title;
        }

        protected void HotNewsClick(object sender, EventArgs e)
        {
            Response.Redirect(URL);

        }
    }
}