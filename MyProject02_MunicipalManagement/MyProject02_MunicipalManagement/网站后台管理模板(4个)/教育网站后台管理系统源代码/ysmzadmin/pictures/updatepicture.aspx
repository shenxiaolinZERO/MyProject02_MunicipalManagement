<%@ Page Language="C#" AutoEventWireup="true" CodeFile="updatepicture.aspx.cs" Inherits="ysmzadmin_pictures_updatepicture" %>
<%@ Register Src="~/ysmzadmin/pictures/userleft.ascx" TagPrefix="uc1" TagName="userleft" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
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
         <div class="houtai_right_title">芙蓉特色修改图片</div>
          <div class="houtai_right_pic">
         <table style="width:100%; height:35px; border:1px solid #565656">
         <tr>
         <td style="width: 70px; padding-left:10px; vertical-align:middle"><asp:Label ID="Label1" runat="server" Text="Label">添加图片：</asp:Label></td>
         <td style="width:290px;height: 34px;" ><input id="p_File1" type="file" style="width: 290px;" runat="server"/></td>
         <td align="center" style="height: 34px"><asp:Button ID="p_add" runat="server" Text="添 加" Height="28px" /></td>
         <td align="center" style="height: 34px"><asp:Button ID="p_edit" runat="server" Text="修 改" Height="28px" OnClick="p_edit_Click" /></td>
         <td align="center" style="height: 34px"><asp:Button ID="p_back" runat="server" Text="返 回" OnClick="p_back_Click" Height="28px" /></td>
         </tr>          
         </table>           
         </div>
         <div class="houtai_right_pic1">
         <table style="width:100%"><tr><td align="center"><asp:Image ID="Image1" runat="server" Height="300px" Width="400px" ImageAlign="Middle" BorderColor="DimGray" BorderStyle="Solid" BorderWidth="3px" /></td></tr></table>
        </div>
        <div><asp:TextBox ID="p_txt" runat="server" Visible="False"></asp:TextBox>  
        </div>
      </div>
    </div>
    </div>
    </form>
</body>
</html>