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

public partial class ysmzadmin_article_classmanager : System.Web.UI.Page
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

        oledata ol = new oledata();
        ol.executegridview(GridView1, "select * from newscolumn", "columnid");
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
        OleDbConnection con = new OleDbConnection(ConfigurationManager.AppSettings["constr"]);
        con.Open();
        string str = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
        OleDbCommand com = new OleDbCommand("delete from newscolumn where columnid=" + str, con);
        try
        {
            com.ExecuteNonQuery();
        }
        finally
        {
            con.Close();
        }
        OleDbConnection contion = new OleDbConnection(ConfigurationManager.AppSettings["constr"]);
        contion.Open();
        try
        {
            OleDbDataAdapter db = new OleDbDataAdapter("select * from newscolumn", contion);
            DataSet ds = new DataSet();
            db.Fill(ds, "newscolumn");
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        finally
        {
            contion.Close();
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ((LinkButton)(e.Row.Cells[4].Controls[0])).Attributes.Add("onclick", "return confirm('确定要删除吗？')");
        }
    }
}
