<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test2.aspx.cs" Inherits="Murthy.Web.test.test2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
    <div>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" /><br />
        &nbsp;
        <asp:Image ID="Image2" runat="server" ImageUrl="./ValidateCode.aspx?SessionKeyName=CheckCode2" />//该图片将用于显示验证码
    </div>
    </form>
</body>
</html>
