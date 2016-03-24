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

public partial class ysmzadmin_baseinfo_baseinfo : System.Web.UI.Page
{
    protected string pagetitle;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
            {

                string strsql = "select * from baseinfo";
                OleDbConnection ll = new OleDbConnection(ConfigurationManager.AppSettings["constr"]);
                ll.Open();
                OleDbDataAdapter dw = new OleDbDataAdapter(strsql, ll);
                DataSet ds = new DataSet();
                dw.Fill(ds, "baseinfo");
                DataRowView view = ds.Tables["baseinfo"].DefaultView[0];
                pagetitle = Convert.ToString(view["sitename"]) + Convert.ToString(view["programer"]);
                ll.Close();

                oledata da = new oledata();
                OleDbDataReader drd = da.executeread("select * from baseinfo");
                drd.Read();
                if (drd.HasRows)
                {
                    this.sitenamebox.Text = drd["sitename"].ToString();
                    this.siteadressbox.Text = drd["siteadress"].ToString();
                    this.sitepostbox.Text = drd["sitepost"].ToString();
                    this.programerbox.Text = drd["programer"].ToString();
                    this.logotxt.Text = drd["logopic"].ToString();
                    this.banbenbox.Text = drd["banben"].ToString();
                    this.save.Enabled = false;

                }
                else
                {
                    this.save.Enabled = true;
                    this.reset.Enabled = false;
                }
                drd.Close();
            }
        }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string filepath = "";
        string fileexename = "";
        string mfilename, mpath;
        if (logotxt.Text == "")    //判断原有LOGO是否存在
        {
            if (this.File1.PostedFile.FileName == "")    //判断原有现在LOGO是否有地址
            {

                string m_updatestr = "update baseinfo set sitename='" + sitenamebox.Text + "',siteadress='"
                + siteadressbox.Text + "',sitepost='" + sitepostbox.Text + "',programer='" + programerbox.Text
                + "',banben='" + banbenbox.Text + "'";
                oledata oda = new oledata();
                oda.excutesql(m_updatestr);              
                Response.Write("<script language=javascript>alert('修改成功！');location='baseinfo.aspx'</script>");
                Page_Load(sender, e);
            }
            else
            {
                filepath = File1.PostedFile.FileName;
                fileexename = filepath.Substring(filepath.LastIndexOf(".") + 1);
                try
                {
                    mpath = Server.MapPath("../image/");
                    mfilename = filepath.Substring(filepath.LastIndexOf("\\") + 1);
                    File1.PostedFile.SaveAs(mpath + mfilename);                       //保存图片
                    this.TextBox1.Text = "../image/" + mfilename;
                    this.TextBox1.Visible = true;
                }
                catch (Exception err)
                {
                    Response.Write(err.ToString());
                }
                string m_updatestr = "update baseinfo set sitename='" + sitenamebox.Text + "',siteadress='"
               + siteadressbox.Text + "',sitepost='" + sitepostbox.Text + "',programer='" + programerbox.Text
               + "',logopic='" + TextBox1.Text + "',banben='" + banbenbox.Text + "'";
                oledata oda = new oledata();
                oda.excutesql(m_updatestr);
                Response.Write("<script language=javascript>alert('修改成功！');location='baseinfo.aspx'</script>");
                Page_Load(sender, e);
            }
        }
        else
        {

            if (this.File1.PostedFile.FileName == "")
            {

                string m_updatestr = "update baseinfo set sitename='" + sitenamebox.Text + "',siteadress='"
                + siteadressbox.Text + "',sitepost='" + sitepostbox.Text + "',programer='" + programerbox.Text
                + "',banben='" + banbenbox.Text + "'";
                oledata oda = new oledata();
                oda.excutesql(m_updatestr);
                Response.Write("<script language=javascript>alert('修改成功！');location='baseinfo.aspx'</script>");
                Page_Load(sender, e);
            }
            else
            {
                FileInfo fi = new FileInfo(Server.MapPath(logotxt.Text.ToString()));
                fi.Delete();
                filepath = File1.PostedFile.FileName;
                fileexename = filepath.Substring(filepath.LastIndexOf(".") + 1);
                try
                {
                    mpath = Server.MapPath("../image/");
                    mfilename = filepath.Substring(filepath.LastIndexOf("\\") + 1);
                    File1.PostedFile.SaveAs(mpath + mfilename);
                    this.TextBox1.Text = "../image/" + mfilename;
                    this.TextBox1.Visible = true;
                }
                catch (Exception err)
                {
                    Response.Write(err.ToString());
                }
                string m_updatestr = "update baseinfo set sitename='" + sitenamebox.Text + "',siteadress='"
               + siteadressbox.Text + "',sitepost='" + sitepostbox.Text + "',programer='" + programerbox.Text
               + "',logopic='" + TextBox1.Text + "',banben='" + banbenbox.Text + "'";
                oledata oda = new oledata();
                oda.excutesql(m_updatestr);
                Response.Write("<script language=javascript>alert('修改成功！');location='baseinfo.aspx'</script>");
                Page_Load(sender, e);
               
            }

        }
    }

    protected void save_Click(object sender, EventArgs e)
    {
       
            string m_str = " insert into baseinfo(sitename,siteadress,sitepost,programer,logopic,banben) values ('"
            + sitenamebox.Text + "','" + siteadressbox.Text + "','" + sitepostbox.Text + "','" + programerbox.Text
            + "','" + TextBox1.Text + "','" + banbenbox.Text + "')";
            oledata oda = new oledata();
            bool bl = oda.excutesql(m_str);
            if (bl==true)
            {
                Response.Write("<script language=javascript>alert('保存成功！');location='baseinfo.aspx'</script>");
                Page_Load(sender, e);
            }
            else
            {
                Response.Write("<script language=javascript>alert('保存失败！');loaction='javascript:history.go(-1)'</script>");
            }  
    }
}
