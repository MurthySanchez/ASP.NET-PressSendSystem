using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Murthy.Web.News.projects
{
    public partial class Main : System.Web.UI.Page
    {

        private void Page_Load_News(int num)
        {
            string sqlSearchNews;
            PlaceHolder placeHolder;
            switch (num)
            {
                case 0: sqlSearchNews = "SELECT Title, URL FROM mf_news WHERE Catalogue=N'今日头条' AND status='1'"; placeHolder = Ph_HotSpots; break;
                case 1: sqlSearchNews = "SELECT Title, URL FROM mf_news WHERE Catalogue=N'热点要闻' AND status='1'"; placeHolder = Ph_HotNews; break;
                case 2: sqlSearchNews = "SELECT Title, URL FROM mf_news WHERE Catalogue=N'近日新闻' AND status='1'"; placeHolder = Ph_RecentNews; break;
                default: return ;
                
            }
            List<string[]> result = MForum.SqlArray(sqlSearchNews);

            for (int i = 0; i < result.Count; i++)
            {
                string URL;

                LinkButton link = new LinkButton();
                link.Text = result[i][0];
                URL = result[i][1];
                link.Click += (object s, EventArgs a) => HotNewsClick(URL);
                placeHolder.Controls.Add(link);
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

            Page_Load_News(0);   //今日头条
            Page_Load_News(1);   //热点要闻
            Page_Load_News(2);   //近日新闻
            Application.Lock();
            Application["clickCount"] = (int)Application["clickCount"] + 1;
            Application.UnLock();
        }


        protected void HotNewsClick(String str)
        {
            Response.Redirect(str);

        }
    }
}