<%@ Page Language="C#" AutoEventWireup="true" CodeFile="baseinfo.aspx.cs" Inherits="ysmzadmin_baseinfo_baseinfo" %>
<%@ Register Src="~/ysmzadmin/baseinfo/userleft.ascx" TagPrefix="uc1" TagName="userleft" %>
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
        <div class="houtai_left"><uc1:userleft ID="Userleft1" runat="server" /></div> 
        <div class="houtai_right">
        <div class="houtai_right_title">芙蓉特色后台基本属性设置</div>
        <div class="houtai_right_left">       
        <ul>
          <li class="houtai_right_leftli">网站名称：</li>
          <li class="houtai_right_leftli">网站地址：</li>
          <li class="houtai_right_leftli">网站邮箱：</li>
          <li class="houtai_right_leftli">程序设计：</li>
          <li class="houtai_right_leftli">原来LOGO：</li>
          <li class="houtai_right_leftli">现在LOGO：</li>
          <li class="houtai_right_leftli">版本序号：</li>
        </ul>
        </div>
        <div class="houtai_right_right">
        <ul>
            
          <li class="houtai_right_rightli"><asp:TextBox ID="sitenamebox" runat="server"></asp:TextBox></li>
          <li class="houtai_right_rightli"><asp:TextBox ID="siteadressbox" runat="server"></asp:TextBox></li>
          <li class="houtai_right_rightli"><asp:TextBox ID="sitepostbox" runat="server"></asp:TextBox></li>
          <li class="houtai_right_rightli"><asp:TextBox ID="programerbox" runat="server"></asp:TextBox></li>
          <li class="houtai_right_rightli"><asp:TextBox ID="logotxt" runat="server" ReadOnly="True"></asp:TextBox></li>
          <li class="houtai_right_rightli"><input id="File1" type="file" runat="server" /></li>         
          <li class="houtai_right_rightli"><asp:TextBox ID="banbenbox" runat="server"></asp:TextBox></li>
        </ul>
        </div>
        <div class="houtai_right_bottom">
        <div class="houtai_right_bottomok"><asp:Button ID="save" runat="server" Text="保　存" OnClick="save_Click" /></div>            
        <div class="houtai_right_bottomre"><asp:Button ID="reset" runat="server" Text="修　改" OnClick="Button2_Click" /></div>
        </div>
        <div><asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>      
    </div>
   </div>         
   </div>     
    </form>
</body>
</html>
