<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMainMenu.ascx.cs" Inherits="MumuSmartHomeWebPortal.userControl.ucMainMenu" %>
<link href="../css/MainMenu.css" rel="stylesheet" />
<script src="../js/mainMenu.js"></script>

<div class="nav">
    <div class="menu_item">
        <div class="menu_item_title" onclick="menuToggle(this)">
            <span><img src="../images/sources/people_fill.png" />用户管理</span>
        </div>
        <div class="menu_item_content">
            <ul>
                <li><a href="#">用户查询</a></li>
                <li><a href="#">添加用户</a></li>
            </ul>
        </div>
    </div>
    <div class="menu_item">
        <div class="menu_item_title" onclick="menuToggle(this)">
            <span><img src="../images/sources/group_fill.png" />用户组管理</span>
        </div>
        <div class="menu_item_content">
            <ul>
                <li><a href="../views/GroupInfoPage.aspx">用户组管理</a></li>
            </ul>
        </div>
    </div>
    <div class="menu_item">
        <div class="menu_item_title" onclick="menuToggle(this)">
            <span><img src="../images/sources/addressbook.png"/>账号管理</span>
        </div>
        <div class="menu_item_content">
            <ul>
                <li><a href="#">账号查询</a></li>
                <li><a href="#">账号管理</a></li>
            </ul>
        </div>
    </div>
    <div class="menu_item">
        <div class="menu_item_title" onclick="menuToggle(this)">
            <span><img src="../images/sources/lock_fill.png"/>权限管理</span>
        </div>
        <div class="menu_item_content">
            <ul>
                <li><a href="#">新增权限</a></li>
            </ul>
        </div>
    </div>
    <div class="menu_item">
        <div class="menu_item_title" onclick="menuToggle(this)">
            <span><img src="../images/sources/computer_fill.png"/>设备管理</span>
        </div>
        <div class="menu_item_content">
            <ul>
                <li><a href="#">新增设备</a></li>
            </ul>
        </div>
    </div>
    <div class="menu_item">
        <div class="menu_item_title" onclick="menuToggle(this)">
            <span><img src="../images/sources/tasks.png"/>任务管理</span>
        </div>
        <div class="menu_item_content">
            <ul>
                <li><a href="#">新增任务</a></li>
            </ul>
        </div>
    </div>
    <div class="menu_item">
        <div class="menu_item_title" onclick="menuToggle(this)">
            <span><img src="../images/sources/setting.png"/>配置管理</span>
        </div>
        <div class="menu_item_content">
            <ul>
                <li><a href="#">新增配置</a></li>
            </ul>
        </div>
    </div>
</div>