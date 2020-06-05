<%@ Page Title="" Language="C#" MasterPageFile="/News/projects/NewsExample.Master" AutoEventWireup="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="dfajk"># 发的时间考虑
打算离开就
1. 发动机埃里克
2. 阿凡达
3. 发觉离开

爱上发动机哭了</div>
    <script type="text/javascript">
        function compile() {
            var text = document.getElementById("dfajk").innerHTML;
            var converter = new showdown.Converter();
            var html = converter.makeHtml(text);
            document.getElementById("dfajk").innerHTML = html;
        }
    </script>
</asp:Content>
