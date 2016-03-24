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

public partial class ysmzadmin_boarder_updateboardmanage : System.Web.UI.Page
{
    protected string pagetitle;
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

        if (Page.IsPostBack == false)
        {
            OleDbConnection conn = new OleDbConnection(ConfigurationManager.AppSettings["constr"]);
            conn.Open();
            OleDbDataAdapter odt = new OleDbDataAdapter("select * from gonggao where gonggaoid=" + Request["gonggaoid"], conn);
            DataSet ds = new DataSet();
            odt.Fill(ds, "gonggao");
            DataRowView row = ds.Tables["gonggao"].DefaultView[0];
            titletext_up.Text = Convert.ToString(row["title"]);
            nametext_up.Text = Convert.ToString(row["author"]);
            gonggaocentent_up.Text = Convert.ToString(row["centents"]);
            conn.Close();
        }
    }

    protected void gonggaoreset_Click(object sender, EventArgs e)
    {
        this.titletext_up.Text = "";
        this.titletext_up.Focus();
        this.nametext_up.Text = "";
        this.gonggaocentent_up.Text = "";
    }
  
    protected void goback_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("boarderinfo.aspx");
    }
    protected void gonggao_up_Click(object sender, EventArgs e)
    {
        string strg = "update gonggao set title='" + titletext_up.Text + "',author='" + nametext_up.Text + "',centents='" + gonggaocentent_up.Text + "' where gonggaoid="+Request.QueryString["gonggaoid"];
        oledata odt = new oledata();
        bool bl = odt.excutesql(strg);
        if (bl == true)
        {
            Response.Write("<script language=javascript>alert('恭喜你，修改成功！');loaction='boarderinfo.aspx'</script>");
            Page_Load(sender, e);
        }
        else
        {
            Response.Write("<script language=javascript>alert('对不起，修改失败！');loaction='javascript:history.go.(-1)'</script>");
        }
    }
}
