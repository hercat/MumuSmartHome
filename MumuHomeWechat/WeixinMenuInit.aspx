<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WeixinMenuInit.aspx.cs" Inherits="MumuHomeWechat.WeixinMenuInit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="btnWeixinMenu" runat="server" OnClick="btnWeixinMenu_Click" Text="微信菜单初始化" />
    
        <br />
    
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="微信菜单查询" />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="获取微信服务器IP地址" />
    
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="获取用户信息" />
        <br />
        <br />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="批量获取用户信息" />
    
        <br />
        <br />
        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="获取用户列表" />
    
        <br />
        <br />
        <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="发送模板消息" />
        <br />
    
    </div>
    </form>
</body>
</html>
