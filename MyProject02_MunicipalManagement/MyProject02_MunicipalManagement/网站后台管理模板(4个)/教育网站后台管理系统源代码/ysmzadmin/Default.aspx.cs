using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.IO;

public partial class ysmzadmin_login : System.Web.UI.Page
{
    protected string pagetitle;
    protected void Page_Load(object sender, EventArgs e)
    {
      
        string strsql = "select * from baseinfo";
        OleDbConnection ll = new OleDbConnection(ConfigurationManager.AppSettings["constr"]);
        ll.Open();
        OleDbDataAdapter da = new OleDbDataAdapter(strsql, ll);
        DataSet ds = new DataSet();
        da.Fill(ds, "baseinfo");
        DataRowView view = ds.Tables["baseinfo"].DefaultView[0];
        pagetitle = Convert.ToString(view["sitename"]) + Convert.ToString(view["programer"]);
        ll.Close();


        if(!IsPostBack)
        {
        Random ra = new Random();
        b4.Text = ra.Next(10000, 99999).ToString();
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.t3.Text != this.b4.Text)
        {
            Response.Write("<script lanuage=javescript>alert('验证码错误！');location='javascript:history.go(-1)'</script>");
           
        }
        else
        {
            
            OleDbConnection con = new OleDbConnection(ConfigurationManager.AppSettings["constr"]);
            con.Open();
            OleDbCommand com = new OleDbCommand("select * from newsuser where username='" + this.TextBox1.Text + "' and userpwd='" + this.TextBox2.Text + "'", con);
            int count = Convert.ToInt32(com.ExecuteScalar());
            if (count > 0)
            {
                Page.Response.Redirect("~/ysmzadmin/baseinfo/baseinfo.aspx");
            }
            else
            {
                Response.Write("<script lanuage=javescript>alert('用户名或密码错误！');location='javascript:history.go(-1)'</script>");
                return;
            }
            con.Close();
        }
    }
}
