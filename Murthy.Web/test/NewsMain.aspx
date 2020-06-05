<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsMain.aspx.cs" Inherits="Murthy.Web.News.NewsMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Murthy NEWS-最新咨询</title>
    <link rel="stylesheet" type="text/css" href="../Styles/news.css" />
</head>
<body>
		<div id="bg1"></div>
		<div id="bg2"></div>
		<div id="outer">
			<div id="main">
				<div id="sidebar">
					<div class="box">
						<h3>
							目录
						</h3>
						<div class="dateList">
							<ul class="linkedList dateList">
								<li class="first">
									<span class="date">头条</span> <a href="#boxHotSpots">今日头条</a>
								</li>
								<li>
									<span class="date">热点</span> <a href="#boxHotNews">热点要闻</a>
								</li>
								<li>
									<span class="date">近日</span> <a href="#boxRecentNews">近日新闻</a>
								</li>
								
							</ul>
						</div>
					</div>
					<div class="box">
						<h3>
							即时新闻
						</h3>
						<ul class="linkedList">
							<li class="first">
								<a href="#">Luctus curae vitae</a>
							</li>
							<li>
								<a href="#">Duis justo parturient lectus</a>
							</li>
							<li>
								<a href="#">Nullam fermentum cras sociis</a>
							</li>
							<li class="last">
								<a href="#">Natoque sapien suscipit</a>
							</li>
						</ul>
					</div>
				</div>
                <div id="content">
                    <div id="boxHotSpots" class="box1">
                        <form id="News" runat="server">

                            <h2 style="font-family: 'Comic Sans MS'">Welcome to Murthy NEWS
                            </h2>
                            <img src="../images/hotNews/4.png" alt="" class="left" />

                            <asp:LinkButton ID="linkHotSpots" runat="server" OnClick="HotNewsClick" CssClass="link"></asp:LinkButton>
                        </form>
                    </div>
					<div id="boxHotNews" class="box">
						<h3 style="font-family: 宋体, Arial, Helvetica, sans-serif; font-size: 22px; font-style: normal; font-weight: bolder">
							热点新闻
						</h3>
						<ul class="linkedList">
							<li class="first">
								<a href="#">Turpis et posuere urna dolor justo</a>
							</li>
							<li>
								<a href="#">Fringilla sem nisl purus lobortis magnis magna pellentesque</a>
							</li>
							<li>
								<a href="#">Venenatis magna ultricies sollicitudin sodales commodo nibh aenean</a>
							</li>
							<li>
								<a href="#">Magnis luctus penatibus non natoque nascetur tempus erat</a>
							</li>
							<li class="last">
								<a href="#">Penatibus dolor pharetra viverra ac erat proin</a>
							</li>
						</ul>
					</div><br class="clear" />
					<div id="boxRecentNews" class="box">
						<h3 style="font-family: 宋体, Arial, Helvetica, sans-serif; font-size: 22px; font-style: normal; font-weight: bolder">
							近日新闻
						</h3>
						<ul class="linkedList">
							<li class="first">
								<a href="#">Turpis et posuere urna dolor justo</a>
							</li>
							<li>
								<a href="#">Fringilla sem nisl purus lobortis magnis magna pellentesque</a>
							</li>
							<li>
								<a href="#">Venenatis magna ultricies sollicitudin sodales commodo nibh aenean</a>
							</li>
							<li>
								<a href="#">Magnis luctus penatibus non natoque nascetur tempus erat</a>
							</li>
							<li class="last">
								<a href="#">Penatibus dolor pharetra viverra ac erat proin</a>
							</li>
						</ul>
					</div><br class="clear" />
				</div><br class="clear" />
			</div>
		</div>
		<div id="copyright">
			Copyright &copy; 2020 Murthy NewsStation.
			<a href="../Account/Login.aspx">后台登陆</a>
		</div>
	 </body>
</html>

<!--REFERENCE BY Free CSS Templates
http://www.freecsstemplates.org -->