﻿ <%@ Page Language="C#" AutoEventWireup="true" CodeFile="articlemanager.aspx.cs" Inherits="ysmzadmin_article_articlemanager" %>
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
         <div class="houtai_right_title">芙蓉特色管理信息</div>
         <div class="houtai_right_pic">
         <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ysmzadmin/article/articleadd.aspx">添加文章</asp:HyperLink>
        </div>
            
        <div class="houtai_right_pic1">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" Width="628px" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:BoundField DataField="articleid" HeaderText="ID号">
                    <ItemStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                    <HeaderStyle BackColor="SlateGray" />
                </asp:BoundField>
                <asp:BoundField DataField="articlecolumn" HeaderText="类别">
                    <ItemStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                    <HeaderStyle BackColor="SlateGray" />
                </asp:BoundField>
                <asp:BoundField DataField="articletitle" HeaderText="文　章　标　题">
                    <ItemStyle Height="25px" VerticalAlign="Middle" />
                    <HeaderStyle BackColor="SlateGray" />
                </asp:BoundField>
                <asp:BoundField DataField="articletime" HeaderText="录入时间">
                    <ItemStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                    <HeaderStyle BackColor="SlateGray" />
                </asp:BoundField>
                <asp:HyperLinkField DataNavigateUrlFields="articleid" DataNavigateUrlFormatString="updatearticle.aspx?articleid={0}"
                    HeaderText="编辑" Text="编辑">
                    <ItemStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" Width="40px" />
                    <HeaderStyle BackColor="SlateGray" />
                </asp:HyperLinkField>
                <asp:CommandField HeaderText="删除" ShowDeleteButton="True">
                    <HeaderStyle BackColor="SlateGray" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40px" ForeColor="Red" />
                </asp:CommandField>
            </Columns>
            <HeaderStyle ForeColor="White" Height="30px" />
            <PagerStyle HorizontalAlign="Center" />
        </asp:GridView>
      </div>          
            
    </div>
    </div>
    </div>
    </form>
</body>
</html>
