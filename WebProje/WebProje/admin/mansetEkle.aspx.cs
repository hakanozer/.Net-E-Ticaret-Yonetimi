using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.IO;

namespace WebProje.admin
{
    public partial class mansetEkle : System.Web.UI.Page
    {
        ArrayList lsm = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {
            DB db = new DB();
            lsm.Clear();
            SqlDataReader rd = db.dataGetir("yerlesimDuzenle");
            while (rd.Read())
            {
                pYerlesimDuzenle y = new pYerlesimDuzenle();
                y.YerlesimID = rd["yerlesimID"].ToString();
                y.Baslik = rd["baslik"].ToString();
                y.ResimYol = rd["resimYol"].ToString();
                y.Aciklama = rd["aciklama"].ToString();
                y.Tarih = rd["tarih"].ToString();
                lsm.Add(y);
            }
            db.kapat();
        }
        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            DB db = new DB();
                db.ac();
                //string ID = Request.QueryString["id"].ToString();
                HttpPostedFile yukleDosya = fluDosya.PostedFile;
                if (yukleDosya != null)
                {
                    FileInfo dosyaBilgi = new FileInfo(yukleDosya.FileName);
                    string path = "../resimler/";
                    string yukleYer = Server.MapPath(path + dosyaBilgi.Name);
                    fluDosya.SaveAs(yukleYer);
                   
                    string dbaslik = txtbaslik.Text.Trim();
                    string daciklama = txtaciklama.Text.Trim();


                    SqlCommand cm = new SqlCommand("insert into yerlesimDuzenle values ('" + dbaslik + "', '" + dosyaBilgi.Name + "', '" + daciklama + "', getDate())", db.conn);
                    int sonuc = cm.ExecuteNonQuery();
                    if (sonuc > 0)
                    {
                        Response.Redirect("yerlesimDuzenle.aspx");
                    }
                    else
                    {
                        Response.Write("Kaydetme başarılı değil");
                    }
                }
                else
                {
                    Response.Write("Dosya seçilmedi");
                }
                db.kapat();
        }

    }
}