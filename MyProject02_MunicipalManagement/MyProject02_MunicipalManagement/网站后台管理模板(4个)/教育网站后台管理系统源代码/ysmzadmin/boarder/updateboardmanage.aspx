<%@ Page Language="C#" AutoEventWireup="true" CodeFile="updateboardmanage.aspx.cs" Inherits="ysmzadmin_boarder_updateboardmanage" %>
<%@ Register Src="~/ysmzadmin/boarder/userleft.ascx" TagPrefix="uc1" TagName="userleft" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title><%=pagetitle%></title>
    <link href="../../skin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="pagebody">
     <div class="houtai_bg"></div>
     <div class="pagebody1">
      <div class="houtai_left1"><uc1:userleft ID="Userleft1" runat="server" /></div>
     <div class="houtai_right1">
      <div class="houtai_right_title">芙蓉特色修改公告信息</div>
      <div class="houtai_right_gonggao">
        <asp:Label ID="Label1" runat="server" Text="标　题：" Height="17px"></asp:Label>
          <asp:TextBox ID="titletext_up" runat="server" Width="180px"></asp:TextBox>
          <asp:Label ID="Label2" runat="server" Height="17px" Text="注：输入的汉字不超过20个！！" ForeColor="Red"></asp:Label>
      </div>
      <div class="houtai_right_gonggao"><asp:Label ID="Label3" runat="server" Text="发布者："></asp:Label>
          <asp:TextBox ID="nametext_up" runat="server"></asp:TextBox>
      </div>
      <div class="houtai_right_gonggao">
          <asp:Label ID="Label4" runat="server" Text="内　容："></asp:Label>
    </div>
    <div class="houtai_right_pic1">
        <asp:TextBox ID="gonggaocentent_up" runat="server" Height="195px" Width="606px" TextMode="MultiLine"></asp:TextBox>
    </div>
    <div class="houtai_right_bottomok">
        <asp:Button ID="goback" runat="server" Text="返回" OnClick="goback_Click" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="gonggao_up" runat="server" Text="修改" OnClick="gonggao_up_Click" /></div>
         
    <div class="houtai_right_bottomre"><asp:Button ID="gonggaoreset" runat="server" Text="重置" OnClick="gonggaoreset_Click" /></div>
    </div>
    </div>
    </div>
    </form>
</body>
</html>
