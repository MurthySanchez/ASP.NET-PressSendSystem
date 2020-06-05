<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testForButton.aspx.cs" Inherits="Murthy.Web.test.testForButton" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
         <h1>Test Btn affair</h1>
    <form id="form1" runat="server">
    <div>
        <table style="height:196px;width:491px">
            <tr><td colspan="2" align =center><asp:Label ID="Label1" runat="server" Text="SystemUserLogin"></asp:Label></td></tr>

            <tr><td align =center class="style1"><asp:Label ID ="Label2" runat="server" Text="username"></asp:Label></td>
                <td><asp:TextBox ID ="txtUserName" runat="server" Height="21px" Width="187px"></asp:TextBox></td>
            </tr>

            <tr><td align=center class="style1"><asp:Label ID ="Label3" runat="server" Text="password"></asp:Label></td>
                <td><asp:TextBox ID ="txtUserPasswd" runat="server" Height="21px" Width="187px" TextMode="Password"></asp:TextBox></td>
            </tr>

            <tr><td align=center class="style1"><asp:Label ID="Label4" runat="server" Text="UserGrade:"></asp:Label></td>
                <td>
                    <asp:RadioButton ID="RadioButton1" runat="server" Text="amdin" GroupName="level" />
                    <asp:RadioButton ID="RadioButton2" runat="server" Text="member" GroupName="level" />
                    <asp:RadioButton ID="RadioButton3" runat="server" Text="user" GroupName="level" />
                </td>
            </tr>
            <tr>
                <td align=center class="style1"><asp:Button ID="btnLog" runat="server" Text="login" onclick="BtnLog_Click"/></td>
                <td align=left><asp:Button ID="btnReset" runat="server" Text="reset" onclick="BtnReset_Click" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
