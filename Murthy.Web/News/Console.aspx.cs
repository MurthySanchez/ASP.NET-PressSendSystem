using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;

namespace Murthy.Web.News
{
    public partial class Console : System.Web.UI.Page
    {
        string username, userid,tmpUsername;
        string specialWord ="n";

        static string sqlSearchWholeSubNews = "SELECT NewsId, Title, Catalogue, UploadTime, Content,Keyword FROM mf_news WHERE status='1'";
        static string sqlSearchWholeNews = "SELECT NewsId, Title, Catalogue, CreateTime, Content, Keyword FROM mf_news WHERE status='0'";
        private static string modifyId = null;
         
        ImageButton btnEdit, btnDel;
        Hashtable hashtable = new Hashtable();


        private void HashTableInit()
        {
            for (int i = 0; i <= 31; i++)
            {
                if (i <= 9)
                    hashtable.Add(i, i);
                else
                    hashtable.Add(i, (char)(i + 55));
            }
        }

        protected void Page_Load_NewsList(string sql, Table table)
        {
            List<string[]> result = MForum.SqlArray(sql);
            //int column = 4;
            int id = 1;
            
            for(int i = 0; i < result.Count; i++)
            {
                string realId = result[i][0];
                string title = result[i][1];
                string catlog = result[i][2];
                string createtime = result[i][3];
                string content = result[i][4];
                string keyword = result[i][5];

                TableRow row = new TableRow();
                TableCell cellTitle, cellCatlog, cell;

                cell = new TableCell();
                cell.Text = id++.ToString();
                row.Cells.Add(cell);//从1开始按显示顺序编号

                cellTitle = new TableCell();
                cellTitle.Text = title;
                row.Cells.Add(cellTitle);//添加标题

                cellCatlog = new TableCell();
                cellCatlog.Text = catlog;
                row.Cells.Add(cellCatlog);//添加类别

                cell = new TableCell();
                cell.Text = createtime;
                row.Cells.Add(cell);//添加创建时间

                btnEdit = new ImageButton();
                btnDel = new ImageButton();
                btnEdit.ImageUrl = "/images/icn_edit.png";
                btnDel.ImageUrl = "/images/icn_trash.png";
                cell = new TableCell();
                cell.Controls.Add(btnEdit);
                cell.Controls.Add(btnDel);
                row.Cells.Add(cell);//添加操作选项

                table.Rows.Add(row);//将行插入到表格中

                btnEdit.AlternateText = "编辑";
                btnDel.AlternateText = "删除";

                //按钮事件
                btnEdit.Click += (object sender, ImageClickEventArgs e) => BtnEditClick(btnEdit,realId,title, catlog, content, keyword);
                btnDel.Click += (object sender, ImageClickEventArgs e) => BtnDelClick(table,row, realId);
                btnEdit.PostBackUrl = "#pushNews";
            }

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            
            username = Session["username"].ToString();
            tmpUsername = Session["tmpUsername"].ToString();
            Session["modifyId"] = "";
            if (username == "")
            {
                userid = new Random().Next(1000).ToString();
                if(tmpUsername == "")
                {
                    lblName.Text = "游客" + userid;
                    tmpUsername = "游客" + userid;
                    Session["tmpUsername"] = tmpUsername;
                }
                select_status.Items.Remove("发布");
                specialWord = "N";
                li_article.Visible = false;
                article.Visible = false;
            }
            else
            {

                userid = Session["userid"].ToString();
                ShowAlert(userid);
                lblName.Text = username;
            }
            lblOnlineCount.Text = "当前在线:" + Application["user_sessions"].ToString() + "人";
            //Load_NewsList();
            Page_Load_NewsList(sqlSearchWholeSubNews, tblNewsManager);

            Page_Load_NewsList(sqlSearchWholeNews, tb2NewsManager);
            HashTableInit();
        }

        public void ShowAlert(string str)
        {
            Response.Write("<script language=javascript>alert('" + str + "');</script>");
        }

