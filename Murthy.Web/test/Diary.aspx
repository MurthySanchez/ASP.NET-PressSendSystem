<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Diary.aspx.cs" Inherits="MForum.timeChange" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>TimeChange</title>
</head>
<body>
    <form id="form1" runat="server">
        <p align="center" style="font-family: Chiller">
            <font size="8" font="">Diary</font>
        </p>
        <hr />
        <h1>day one</h1>
        <%
            DateTime time1 = DateTime.Now;
            Response.Write("date is :" + time1.ToString("yyyy-MM-dd") + "time is : " + time1.ToString("HH:mm:ss dddd"));
            %>
    </form>
</body>
</html>
