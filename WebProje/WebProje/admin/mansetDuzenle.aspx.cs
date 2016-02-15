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
    public partial class mansetDuzenle : System.Web.UI.Page
    {
        public static ArrayList lsd = new ArrayList();
        string yID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            DB db = new DB();
            txtBaslik.Text = "";
            txtResimAdi.Text = "";
            txtAciklama.Text = "";
            lsd.Clear();
            yID = Request.QueryString["yerlesimID"].ToString();
            if (Request.QueryString["yerlesimID"] != null)
            {
                SqlDataReader rd = db.dataGetir("yerlesimDuzenle where yerlesimID= '" + yID + "'");
                while (rd.Read())
                {
                    txtBaslik.Text = rd["baslik"].ToString();
                    txtResimAdi.Text = rd["resimYol"].ToString();
                    txtAciklama.Text = rd["aciklama"].ToString();

                    pYerlesimDuzenle rs = new pYerlesimDuzenle();
                    rs.YerlesimID = rd["yerlesimID"].ToString();
                    rs.Baslik = rd["baslik"].ToString();
                    rs.ResimYol = rd["resimYol"].ToString();
                    rs.Aciklama = rd["aciklama"].ToString();
                    rs.Tarih = rd["tarih"].ToString();
                    lsd.Add(rs);
                }
            }
            else
            {
                // yönlendirme yap
                Response.Redirect("yerlesimDuzenle.aspx");
            }
            db.kapat();
        }

        protected void btnDuzenle_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            string baslik = txtBaslik.Text;
            string resim = txtResimAdi.Text;
            string aciklama = txtAciklama.Text;
            //string tarih = txtTarih.Text;
            HttpPostedFile yukleDosya = fluDosya.PostedFile;
            if (yukleDosya != null)
            {
                FileInfo dosyaBilgi = new FileInfo(yukleDosya.FileName);
                string path = "../resimler/";
                if (resim != dosyaBilgi.Name)
                {
                    string yukleYer = Server.MapPath(path + dosyaBilgi.Name);
                    fluDosya.SaveAs(yukleYer);
                    resim = dosyaBilgi.Name;
                }
            }
            SqlCommand cm = new SqlCommand("update yerlesimDuzenle set baslik= '" + baslik + "', resimYol= '" + resim + "', aciklama= '" + aciklama + "', tarih= getdate() where yerlesimID= '" + yID + "' ", db.conn);
            db.ac();
            int sonuc = cm.ExecuteNonQuery();
            if (sonuc > 0)
            {
                Response.Redirect("yerlesimDuzenle.aspx");
            }

            db.kapat();
        }
    }
}