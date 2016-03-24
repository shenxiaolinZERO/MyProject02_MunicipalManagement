<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addpicture.aspx.cs" Inherits="ysmzadmin_pictures_addpicture" %>
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
         <div class="houtai_right_title">芙蓉特色添加图片</div>
         <div class="houtai_right_pic">
         <table style="width:100%; height:35px; border:1px solid #565656">
         <tr>
         <td style="width: 70px; padding-left:10px; vertical-align:middle; height: 34px;"><asp:Label ID="Label1" runat="server" Text="Label">添加图片：</asp:Label></td>
         <td style="width:290px; padding-right:5px; height: 34px;"><input id="upimage" type="file" style="width: 290px; height:28px" runat="server"/></td>
         <td align="center" style="height: 34px"><asp:Button ID="btnadd" runat="server" Text="添 加" OnClick="btnadd_Click" Height="28px" /></td>
         <td align="center" style="height: 34px"><asp:Button ID="btnupdate" runat="server" Text="修 改" Height="28px" /></td>
         <td align="center" style="height: 34px"><asp:Button ID="backet" runat="server" Text="返 回" OnClick="backet_Click" Height="28px" /></td>
         </tr>          
         </table>           
         </div>
         <div class="houtai_right_pic1"><asp:GridView ID="pic_GridView" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" PageSize="9" Width="626px">
             <Columns>
                 <asp:BoundField DataField="picid" HeaderText="图片ID号">
                     <ItemStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                     <HeaderStyle BackColor="SlateGray" />
                 </asp:BoundField>
                 <asp:BoundField DataField="picurl" HeaderText="图 片 路 径">
                     <ItemStyle Height="25px" VerticalAlign="Middle" />
                     <HeaderStyle BackColor="SlateGray" />
                 </asp:BoundField>
                 <asp:HyperLinkField DataNavigateUrlFields="picid" DataNavigateUrlFormatString="updatepicture.aspx?picid={0}"
                     HeaderText="查看" Text="查看">
                     <ItemStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                     <HeaderStyle BackColor="SlateGray" />
                 </asp:HyperLinkField>
                 <asp:CommandField HeaderText="删除" ShowDeleteButton="True">
                     <HeaderStyle BackColor="SlateGray" />
                     <ItemStyle ForeColor="Red" HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" Height="25px" />
                 </asp:CommandField>
             </Columns>
             <HeaderStyle ForeColor="White" Height="25px" VerticalAlign="Middle" />
             <PagerStyle HorizontalAlign="Center" />
          </asp:GridView>           
        </div>
            
        <div><asp:TextBox ID="pictxt" runat="server" Visible="False"></asp:TextBox>         
      </div>          
    </div>
    </div>
    </div>
    </form>
</body>
</html>
