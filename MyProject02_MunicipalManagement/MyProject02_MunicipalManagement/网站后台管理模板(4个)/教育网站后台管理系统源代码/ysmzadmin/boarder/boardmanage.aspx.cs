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

public partial class ysmzadmin_boarder_boardmanage : System.Web.UI.Page
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
    }

    protected void gonggaoreset_Click(object sender, EventArgs e)
    {
        this.titletext.Text = "";
        this.titletext.Focus();
        this.nametext.Text = "";
        this.gonggaocentent.Text = "";
    }
    protected void gonggaook_Click(object sender, EventArgs e)
    {
        if (titletext.Text != "" && nametext.Text != "" && gonggaocentent.Text != "")
        {
            string str = "insert into gonggao(title,author,centents) values('" + titletext.Text + "','" + nametext.Text + "','" + gonggaocentent.Text + "')";
            oledata od = new oledata();
            bool gonggao = od.excutesql(str);
            if (gonggao == true)
            {
                Response.Write("<script language=javascript>alert('保存成功！');location='boardmanage.aspx'</script>");
                Page_Load(sender, e);
            }
            else
            {
                Response.Write("<script language=javascript>alert('保存失败！');loaction='javascript:history.go(-1)'</script>");
            }            
        }
        else
        {
            Response.Write("<script language=javascript>alert('不允许为空！');location='boardmanage.aspx'</script>");
        }
    }
    protected void goback_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("boarderinfo.aspx");
    }
}
