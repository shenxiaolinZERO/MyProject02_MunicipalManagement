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

public partial class ysmzadmin_article_articlemanager : System.Web.UI.Page
{
    protected string pagetitle;
    oledata olet = new oledata();
    protected void Page_Load(object sender, EventArgs e)
    {
     
        string strsql = "select * from baseinfo";
        OleDbConnection ll = new OleDbConnection(ConfigurationManager.AppSettings["constr"]);
        ll.Open();
        OleDbDataAdapter da = new OleDbDataAdapter(strsql, ll);
        DataSet ds = new DataSet();
        da.Fill(ds,"baseinfo");
        DataRowView view = ds.Tables["baseinfo"].DefaultView[0];
        pagetitle = Convert.ToString(view["sitename"]) + Convert.ToString(view["programer"]);
        ll.Close();


            olet.executegridview(GridView1, "select * from newsarticle order by articleid desc", "articleid");
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string strt = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
        OleDbConnection ol = new OleDbConnection(ConfigurationManager.AppSettings["constr"]);
        ol.Open();
        OleDbCommand com = new OleDbCommand("delete from newsarticle where articleid=" + strt, ol);
        com.ExecuteNonQuery();
        ol.Close();
        OleDbConnection olb = new OleDbConnection(ConfigurationManager.AppSettings["constr"]);
        olb.Open();
        OleDbDataAdapter db = new OleDbDataAdapter("select * from newsarticle order by articleid desc", olb);
        DataSet ds = new DataSet();
        db.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
        olb.Close();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ((LinkButton)(e.Row.Cells[5].Controls[0])).Attributes.Add("onclick", "return confirm('确定要删除吗？')");
        }
    }
}
