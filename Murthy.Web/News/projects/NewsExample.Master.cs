using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Murthy.Web.News.projects
{
    public partial class NewsExample : System.Web.UI.MasterPage
    {
        private void Page_Load_RealTimeNews()
        {
            string sqlSearchNews;           
            sqlSearchNews = "SELECT Title, URL FROM mf_news WHERE Catalogue=N'即时新闻'";
        
            List<string[]> result = MForum.SqlArray(sqlSearchNews);
            string URL;

            for (int i = 0; i < result.Count; i++)
            {
                LinkButton link = new LinkButton();
                link.Text = result[i][0];
                URL = result[i][1];
                link.Click += (object s, EventArgs a) => RealTimeNewsClick(URL);
                Ph_RealTimeNews.Controls.Add(link);
            }
            
        }

        private void RealTimeNewsClick(string url)
        {
            Response.Redirect(url);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Page_Load_RealTimeNews();
        }
    }
}