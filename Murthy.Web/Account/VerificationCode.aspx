<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerificationCode.aspx.cs" Inherits="Murthy.Web.Account.VerificationCode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <%Response.Buffer = true; %>
    <%Response.ExpiresAbsolute = DateTime.Now.AddSeconds(-1); %>
    <%Response.Expires = 0; %>
    <%Response.CacheControl = "no-cache"; %>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
