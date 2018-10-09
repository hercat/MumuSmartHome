<%@ Page Title="用户组管理" Language="C#" MasterPageFile="~/master/Master.Master" AutoEventWireup="true" CodeBehind="GroupInfoPage.aspx.cs" Inherits="MumuSmartHomeWebPortal.views.GroupInfoPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/groupInfo.css" rel="stylesheet" />
    <script src="../js/groupInfo.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div>
        <%--<ol class="breadcrumb">
            <li><a href="#">用户组管理</a></li>
            <li class="active">用户组管理</li>
        </ol>   --%>

    </div> 
    <div>
        <button class="btn btn-sm btn-success">添加</button>
        <button class="btn btn-sm btn-info">修改</button>
        <button class="btn btn-sm btn-danger">删除</button>
    </div>
    <div class="body">
                
    </div>
</asp:Content>
