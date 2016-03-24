<%@ Page Language="C#" AutoEventWireup="true" CodeFile="updatearticle.aspx.cs" Inherits="ysmzadmin_article_updatearticle" %>
<%@ Register Src="~/ysmzadmin/article/userleft.ascx" TagPrefix="uc1" TagName="userleft" %>

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
         <div class="houtai_right_title">芙蓉特色修改文章信息</div>
          <div class="houtai_right_pic">
         <table style="width:100%; border:1px solid #565656">
         <tr>
         <td style="height:28px; vertical-align:middle; width:70px; padding-left:10px" align="left"><asp:Label ID="Label1" runat="server" Text="选择类别："></asp:Label></td>  
         <td style="width:170px; height:28px; vertical-align:middle" align="left"><asp:DropDownList ID="DropDownList1" runat="server" Width="137px"></asp:DropDownList></td>
         <td style="width:70px; vertical-align:middle; height:28px;padding-left:10px" align="left"><asp:Label ID="Label5" runat="server" Text="文章标题："></asp:Label> </td>
         <td style="vertical-align:middle; height:28px" align="left"><asp:TextBox ID="TextBox1" runat="server" Width="219px"></asp:TextBox></td>
         </tr>
         <tr>
         <td style="width:70px; vertical-align:middle; height:28px;padding-left:10px" align="left"><asp:Label ID="Label6" runat="server" Text="文章作者："></asp:Label></td>
         <td style="width:170px; height:28px; vertical-align:middle" align="left"><asp:TextBox ID="TextBox2" runat="server" Width="130px"></asp:TextBox></td>   
         <td style="height:28px; vertical-align:middle; width:70px; padding-left:10px" align="left"><asp:Label ID="Label2" runat="server" Text="文章出处："></asp:Label></td>
         <td style=" height:28px; vertical-align:middle;" align="left"><asp:TextBox ID="TextBox3" runat="server" Width="147px"></asp:TextBox></td>
         </tr>
         <tr>
         <td style="width:70px; vertical-align:middle; height:28px;padding-left:10px" align="left"><asp:Label ID="Label3" runat="server" Text="原来时间："></asp:Label> </td>
         <td style="width:170px; vertical-align:middle; height:28px;" align="left"><asp:Label ID="Label7" runat="server" Text="保存时绑定本地时间数据" ForeColor="#aca899"></asp:Label></td>
         <td style="width:70px; vertical-align:middle; height:28px;padding-left:10px;" align="left"><asp:Label ID="Label4" runat="server" Text="原来图片："></asp:Label> </td>
         <td style="vertical-align:middle; height:28px; padding-right:10px" align="left"><asp:Label ID="Label9" runat="server" Text="Label" ForeColor="#ACA899"></asp:Label>  </td>
         </tr>
         <tr>
         <td style="width:70px; vertical-align:middle; height:28px;padding-left:10px" align="left"></td>
         <td style="width:170px; height:28px; vertical-align:middle" align="left">
             <asp:CheckBox ID="CheckBox1" runat="server" Text="删除原来图片" />
             </td>
         <td style="width:70px; vertical-align:middle; height:28px;padding-left:10px;" align="left"><asp:Label ID="Label8" runat="server" Text="插入图片："></asp:Label> </td>
         <td style="vertical-align:middle; height:28px; padding-right:10px" align="left"><input id="File2" type="file" runat="server" /></td>
         </tr>            
         </table>
        </div>
        <div class="houtai_right_pic2"><asp:TextBox ID="TextBox4" runat="server" Height="212px" TextMode="MultiLine" Width="622px"></asp:TextBox>     
      <table style="width:100%">
      <tr>
      <td style=" width:47%; height: 30px;" align="right"><asp:Button ID="Button1" runat="server" Text="返　回" Height="28px" OnClick="Button1_Click" /></td>
      <td style="width:6%; height: 30px;" align="center"></td>
      <td style=" width:47%; height: 30px;" align="left"><asp:Button ID="Button2" runat="server" Text="修　改" Height="28px" OnClick="Button2_Click" /></td>         
      </tr>
      </table>
      </div>
      </div>
    </div>
    </form>
</body>
</html>

