<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addclass.aspx.cs" Inherits="ysmzadmin_article_addclass" %>
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
         <div class="houtai_right_title">芙蓉特色添加类别</div>
         <div class="houtai_right_pic">
         <table style="width:100%; height:35px; border:1px solid #565656">
         <tr>
         <td style="width: 70px; padding-left:10px; vertical-align:middle; height: 34px;"><asp:Label ID="Label1" runat="server" Text="Label">添加类别：</asp:Label></td>
         <td style="width:290px; height: 34px;"><asp:TextBox ID="class_text" runat="server" Width="280px"></asp:TextBox></td>
         <td align="center" style="height: 34px"><asp:Button ID="class_add" runat="server" Text="添 加" Height="28px" OnClick="class_add_Click" /></td>
         <td align="center" style="height: 34px"><asp:Button ID="class_edit" runat="server" Text="修 改" Height="28px" /></td>
         <td align="center" style="height: 34px"><asp:Button ID="class_back" runat="server" Text="返 回" OnClick="class_back_Click" Height="28px" /></td>
         </tr>          
         </table>           
         </div>
         <div class="houtai_right_pic1">       
          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="628px" AllowPaging="True" PageSize="9">
              <Columns>
                  <asp:BoundField DataField="columnid" HeaderText="类ID号">
                      <ItemStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                      <HeaderStyle BackColor="SlateGray" ForeColor="White" />
                  </asp:BoundField>
                  <asp:BoundField DataField="columntitle" HeaderText="类　别　标　题">
                      <ItemStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                      <HeaderStyle BackColor="SlateGray" ForeColor="White" />
                  </asp:BoundField>
                  <asp:HyperLinkField DataNavigateUrlFields="columnid" DataNavigateUrlFormatString="updateclass?columnid={0}"
                      HeaderText="编辑" Text="编辑">
                      <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" Height="25px" />
                      <HeaderStyle BackColor="SlateGray" ForeColor="White" />
                  </asp:HyperLinkField>
                  <asp:BoundField DataField="columntime" HeaderText="添加时间">
                      <ItemStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                      <HeaderStyle BackColor="SlateGray" ForeColor="White" />
                  </asp:BoundField>
                  <asp:CommandField HeaderText="删除" ShowDeleteButton="True">
                      <HeaderStyle BackColor="SlateGray" ForeColor="White" />
                      <ItemStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                  </asp:CommandField>
              </Columns>
              <PagerStyle HorizontalAlign="Center" />
              <HeaderStyle Height="30px" />
          </asp:GridView>
         </div>    
      </div>
    </div>
    </form>
</body>
</html>

