<%@ Page Language="C#" AutoEventWireup="true" CodeFile="boarderinfo.aspx.cs" Inherits="ysmzadmin_boarder_boarderinfo" %>
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
        <div class="houtai_left"><uc1:userleft ID="Userleft1" runat="server" /></div>
        <div class="houtai_right">
         <div class="houtai_right_title">芙蓉特色公告管理</div>
         <div class="houtai_right_gonggao1"><asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/ysmzadmin/boarder/boardmanage.aspx">添加公告</asp:LinkButton></div>
         <div class="houtai_right_gonggao2"><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GridView1_RowDataBound" Width="628px">
             <Columns>
                 <asp:BoundField DataField="gonggaoid" HeaderText="ID序列号">
                     <ItemStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                     <HeaderStyle BackColor="SlateGray" />
                 </asp:BoundField>
                 <asp:BoundField DataField="title" HeaderText="公 告 标 题">
                     <ItemStyle Height="25px" HorizontalAlign="Justify" VerticalAlign="Middle" />
                     <HeaderStyle BackColor="SlateGray" />
                 </asp:BoundField>
                 <asp:BoundField DataField="author" HeaderText="发布者">
                     <ItemStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                     <HeaderStyle BackColor="SlateGray" />
                 </asp:BoundField>
                 <asp:HyperLinkField DataNavigateUrlFields="gonggaoid" DataNavigateUrlFormatString="updateboardmanage.aspx?gonggaoid={0}"
                     HeaderText="编辑" Text="编辑">
                     <ItemStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                     <HeaderStyle BackColor="SlateGray" />
                 </asp:HyperLinkField>
                 <asp:CommandField HeaderText="删除" ShowDeleteButton="True">
                     <ItemStyle ForeColor="Red" Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                     <HeaderStyle BackColor="SlateGray" />
                 </asp:CommandField>
             </Columns>
             <RowStyle Height="25px" />
             <PagerStyle HorizontalAlign="Center" />
             <HeaderStyle Height="25px" Font-Bold="True" ForeColor="White" />
         </asp:GridView>
         </div>         
        </div>
      </div>
    </div>
    </form>
</body>
</html>
