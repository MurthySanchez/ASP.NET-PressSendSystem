<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Murthy.Web.Account.Login" EnableEventValidation="false" %>

<!DOCTYPE html>

<!-- 此网页模板来自中国站长-->
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <!-- This Theme files -->
    <link href="../Styles/styleLogin.css" rel="stylesheet" type="text/css" media="all" />
    <title>Login</title>
    <style type="text/css">
        #txtCode {
            width: 105px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="background">
        </div>
        <div class="login">
            <div class="login-top">
                <h1 style="font-family: 'Arial Unicode MS'">Login</h1>

                <input id="txtUserID" name="txtUserID" type="text" value="User id" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'User Id';}" />
                <!--<asp:TextBox ID="txtUserID" runat="server" ></asp:TextBox>-->
                <input id="txtPasswd" name="txtPasswd" type="password" value="password" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'password';}" />
                <input id="txtCode" name="txtCode" type="text" name="txtCode" />
                <asp:Image ID="VerCodeImg" ImageUrl="~/Account/VerificationCode.aspx" runat="server" />
                <asp:Label ID="ifCodeInput" runat="server" ForeColor="#CC0000"></asp:Label>
                

                <div class="forgot">
                    <a href="../News/Console.aspx">Visitor login</a>
                    <asp:Button ID="BtnLogin" runat="server" Text="Login" OnClick="BtnLogin_Click" />

                </div>
            </div>

            <div class="login-bottom">
                <%--<h3 style="font-family: 'Arial Unicode MS'">Haven't admin account?&nbsp<a href="#" style="font-size: 20px">Guest access</a></h3>--%>
            </div>

        </div>
    </form>
    <div class="copyright">
        <p>Copyright &copy; 2020 Murthy News Station.</p>
    </div>
</body>
</html>
