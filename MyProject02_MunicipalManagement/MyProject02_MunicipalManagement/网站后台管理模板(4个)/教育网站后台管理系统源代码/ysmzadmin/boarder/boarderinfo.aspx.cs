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

public partial class ysmzadmin_boarder_boarderinfo : System.Web.UI.Page
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

            string str = "select * from gonggao order by gonggaoid desc";
            oledata od = new oledata();
            od.executegridview(GridView1, str, "gonggaoid");
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }
 
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        oledata ole = new oledata();
        string str = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
        ole.excutesql("delete from gonggao where gonggaoid="+str);
        ole.executedatabind(GridView1,"select * from gonggao order by gonggaoid desc");
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ((LinkButton)(e.Row.Cells[4].Controls[0])).Attributes.Add("onclick", "return confirm('确定要删除吗？')");
        }
    }
}
