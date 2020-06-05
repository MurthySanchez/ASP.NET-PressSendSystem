<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Console.aspx.cs" Inherits="Murthy.Web.News.Console" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/Styles/console.css" type="text/css" />
    <script type="text/javascript" src="/js/showdown.js"></script>
    <title>Murthy NEWS-控制台</title>
</head>
<body>
    <form id="formConsole" runat="server">
        <header id="header">
            <hgroup>
                <h1 class="site_title"><a href="index.html">Murthy NEWS</a></h1>
                <h2 class="section_title">Console</h2>
            </hgroup>
        </header>
        <!-- end of header bar -->
        <section id="secondary_bar">
            <div class="user">

                <p>
                    <asp:Label ID="lblName" runat="server"></asp:Label>
                    (<a href="#messages">Messages</a>)
                </p>

                <!-- <a class="logout_user" href="#" title="Logout">Logout</a> -->
            </div>
            <div class="breadcrumbs_container">
                <article class="breadcrumbs">
                    <a href="#">控制台</a><div class="breadcrumb_divider"></div>
                    <a class="current" href="/News/Main.aspx">切换到首页</a>
                </article>
            </div>
        </section>
        <!-- end of secondary bar -->
        <aside id="sidebar" class="column">
            <hr />
            <h3>我的面板</h3>
            <ul class="toggle">
                <%--<li><font class="ficomoon icon-pwd"></font><a href="#">修改密码</a></li>--%>
                <li><font class="ficomoon icon-logout"></font><a href="/Account/Login.aspx">退出</a></li>
            </ul>
            <h3>模块</h3>
            <ul class="toggle">
                <li><font class="ficomoon icon-circle"></font><a href="#access">访问记录</a></li>
                <li id="li_article" runat="server"><font class="ficomoon icon-bbs"></font><a href="#article">文章管理</a></li>
                <li id="li_message" runat="server"><font class="ficomoon icon-question"></font><a href="#messages">消息管理</a></li>
                <li><font class="ficomoon icon-private-msg"></font><a href="#pushNews">发布文章</a></li>

            </ul>
            <%--<h3>用户</h3>
            <ul class="toggle">
                <li><font class="ficomoon icon-user-module"></font><a href="#userManage">会员管理</a></li>
                <li><font class="ficomoon icon-users"></font><a href="#visitorManage">游客管理</a></li>
                <li><font class="ficomoon icon-user-group"></font><a href="#">会员组管理</a></li>
            </ul>--%>

            <footer>
                <hr />
                <p><strong>Copyright &copy; 2020 Murthy NewsStation.</strong></p>
            </footer>
        </aside>
        <!-- end of sidebar -->
        <section id="main" class="column main_shadow">
            <h4 class="alert_info">欢迎来到管理面板</h4>
            <article id="access" class="module width_full">
                <header>
                    <h3>访问记录</h3>
                </header>
                <div class="module_content">
                    <article class="stats_graph">
                        <img src="../images/hotNews/gun.jpg" width="520" height="140" alt="" />
                    </article>

                    <article class="stats_overview">
                        <div class="overview_today">
                            <p class="overview_day">今日</p>
                            <p class="overview_count">1,876</p>
                            <p class="overview_type">点击</p>
                            <p class="overview_count">2,103</p>
                            <p class="overview_type">浏览</p>
                        </div>
                        <div class="overview_previous">
                            <p class="overview_day">昨日</p>
                            <p class="overview_count">1,646</p>
                            <p class="overview_type">点击</p>
                            <p class="overview_count">2,054</p>
                            <p class="overview_type">浏览</p>
                        </div>
                    </article>
                    <div class="clear"></div>
                </div>
            </article>


            <article id="article" runat="server" class="module width_3_quarter">
                <header>
                    <h3 class="tabs_involved">文章管理</h3>
                    <%--<ul class="tabs">
                        <li class="active"><a href="#tab1">发布</a></li>
                        <li><a href="#tab2" >草稿箱</a></li>
                    </ul>--%>
                    <ul class="tabs">
                        <asp:ImageButton ID="IBtnUpdate" runat="server" OnClick="IBtnUpdate_Click" Height="16px" ImageAlign="Left" ImageUrl="~/images/icn_update.png" Width="16px"/>
                        <li id="sendbox" runat="server" class="active"><a href="#tab_container" onclick="click_send()">发布</a></li>
                        <li id="draftbox" runat="server"><a href="#tab_container" onclick="click_draft()">草稿箱</a></li>
                    </ul>
                    <asp:TextBox ID="TextBox1" runat="server" Height="16px"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/icn_search.png" OnClick="ImageButton1_Click" />
                </header>
                <script type="text/javascript">
                    function click_send() {
                        document.getElementById("tab2").style.display = "none";
                        document.getElementById("tab1").style.display = "block";
                        document.getElementById("sendbox").className = "active";
                        document.getElementById("draftbox").className = null;
                    }

                    function click_draft() {
                        document.getElementById("tab1").style.display = "none";
                        document.getElementById("tab2").style.display = "block";
                        document.getElementById("draftbox").className = "active";
                        document.getElementById("sendbox").className = null;
                        //$('#tab1').css('display', 'none');
                    }
                </script>


                <div class="tab_container">

                    <div id="tab1" class="tab_content">
                        
                        <asp:Table ID="tblNewsManager" runat="server" CssClass="tablesorter">
                            <asp:TableHeaderRow runat="server">
                                <asp:TableCell runat="server"></asp:TableCell>
                                <asp:TableCell runat="server">新闻标题</asp:TableCell>
                                <asp:TableCell runat="server">类别</asp:TableCell>
                                <asp:TableCell runat="server">创建时间</asp:TableCell>
                                <asp:TableCell runat="server">操作</asp:TableCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                         <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CssClass="tablesorter" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="NewsId" ForeColor="Black" GridLines="Horizontal">
                            <Columns>
                                <asp:BoundField DataField="NewsId" HeaderText="NewsId" SortExpression="NewsId" />
                                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                                <asp:BoundField DataField="CreateTime" HeaderText="CreateTime" SortExpression="CreateTime" ReadOnly="True" />
                                <asp:BoundField DataField="Catalogue" HeaderText="Catalogue" SortExpression="Catalogue" />
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/images/icn_trash.png" EditImageUrl="~/images/icn_edit.png" ShowEditButton="True" />
                            </Columns>
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#242121" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [NewsId], [Title], [CreateTime], [Catalogue] FROM [mf_news]" DeleteCommand="DELETE FROM [mf_news] WHERE [NewsId] = @NewsId" InsertCommand="INSERT INTO [mf_news] ([NewsId], [Title], [CreateTime], [Catalogue]) VALUES (@NewsId, @Title, @CreateTime, @Catalogue)" UpdateCommand="UPDATE [mf_news] SET [Title] = @Title, [CreateTime] = @CreateTime, [Catalogue] = @Catalogue WHERE [NewsId] = @NewsId">
                            <DeleteParameters>
                                <asp:Parameter Name="NewsId" Type="String" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="NewsId" Type="String" />
                                <asp:Parameter Name="Title" Type="String" />
                                <asp:Parameter Name="CreateTime" Type="DateTime" />
                                <asp:Parameter Name="Catalogue" Type="String" />
                            </InsertParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="Title" Type="String" />
                                <asp:Parameter Name="CreateTime" Type="DateTime" />
                                <asp:Parameter Name="Catalogue" Type="String" />
                                <asp:Parameter Name="NewsId" Type="String" />
                            </UpdateParameters>
                        </asp:SqlDataSource>--%>
                    </div>

                    <div id="tab2" class="tab_content" style="display: none">
                        <asp:Table ID="tb2NewsManager" runat="server" CssClass="tablesorter">
                            <asp:TableHeaderRow runat="server">
                                <asp:TableCell runat="server"></asp:TableCell>
                                <asp:TableCell runat="server">新闻标题</asp:TableCell>
                                <asp:TableCell runat="server">类别</asp:TableCell>
                                <asp:TableCell runat="server">创建时间</asp:TableCell>
                                <asp:TableCell runat="server">操作</asp:TableCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                    </div>
                    <!-- end of #tab2 -->
                </div>
                <!-- end of .tab_container -->
            </article>



            <article id="messages" runat="server" class="module width_quarter">
                <header>
                    <h3>消息
                    </h3>
                    <asp:Label ID="lblOnlineCount" runat="server" Text="Label"></asp:Label>
                </header>
                <div class="message_list">
                    <div id="messageContent" runat="server" class="module_content">
                        <div id ="messagemessage" runat="server" class="message">
                            <%--<p>啥时候下班呀?</p>
                            <p><strong>John Doe</strong></p>--%>
                        </div>
                       <%-- <div class="message">
                            <p>主管咋还不说下班呢</p>
                            <p><strong>John Doe</strong></p>
                        </div>
                        <div class="message">
                            <p>开始摸鱼...</p>
                            <p><strong>John Doe</strong></p>
                        </div>
                        <div class="message">
                            <p>🤫主管来了!</p>
                            <p><strong>Timmy</strong></p>
                        </div>
                        <div class="message">
                            <p>收到收到!</p>
                            <p><strong>John Doe</strong></p>
                        </div>--%>
                    </div>
                </div>
                <footer class="post_message">
					<input id="sendMessage" name="sendMessage" type="text" value="Message" onfocus="if(!this._haschanged){this.value=''};this._haschanged=true;"/>
                    <asp:ImageButton ID="iBtnMessage" runat="server" CssClass="btn_post_message" OnClick="iBtnMessage_Click" />
                </footer>
            </article>


            <div class="clear"></div>
            <article id="pushNews" class="module width_full">
                <header>
                    <h3>文章</h3>
                </header>
                <div class="module_content">
                    <fieldset>
                        <label>新闻标题</label>
                        <input id="txtSubmitTitle" name="txtSubmitTitle" type="text" runat="server"/>
                    </fieldset>

                    <fieldset id="fieldContent" style="height:400px;">
                        <label>内容</label>
                        <textarea id="txtSubmitContent" name="txtSubmitContent" rows="12" runat="server" onkeyup="compile()"></textarea>
                        <div id="txtAreaContent" runat="server"></div>
                    </fieldset>

                    <fieldset style="width: 48%; float: left; margin-right: 3%;">
                        <!-- to make two field float next to one another, adjust values accordingly -->
                        <label>类别</label>
                        <select id="selSubmitCatalog" name="selSubmitCatalog" runat="server" style="width: 92%;">
                            <option>今日头条</option>
                            <option>热点要闻</option>
                            <option>近日新闻</option>
                            <option>即时新闻</option>
                        </select>
                    </fieldset>

                    <fieldset style="width: 48%; float: left;">
                        <label>标签</label>
                        <input id="txtKeyword" name="txtKeyword" runat="server" type="text" style="width: 92%;"/>
                    </fieldset>
                    <div class="clear"></div>
                </div>
                <footer>
                    <div class="submit_link" runat="server">
                        
                        <select id="select_status" name="select_status" runat="server">
                            <option>发布</option>
                            <option>草稿</option>
                        </select>
                        <asp:Button ID="btnSubmit" runat="server" CssClass="alt_btn" Text="发布" OnClick="BtnSubmitClick"/>
                        <asp:Button ID="btnReset" runat="server" Text="重置" />
                    </div>
                </footer>
            </article>
            <%--<!-- end of post new article -->
        <h4 class="alert_warning">A Warning Alert</h4>

        <h4 class="alert_error">An Error Message</h4>

        <h4 class="alert_success">A Success Message</h4>--%>
            <article id="userManage" class="module width_full">
                <header>
                    <h3>会员管理</h3>
                </header>
                <div class="module_content">
                </div>
            </article>

            <!-- end of styles article -->
            <div class="spacer"
            </div>

            <article id="visitorManage" class="module width_full">
                <header>
                    <h3>游客管理</h3>
                </header>
                <div class="module_content">
                </div>
            </article>

            <div class="spacer">
            </div>
        </section>
        <script src="scripts/libs/require/require.js" type="text/javascript" data-main="scripts/app/index/main"></script>
    </form>
    <script type="text/javascript">
        function compile() {
            var text = document.getElementById("txtSubmitContent").value;
            var converter = new showdown.Converter();
            var html = converter.makeHtml(text);
            document.getElementById("txtAreaContent").innerHTML = html;
        }
       
    </script>
</body>
</html>
