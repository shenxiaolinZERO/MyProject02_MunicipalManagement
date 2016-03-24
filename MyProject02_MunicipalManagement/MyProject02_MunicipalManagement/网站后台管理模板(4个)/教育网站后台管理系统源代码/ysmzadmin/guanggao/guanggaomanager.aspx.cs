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

public partial class ysmzadmin_guanggao_guanggaomanager : System.Web.UI.Page
{
    protected string pagetitle;
    oledata ta = new oledata();
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

        string str = "select * from guanggao order by id desc";
        ta.executegridview(pic_GridView, str, "id");
    }

    protected void pic_GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        pic_GridView.PageIndex = e.NewPageIndex;
        pic_GridView.DataBind();
    }
    protected void pic_GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string sr = pic_GridView.DataKeys[e.RowIndex].Value.ToString();
        OleDbConnection le = new OleDbConnection(ConfigurationManager.AppSettings["constr"]);
        le.Open();
        OleDbCommand com = new OleDbCommand("delete from guanggao where id=" + sr, le);
        try
        {
            com.ExecuteNonQuery();
        }
        finally
        {
            le.Close();
        }
        OleDbConnection oe = new OleDbConnection(ConfigurationManager.AppSettings["constr"]);
        oe.Open();
        OleDbDataAdapter db = new OleDbDataAdapter("select * from guanggao order by id desc", oe);
        DataSet ds = new DataSet();
        db.Fill(ds);
        pic_GridView.DataSource = ds;
        pic_GridView.DataBind();
        oe.Close();
    }
    protected void pic_GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ((LinkButton)(e.Row.Cells[3].Controls[0])).Attributes.Add("onclick", "return confirm('确定要删除吗？')");
        }
    }
}
