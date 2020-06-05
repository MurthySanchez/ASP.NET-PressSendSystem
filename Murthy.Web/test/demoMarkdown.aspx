<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="demoMarkdown.aspx.cs" Inherits="Murthy.Web.test.demoMarkdown" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>MarkDown</title>
    <script type="text/javascript" src="../js/showdown.js"></script>
</head>
<style>
    body {
        font-family: "Helvetica Neue", Helvetica, Microsoft Yahei, Hiragino Sans GB, WenQuanYi Micro Hei, sans-serif;
        font-size: 16px;
        line-height: 1.42857143;
        color: #333;
        background-color: #fff;
    }

    ul li {
        line-height: 24px;
    }

    blockquote {
        border-left: #eee solid 5px;
        padding-left: 20px;
    }

    code {
        color: #D34B62;
        background: #F9F2F4;
    }
</style>
<body>
    <form id="form1" runat="server">
        <div>
            <textarea id="content" style="height: 400px; width: 600px;" onkeyup="compile()"></textarea>
            <div id="result"></div>
        </div>
    </form>
    <script type="text/javascript">
        function compile() {
            var text = document.getElementById("content").value;
            var converter = new showdown.Converter();
            var html = converter.makeHtml(text);
            document.getElementById("result").innerHTML = html;
        }
    </script>
</body>
</html>
