using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.IO;



namespace WebProje.admin
{
    public partial class admin : System.Web.UI.MasterPage
    {
        DB db = new DB();

        protected void Page_Load(object sender, EventArgs e)
        {

            // giriş kontrolü yapılıyor
            if (Session["adminID"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            db.ac();
            // database den resimin PathOnDisk (ProfilImages tablosunda kolon adı ) PathOnDisk)  ini al
            SqlCommand sorgu = new SqlCommand("select top 1 PathOnDisk  from ProfilImages order by id desc", db.conn);
            SqlDataReader rd = sorgu.ExecuteReader();
            while (rd.Read())
            {
                imgProfil.Src = "../resimler/" + rd["PathOnDisk"].ToString();
            }
            db.kapat();
        }


        protected void Application_Start(object sender, EventArgs e)
        {
            string JQueryVer = "1.7.1";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/Scripts/jquery-" + JQueryVer + ".min.js",
                DebugPath = "~/Scripts/jquery-" + JQueryVer + ".js",
                CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + JQueryVer + ".min.js",
                CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + JQueryVer + ".js",
                CdnSupportsSecureConnection = true,
                LoadSuccessExpression = "window.jQuery"
            });
        }

        protected void btnUploadImage_Click(object sender, EventArgs e)
        {
            HttpPostedFile yukleDosya = fuImage.PostedFile;
            if (yukleDosya.FileName != "")
            {
                FileInfo dosyaBilgi = new FileInfo(yukleDosya.FileName);
                string extenxion = Path.GetExtension(fuImage.FileName);
                string newFileName = Guid.NewGuid() + extenxion;
                string fullpath = @"../resimler/";//yüklenicek yol
                string yukleYer = Server.MapPath(fullpath + newFileName);//yuklenicek yer
                fuImage.SaveAs(yukleYer);
                db.ac();
                SqlCommand cm = new SqlCommand("insert into ProfilImages values('" + newFileName + "')", db.conn);
                int sonuc = cm.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    //başarılı
                    Response.Redirect("admin.aspx?PathOnDisk=" + newFileName + "");
                }
                db.kapat();
            }
        }

    }
}