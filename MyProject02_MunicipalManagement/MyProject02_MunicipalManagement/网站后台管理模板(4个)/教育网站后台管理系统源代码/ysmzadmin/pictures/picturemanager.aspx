<%@ Page Language="C#" AutoEventWireup="true" CodeFile="picturemanager.aspx.cs" Inherits="ysmzadmin_pictures_picturemanager" %>
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
         <div class="houtai_right_title">芙蓉特色图片管理</div>
         <div class="houtai_right_pic">
           <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ysmzadmin/pictures/addpicture.aspx">添加图片</asp:HyperLink>      
         </div>   
         <div class="houtai_right_pic1"><asp:GridView ID="pic_GridView" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" Width="626px" OnPageIndexChanging="pic_GridView_PageIndexChanging" OnRowDeleting="pic_GridView_RowDeleting" OnRowDataBound="pic_GridView_RowDataBound">
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
                     <ItemStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                     <HeaderStyle BackColor="SlateGray" />
                 </asp:HyperLinkField>
                 <asp:CommandField HeaderText="删除" ShowDeleteButton="True">
                     <HeaderStyle BackColor="SlateGray" />
                     <ItemStyle ForeColor="Red" Height="25px" HorizontalAlign="Center" VerticalAlign="Middle"
                         Width="80px" />
                 </asp:CommandField>
             </Columns>
             <HeaderStyle ForeColor="White" Height="25px" VerticalAlign="Middle" />
             <PagerStyle HorizontalAlign="Center" />
          </asp:GridView>           
        </div>
            
        <div>
            &nbsp;</div>          
    </div>
    </div>
    </div>
    </form>
</body>
</html>
