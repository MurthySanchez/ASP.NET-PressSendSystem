<%@ Page Title="" Language="C#" MasterPageFile="/News/projects/NewsExample.Master" AutoEventWireup="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="dfajk"># ����ʱ�俼��
�����뿪��
1. �����������
2. ������
3. �����뿪

���Ϸ���������</div>
    <script type="text/javascript">
        function compile() {
            var text = document.getElementById("dfajk").innerHTML;
            var converter = new showdown.Converter();
            var html = converter.makeHtml(text);
            document.getElementById("dfajk").innerHTML = html;
        }
    </script>
</asp:Content>
