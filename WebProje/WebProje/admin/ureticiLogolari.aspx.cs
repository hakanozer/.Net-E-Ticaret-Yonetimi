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
    public partial class ureticiLogolari : System.Web.UI.Page
    {
        public ArrayList logoList = new ArrayList();
        DB db = new DB();
        ureticiler u = new ureticiler();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["ureticiID"] != null)
            {
                IdyeGoreUreticiGetir(Request.QueryString["ureticiID"]);
            }
            else
            {
                // yönlendirme yap
                Response.Redirect("ureticiler.aspx");
            }
        }

        private void IdyeGoreUreticiGetir(string asdf)
        {
            // resimleri getir
            SqlDataReader rd = db.dataGetir("ureticiler where ureticiID = '" + asdf + "'");

            while (rd.Read())
            {
                pUreticiler ur = new pUreticiler();
                ur.UreticiID = Convert.ToInt32(rd["ureticiID"]);
                ur.UreticiAdi = rd["ureticiAdi"].ToString();
                ur.LogoAdi = rd["logoAdi"].ToString();
                ur.Tarih = Convert.ToDateTime(rd["tarih"]);
                logoList.Add(ur);

            }
            db.kapat();
        }
        protected void btnYukle_Click(object sender, EventArgs e)
        {
            string ureticiID = Request.QueryString["ureticiID"].ToString();
            string logoAdi = "";
            string ureticiAdi = "";
            HttpPostedFile yukleDosya = fluDosyaLogo.PostedFile;
            if (yukleDosya.FileName == "")
            {
                logoAdi = Request.QueryString["logoAdi"].ToString();

            }
            else
            { // veritabanına yaz
                Random rdn = new Random();
                FileInfo dosyaBilgi = new FileInfo(yukleDosya.FileName);
                logoAdi = dosyaBilgi.Name;
                string path = "../resimler/";
                string yukleYer = Server.MapPath(path + logoAdi);
                fluDosyaLogo.SaveAs(yukleYer);
            }
            if (adi.Text != "")
            {
                ureticiAdi = adi.Text;
            }
            else
            {
                ureticiAdi = Request.QueryString["ureticiAdi"].ToString();
            }
            //try
            //{
            //    if (adi.Text == "")
            //    {
            //        throw new Exception("üretici adını boş bırakmayınız ");
            //    }
            db.ac();
            SqlCommand cm = new SqlCommand("UPDATE ureticiler SET ureticiAdi='" + ureticiAdi + "', logoAdi='" + logoAdi + "' , tarih=getDate() WHERE  ureticiID='" + ureticiID + "'", db.conn);

            int sonuc = cm.ExecuteNonQuery();
            db.kapat();
            if (sonuc > 0)
            {
                // başarılı
                Response.Redirect("ureticiLogolari.aspx?ureticiID=" + ureticiID +
                                    "&ureticiAdi= " + Request.QueryString["ureticiAdi"].ToString() +
                                    "&logoAdi=" + Request.QueryString["logoAdi"].ToString());


                string guncelle = "GÜNCELLEME İŞLEMİ BAŞARILI";
                Response.Write("<script>alert('" + guncelle + "')</script>");
            }
            //}
            //catch (Exception er)
            //{
            //    Response.Write("<script>alert('"+er.Message+"')</script>");
            //}



        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}