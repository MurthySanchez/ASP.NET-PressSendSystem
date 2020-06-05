<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test1.aspx.cs" Inherits="Murthy.Web.test.test1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" /><br />
        &nbsp;
        <asp:Image ID="Image1" runat="server" ImageUrl="~/ValidateCode.aspx?SessionKeyName=CheckCode1" />//该图片将用于显示验证码
    </div>
    </form>
</body>
</html>
