<%@ Page Title="" Language="C#" MasterPageFile="~/News/projects/NewsExample.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Murthy.Web.News.projects.Main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div id="boxHotSpots" class="box1">

            <h2 style="font-family: 'Comic Sans MS'">Welcome to Murthy NEWS
            </h2>
            <img src="/images/hotNews/4.png" alt="" class="left" />
            <asp:PlaceHolder ID="Ph_HotSpots" runat="server"></asp:PlaceHolder>
            <%--<asp:LinkButton ID="linkHotSpots" runat="server" OnClick="HotNewsClick" CssClass="link"></asp:LinkButton>--%>
        </div>
        <div id="boxHotNews" class="box">
            <h3 style="font-family: 宋体, Arial, Helvetica, sans-serif; font-size: 22px; font-style: normal; font-weight: bolder">热点新闻
            </h3>
            <asp:PlaceHolder ID="Ph_HotNews" runat="server"></asp:PlaceHolder>
        </div>
        <br class="clear" />
        <div id="boxRecentNews" class="box">
            <h3 style="font-family: 宋体, Arial, Helvetica, sans-serif; font-size: 22px; font-style: normal; font-weight: bolder">近日新闻
            </h3>
            <asp:PlaceHolder ID="Ph_RecentNews" runat="server"></asp:PlaceHolder>
        </div>
        <br class="clear" />
    </div>

</asp:Content>
