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

public partial class ysmzadmin_guanggao_updateguanggao : System.Web.UI.Page
{
    protected string pagetitle;
    oledata dt = new oledata();
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

        this.p_add.Enabled = false;
        DataSet dset = null;
        dset = dt.getdataset("select * from guanggao where id=" + Request["id"], "guanggao");
        DataRowView row = dset.Tables["guanggao"].DefaultView[0];
        p_txt.Text = row["guanggaourl"].ToString();
        try
        {
            this.Image1.ImageUrl = p_txt.Text;
        }
        catch
        {
            Response.Write("<script language=javascript> alert('图片显示失败！');location='updateguanggao.aspx'</script>");
        }
    }
    protected void p_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("guanggaomanager.aspx");
    }
    protected void p_edit_Click(object sender, EventArgs e)
    {
        if(this.p_File1.PostedFile.FileName=="")
        {
            Response.Write("<script language=javascript> alert('请选择要上传的文件！');location='javascript:history.go(-1)'</script>");
        }
        else
        {
            FileInfo info = new FileInfo(Server.MapPath(p_txt.Text.ToString()));
            info.Delete();
            string p_filename = "", p_fileexename = "", m_filename, m_filepath;
            if ("" != this.p_File1.PostedFile.FileName)
            {
                p_filename = this.p_File1.PostedFile.FileName;
                p_fileexename = p_filename.Substring(p_filename.LastIndexOf(".") + 1);
                try
                {
                    m_filepath = Server.MapPath("../updateimage/");
                    m_filename = p_filename.Substring(p_filename.LastIndexOf("\\") + 1);
                    p_File1.PostedFile.SaveAs(m_filepath + m_filename);
                    p_txt.Text = "../updateimage/" + m_filename;
                    this.p_txt.Visible = true;
                }
                catch (Exception err)
                {
                    Response.Write(err.ToString());
                }
            }
        } 
        bool ol = dt.excutesql("update guanggao set guanggaourl='" + p_txt.Text + "' where id=" + Request["id"]);
        if (ol == true)
        {
            Response.Write("<script language=javascript> alert('更新广告成功！');location='guanggaomanager.aspx'</script>");
        }
        else
        {
            Response.Write("<script language=javascript> alert('更新广告失败！');location='javascript:history.go(-1)'</script>");
        }
    }
}
