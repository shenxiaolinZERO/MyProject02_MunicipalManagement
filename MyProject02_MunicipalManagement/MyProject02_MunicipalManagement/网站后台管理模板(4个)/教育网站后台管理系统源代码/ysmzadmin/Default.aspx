<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="ysmzadmin_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title><%=pagetitle%></title>
    <link href="../skin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="bg">
       <div class="pagebody">
          <div class="label_1"><asp:Label ID="Label1" runat="server" Text="用户名：" Font-Bold="True" Height="15px"></asp:Label></div>          
          <div class="textbox_1"><asp:TextBox ID="TextBox1" runat="server" Height="15px" ToolTip="在此输入用户名！" Width="130px" BackColor="AntiqueWhite" BorderColor="ControlLight" BorderStyle="Inset"></asp:TextBox></div>
          <div class="label_2"><asp:Label ID="Label2" runat="server" Text="密　码：" Font-Bold="True" Height="15px"></asp:Label></div>
          <div class="textbox_2"><asp:TextBox ID="TextBox2" runat="server" Width="130px" Height="15px" ToolTip="在此输入密码！" BackColor="AntiqueWhite" BorderColor="ControlLight" BorderStyle="Inset" TextMode="Password"></asp:TextBox></div>
          <div class="label_3"><asp:Label ID="Label3" runat="server" Text="验证码：" Font-Bold="True"></asp:Label></div>
          <div class="textbox_3"><asp:TextBox ID="t3" runat="server" Width="76px" Height="15px" ToolTip="在此输入验证码！" BackColor="AntiqueWhite" BorderColor="ControlLight" BorderStyle="Inset"></asp:TextBox></div>
          <div class="label_4"><asp:Label ID="b4" runat="server" Text="Label" ForeColor="Red"></asp:Label></div>          
       </div>
       <div class="pagebody">
          <div class="ok"><asp:Button ID="Button1" runat="server" Text="登　录" BackColor="#D4E8ED" BorderColor="#D4E8ED" Font-Bold="True" Font-Size="10pt"  ForeColor="Blue" Height="25px" OnClick="Button1_Click" /></div>
          <div class="back"><asp:Button ID="Button2" runat="server" Text="返　回" BackColor="#D4E8ED" BorderColor="#D4E8ED" Font-Bold="True"  ForeColor="Blue" Height="25px" OnClick="Button2_Click" Font-Size="10pt"/></div>         
       </div>
    </div>              
    </form>    
</body>
</html>