        private string createId()
        {
            string str = null;
            
            string year = DateTime.Now.ToString("yy");
            int y = Convert.ToInt32(year);
            string month = DateTime.Now.ToString("MM");
            int M = Convert.ToInt32(month);
            string date = DateTime.Now.ToString("dd");
            int d = Convert.ToInt32(date);
            string hour = DateTime.Now.ToString("HH");
            int h = Convert.ToInt32(date); 
            string min = DateTime.Now.ToString("mm");
            int m = Convert.ToInt32(date);
            int sum = h + m;
            str = userid + hashtable[y].ToString() + hashtable[M].ToString() + hashtable[d].ToString() + sum.ToString() + specialWord;
            return str;
        }

        protected void BtnEditClick(ImageButton btn,string id, string title, string catlog, string content, string key)
        {
            //Response.Redirect("./Console.aspx#pushNews");
            modifyId = id;//识别是否是修改新闻
            txtSubmitTitle.Value = title;
            txtSubmitContent.Value = content;
            selSubmitCatalog.Value = catlog;
            txtKeyword.Value = key;

        }

        protected void BtnDelClick(Table table,TableRow delRow,string id)
        {
            string sqlGetPath = "SELECT WholePathURL FROM mf_news WHERE NewsId ='" + id + "'";
            string path = MForum.SqlOneResult(sqlGetPath);
            string sqlDelSendRow = "DELETE FROM mf_news WHERE NewsId = '" + id + "'";
            table.Rows.Remove(delRow);
            File.Delete(path);
            ShowAlert(MForum.ExecSql(sqlDelSendRow).ToString()+"行删除");
        }

