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

public partial class ysmzadmin_article_updateclass : System.Web.UI.Page
{
    protected string pagetitle;
    oledata ole = new oledata();
    protected void Page_Load(object sender, EventArgs e)
    {
  
        string strsql = "select * from baseinfo";
        OleDbConnection ll = new OleDbConnection(ConfigurationManager.AppSettings["constr"]);
        ll.Open();
        OleDbDataAdapter da = new OleDbDataAdapter(strsql, ll);
        DataSet dse = new DataSet();
        da.Fill(dse, "baseinfo");
        DataRowView view = dse.Tables["baseinfo"].DefaultView[0];
        pagetitle = Convert.ToString(view["sitename"]) + Convert.ToString(view["programer"]);
        ll.Close();

        if (!IsPostBack)
        {
            this.e_add.Enabled = false;
            ole.executegridview(GridView1, "select * from newscolumn", "columnid");
            this.GridView1.Enabled = false;
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.AppSettings["constr"]);
            connection.Open();
            OleDbDataAdapter db = new OleDbDataAdapter("select * from newscolumn where columnid=" + Request["columnid"], connection);
            DataSet ds = new DataSet();
            db.Fill(ds, "newscolumn");
            DataRowView row = ds.Tables["newscolumn"].DefaultView[0];
            this.TextBox1.Text = Convert.ToString(row["columntitle"]);
            connection.Close();
        }
    }
    protected void e_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("classmanager.aspx");
    }
    protected void e_edit_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "")
        {
            Response.Write("<script language=javascript>alert('对不起，修改文本框不能为空！');location='javascript:history.go(-1)'</script>");
        }
        else
        {
            this.TextBox2.Text = Convert.ToString(DateTime.Now);
            string str = "update newscolumn set columntitle='" + TextBox1.Text + "',columntime='" + TextBox2.Text + "' where columnid=" + Request.QueryString["columnid"];
            bool oo = ole.excutesql(str);
            if (oo == true)
            {
                Response.Write("<script language=javascript>alert('恭喜恭喜，修改成功！');location='classmanager.aspx'</script>");
            }
            else
            {
                Response.Write("<script language=javascript>alert('对不起，修改失败！');location='javascript:history.go(-1)'</script>");
            }
        }
    }
}
