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
    public partial class ureticiler : System.Web.UI.Page
    {
        public ArrayList lst = new ArrayList();
        DB db = new DB();

        protected void Page_Load(object sender, EventArgs e)
        {

            lst.Clear();

            SqlDataReader rd = db.dataGetir("ureticiler");
            while (rd.Read())
            {
                pUreticiler ur = new pUreticiler();
                ur.UreticiID = Convert.ToInt32(rd["ureticiID"]);
                ur.UreticiAdi = rd["ureticiAdi"].ToString();
                ur.LogoAdi = rd["logoAdi"].ToString();

                ur.Tarih = Convert.ToDateTime(rd["tarih"]);
                lst.Add(ur);


            }
            db.kapat();
            if (Request.QueryString["ureticiID"] != null)
            {
                sil();
            }
        }
        private void sil()
        {
            db.ac();
            string id = Request.QueryString["ureticiID"].ToString();
            // veritabanında da bu bilgileri sil
            SqlCommand cm = new SqlCommand("delete from ureticiler where ureticiID = '" + id + "'", db.conn);
            int silSonuc = cm.ExecuteNonQuery();
            db.kapat();
            if (silSonuc > 0)
            {
                // silme başarılı
               
                Response.Redirect("ureticiler.aspx");
                string silme = "SİLME İŞLEMİ BAŞARILI";
                Response.Write("<script>alert('" + silme + "')</script>");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox2.Text == "")
                {
                    throw new Exception("Üretici adını boş bırakmayın ");
                }

                try
                {
                    if (FileUpload1==null)
                    {
                        throw new Exception("Lütfen Logo Seçiniz");

                    }

                }
                catch (Exception ex)
                {

                    Response.Write("<script>alert('" + ex.Message + "')</script>");
                }

                string ureticiAdi = TextBox2.Text;
                HttpPostedFile yukleDosya = FileUpload1.PostedFile;
                if (yukleDosya != null)
                {
                    Random rdn = new Random();
                    FileInfo dosyaBilgi = new FileInfo(yukleDosya.FileName);
                    string resimIsim = dosyaBilgi.Name;
                    string path = "../resimler/";
                    string yukleYer = Server.MapPath(path + resimIsim);
                    FileUpload1.SaveAs(yukleYer);

                    // veritabanına yaz
                    db.ac();
                    SqlCommand cm = new SqlCommand("insert into ureticiler values('" + ureticiAdi + "', '" + resimIsim + "', getDate())", db.conn);
                    int sonuc = cm.ExecuteNonQuery();
                    if (sonuc > 0)
                    {
                        // başarılı
                         Response.Redirect("ureticiler.aspx?ureticiAdi=" + ureticiAdi + "");
                        string kayıt = "KAYDETME BAŞARILI";
                        Response.Write("<script>alert('"+kayıt+  "')</script>");
                      
                    }
                }
            }
            catch (Exception er)
            {
                Response.Write("<script>alert('" + er.Message + "')</script>");
            }
        }
    }

}
     