        //生成HTML页
        public static string WriteASPXFile(string html, string id)
        {
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"News\projects\"+id+".aspx";
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(@"<%@ Page Title="""" Language=""C#"" MasterPageFile=""~/News/projects/NewsExample.Master"" AutoEventWireup=""true"" %>");
            sw.WriteLine("<asp:Content ID=\"Content1\" ContentPlaceHolderID=\"head\" runat=\"server\">\n</asp:Content > ");
            sw.WriteLine("<asp:Content ID=\"Content2\" ContentPlaceHolderID=\"ContentPlaceHolder1\" runat=\"server\">");
            sw.WriteLine("<div id=\""+id+"\">");
            sw.WriteLine(html);
            sw.WriteLine("</div>");
            sw.WriteLine("<script type=\"text/javascript\">" +
                "compile();"+
                "function compile() {" +
                "var text = document.getElementById(\"" + id + "\").innerHTML;" +
                "var converter = new showdown.Converter();" +
                "var html = converter.makeHtml(text);" +
                "document.getElementById(\"" + id + "\").innerHTML = html;" +
                "}" +
                "</script>");
            sw.WriteLine("</asp:Content>");
            sw.Close();
            return path;
        }

        public static string WriteHTMLFile(string html, string id)
        {
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"News\projects\" + id + ".html";
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine("<!DOCTYPE html>"+
                        "<html>"+
                        "<head> " +
                        "   <meta charset = \"utf -8\"/>" +
                        "   <title> Murthy NEWS</title>" +
                        "   <script type = \"text /javascript\" src = \"/js/showdown.js\" ></script>" +
                        "   <link rel =\"stylesheet\" type = \"text/css\" href = \"/Styles/news.css\" />" +
                        "</head>" +
                        "<body>" +
                        "    <DIV id = \"bg1\" ></DIV>" +
                        "    <DIV id = \"bg2\" ></DIV>" +
                        "    <DIV id = \"outer\">" +
                        "        <DIV id = \"main\">" +
                        "            <DIV id = \"sidebar\">" +
                        "                <DIV class=\"box\">" +
                        "                    <H3>Catalog</H3>" +
                        "                    <DIV class=\"dateList\">" +
                        "                        <UL class=\"linkedList dateList\">" +
                        "                            <LI class=\"first\">" +
                        "                                <SPAN class=\"date\">Headline</SPAN> <A href = \"http://localhost:61774/News/Main.aspx#boxHotSpots\" > Headline </A>"+
                        "                            </LI>" +
                        "                            <LI>" +
                        "                                <SPAN class=\"date\">HotSpot</SPAN> <A href = \"http://localhost:61774/News/Main.aspx#boxHotNews\" > Hot Spots </A>"+
                        "                             </LI>" +
                        "                             <LI>" +
                        "                                 <SPAN class=\"date\">Recently</SPAN> <A href = \"http://localhost:61774/News/Main.aspx#boxRecentNews\" > Recently </A>"+
                        "                              </LI>" +
                        "                          </UL>" +
                        "                      </DIV>" +
                        "                  </DIV>" +
                        "              </DIV>" +
                        "              <DIV id=\"content\">");
            sw.WriteLine("<div id=\"" + id + "\">");
            sw.WriteLine(html);
            sw.WriteLine("</div>");
            //sw.WriteLine("<script type=\"text/javascript\">" +
            //    "compile();" +
            //    "function compile() {" +
            //    "var text = document.getElementById(\"" + id + "\").innerHTML;" +
            //    "var converter = new showdown.Converter();" +
            //    "var html = converter.makeHtml(text);" +
            //    "document.getElementById(\"" + id + "\").innerHTML = html;" +
            //    "}" +
            //    "</script>");
            sw.WriteLine("            </DIV>"+
                        "            <BR class=\"clear\">" +
                        "        </DIV>" +
                        "    </DIV>" +
                        "    <DIV id=\"copyright\">" +
                        "        Copyright © 2020 Murthy NewsStation.			 <A href=\"http://localhost:61774/Account/Login.aspx\">Console</A>"+
                        "    </DIV>" +
                        "</body>" +
                        "</html>");
            sw.Close();
            return path;
        }

        protected void IBtnUpdate_Click(object sender, ImageClickEventArgs e)
        {
            
            Response.Redirect("./Console.aspx");
            
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string searchBox = TextBox1.Text;
            
            string sqlSearchKeyWord = "SELECT NewsId, Title, Catalogue, UploadTime, Content,Keyword FROM mf_news" +
                " WHERE Title=N'"+searchBox+ "' OR Keyword=N'" + searchBox+ "' OR  Catalogue=N'"+searchBox +"'";
            tblNewsManager.Controls.Clear();
            TableRow head = new TableRow();
            TableCell cell;

            cell = new TableCell();
            cell.Text = "编号";
            head.Cells.Add(cell);//从1开始按显示顺序编号

            cell = new TableCell();
            cell.Text = "标题";
            head.Cells.Add(cell);//添加标题

            cell = new TableCell();
            cell.Text = "类别";
            head.Cells.Add(cell);//添加类别

            cell = new TableCell();
            cell.Text = "创建时间";
            head.Cells.Add(cell);//添加创建时间

            cell = new TableCell();
            cell.Text = "操作";
            head.Cells.Add(cell);//添加创建时间
            tblNewsManager.Controls.Add(head);
            Page_Load_NewsList(sqlSearchKeyWord, tblNewsManager);

        }

        protected void iBtnMessage_Click(object sender, ImageClickEventArgs e)
        {
            HtmlGenericControl htmlGeneric = new HtmlGenericControl();
            System.Web.UI.WebControls.Label lblContent = new System.Web.UI.WebControls.Label();
            //System.Web.UI.WebControls.Label lblUsr = new System.Web.UI.WebControls.Label();

            //lblContent.Text ="说: "+ Request.Form["sendMessage"].ToString();
            //lblUsr.Text = tmpUsername;

            Application.Lock();
            if(username=="")
                Application["chatcon"] += "<br>" + tmpUsername + "说: " + Request.Form["sendMessage"].ToString();
            else
                Application["chatcon"] += "<br>" + username + "说: " + Request.Form["sendMessage"].ToString();

            Application.UnLock();
            lblContent.Text = Application["chatcon"].ToString();

            //htmlGeneric.Controls.Add(lblUsr);
            htmlGeneric.Controls.Add(lblContent);
           
            messageContent.Controls.Add(htmlGeneric);
        }

        private int TrashOrSaveHTML(string sql,string path)
        {
            int countSql = MForum.ExecSql(sql);
            if (countSql == 0)
                File.Delete(path);
            return countSql;
        }
 
        protected void BtnSubmitClick(object sender, EventArgs e)
        {
            string txtTitle = Request.Form["txtSubmitTitle"].ToString();
            string txtContent = Request.Form["txtSubmitContent"].ToString();
            //string txtContent = txtSubmitContent.InnerHtml;
            //string txtMarkDown = txtAreaContent.InnerHtml;
            string txtCatalog = Request.Form["selSubmitCatalog"].ToString();
            string txtKeyword = Request.Form["txtKeyword"].ToString();
            string createTime = DateTime.Now.ToString();
            string subTime = "NULL";
            string updatetime = "NULL";
            string chooseStatus = Request.Form["select_status"];
            string WholePathUrl;


            if (String.IsNullOrEmpty(txtTitle) || String.IsNullOrEmpty(txtContent) )
            {
                ShowAlert("error: 未输入完全, 请检查!");
                return;
                
            }
            

            if (String.IsNullOrEmpty(modifyId))
            {
                string id = createId();
                //string urlHTML = WriteASPXFile(txtContent, id);
                WholePathUrl = WriteHTMLFile(txtContent, id);
                string urlHTML = "/News/projects/" + id + ".html";
                if (username == null || chooseStatus=="草稿")
                {
                    subTime = "NULL";

                    string sqlWriteNews = "INSERT INTO mf_news (NewsId, Title, CreateTime, UploadTime, Content, Catalogue, Keyword, URL, WholePathURL, status) VALUES('" +
                        id + "',N'" + txtTitle + "','" + createTime + "'," + subTime + ",N'" + txtContent + "',N'" + txtCatalog + "',N'" + txtKeyword + "','" + urlHTML + "','" + WholePathUrl + "','0')";
                    ShowAlert(TrashOrSaveHTML(sqlWriteNews, WholePathUrl).ToString() + "则新闻已加入草稿箱");

                    //Response.Redirect("./Console.aspx");

                }
                else
                {
                    subTime = DateTime.Now.ToString();

                    string sqlWriteNews = "INSERT INTO mf_news VALUES ('" + id + "',N'" + txtTitle + "','" + createTime + "','" + subTime + "',N'" + txtContent + "',N'" + txtCatalog + "',N'" + txtKeyword + "','" + urlHTML + "','" + WholePathUrl + "','1')";

                    ShowAlert(TrashOrSaveHTML(sqlWriteNews, WholePathUrl).ToString() + "则新闻已发布");
                    //Response.Redirect("./Console.aspx");
                }
            }
            else
            {
                WholePathUrl = WriteHTMLFile(txtContent, modifyId);
                string urlHTML = "/News/projects/" + modifyId + ".html";
                //string urlHTML = WriteASPXFile(txtContent,modifyId);
                updatetime = DateTime.Now.ToString();

                if (chooseStatus == "发布")
                {
                    
                    string sqlUpdateNews = "UPDATE mf_news " +
                                        "SET Title = N'" + txtTitle + "'," +
                                            "Content = N'" + txtContent + "'," +
                                            "UploadTime = '" + updatetime + "'," +
                                            "Catalogue = N'" + txtCatalog + "'," +
                                            "Keyword = N'" + txtKeyword + "'," +
                                            "URL = '" + urlHTML + "'," +
                                            "WholePathURL = '" + WholePathUrl + "'," + 
                                            "status = '1'" +
                                        "WHERE NewsId = '" + modifyId + "'";

                    ShowAlert(TrashOrSaveHTML(sqlUpdateNews, WholePathUrl).ToString() + "则新闻更新并发布");
                }
                else
                {
                    string sqlUpdateNews = "UPDATE mf_news " +
                                        "SET Title = N'" + txtTitle + "'," +
                                            "Content = N'" + txtContent + "'," +
                                            "UploadTime = '" + updatetime + "'," +
                                            "Catalogue = N'" + txtCatalog + "'," +
                                            "Keyword = N'" + txtKeyword + "'," +
                                            "URL = '" + urlHTML + "'," +
                                            "WholePathURL = '" + WholePathUrl + "'," +
                                            "status = '0'" +
                                        "WHERE NewsId = '" + modifyId + "'";

                    ShowAlert(TrashOrSaveHTML(sqlUpdateNews, WholePathUrl).ToString() + "则新闻更新并存草稿");
                }
                    
            }






        }
    }
}