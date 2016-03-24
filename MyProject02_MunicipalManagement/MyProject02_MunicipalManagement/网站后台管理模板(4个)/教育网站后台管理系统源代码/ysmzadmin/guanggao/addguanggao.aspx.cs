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

public partial class ysmzadmin_guanggao_addguanggao : System.Web.UI.Page
{
    protected string pagetitle;
    oledata tai = new oledata();
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

        this.btnupdate.Enabled = false;
        string str = "select * from guanggao order by id desc";
        OleDbConnection ole = new OleDbConnection(ConfigurationManager.AppSettings["constr"]);
        ole.Open();
        OleDbDataAdapter db = new OleDbDataAdapter(str, ole);
        DataSet ds = new DataSet();
        db.Fill(ds);
        this.guang_GridView.DataSource = ds;
        this.guang_GridView.DataBind();
        guang_GridView.Enabled = false;
        ole.Close();
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        string filepath = "";
        string fileexename = "";
        string mfilename, mpath;
        if ("" != this.upimage.PostedFile.FileName)
        {
            filepath = upimage.PostedFile.FileName;
            fileexename = filepath.Substring(filepath.LastIndexOf(".") + 1);
            try
            {
                mpath = Server.MapPath("../updateimage/");
                mfilename = filepath.Substring(filepath.LastIndexOf("\\") + 1);
                upimage.PostedFile.SaveAs(mpath + mfilename);
                this.pictxt.Text = "../updateimage/" + mfilename;
                this.pictxt.Visible = true;
            }
            catch (Exception err)
            {
                Response.Write(err.ToString());
            }
            string xx = "insert into guanggao(guanggaourl)values('" + pictxt.Text + "')";
            OleDbConnection cx = new OleDbConnection(ConfigurationManager.AppSettings["constr"]);
            cx.Open();
            OleDbCommand com = new OleDbCommand(xx, cx);
            try
            {
                com.ExecuteNonQuery();
            }
            finally
            {
                cx.Close();
            }
            Response.Write("<script language=javascript> alert('提交广告成功！');location='guanggaomanager.aspx'</script>");
        }
        else
        {
            Response.Write("<script language=javascript> alert('请选择上传的广告！');location='javascript:history.go(-1)'</script>");
        }
    }
    protected void backet_Click(object sender, EventArgs e)
    {
        Response.Redirect("guanggaomanager.aspx");
    }
}
