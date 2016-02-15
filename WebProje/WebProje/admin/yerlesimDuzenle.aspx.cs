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
using System.Runtime.CompilerServices;

namespace WebProje.admin
{
    public partial class yerlesimDuzenle : System.Web.UI.Page
    {
        public ArrayList lsy1 = new ArrayList();
        public ArrayList lsy2 = new ArrayList();
        DB db = new DB();
        string id = "";
        string logoYol = "";
        

        protected void Page_Load(object sender, EventArgs e)
        {
            lsy1.Clear();
            db.ac();


            SqlCommand cmd = new SqlCommand("select * from yerlesimDuzenle as x left join yerlesimOlay as y on x.yerlesimID = y.yerlesimID", db.conn);
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {
                    pYerlesimDuzenle y = new pYerlesimDuzenle();
                    y.YerlesimID = rd["yerlesimID"].ToString();
                    y.Baslik = rd["baslik"].ToString();
                    y.ResimYol = rd["resimYol"].ToString();
                    y.Aciklama = rd["aciklama"].ToString();
                    y.Tarih = rd["tarih"].ToString();
                    y.OlayAdi = rd["olayAdi"].ToString();
                    y.OlayTuru = rd["olayTuru"].ToString();
                    y.Manset_yap = rd["manset_yap"].ToString();
                    y.Manset_alt = rd["alt_manset_yap"].ToString();
                    y.Sonhaber = rd["sonhaber_yap"].ToString();
                    lsy1.Add(y);
                }
                rd.Close();

                db.kapat();
            }
            fonkSil();

            ////////////////////////////////
            ////////////////////////////////
            mansetYap();
            mansetAltYap();
            sonHaberYap();

        }
        private void fonkSil()
        {
            DB db = new DB();
            if (Request.QueryString["silID"] != null)
            {
                string sil = Request.QueryString["silID"].ToString();
                db.ac();
                SqlCommand cm = new SqlCommand("delete from yerlesimDuzenle where yerlesimID= '" + sil + "'; delete from yerlesimOlay where yerlesimID= '" + sil + "' ", db.conn);
                int sonuc = cm.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    Response.Redirect("yerlesimDuzenle.aspx");
                }
                cm.Dispose();
            }
            db.kapat();
        }

        private void mansetYap()
        {
            DB db = new DB();
            string olayAdi = "";
            string olayTuru = "";
            if (Request.QueryString["mansetsecID1"] != null)
            {
                id = Request.QueryString["mansetsecID1"].ToString();
                olayAdi = Request.QueryString["olayAdi1"].ToString();
                olayTuru = Request.QueryString["olayTuru1"].ToString();
                //mansetOlay();
                db.ac();
                olayAdi = "manset"; 
                if (olayTuru == "False" && olayAdi == "manset")
                {
                    olayTuru = "True";
                    logoYol = "../resimler/manset.png";
                }
                else if (olayTuru == "True" && olayAdi != "manset")
                {
                    olayTuru = "True";
                    logoYol = "../resimler/manset.png";
                }
                else if (olayTuru == "True" && olayAdi == "manset")
                {
                    olayTuru = "False";
                    logoYol = "../resimler/manset_b.png";
                }
                olayAdi = "manset";
                SqlCommand cm = new SqlCommand("update yerlesimOlay set yerlesimID= '" + id + "', olayAdi= '" + olayAdi + "', olayTuru= '" + olayTuru + "', manset_yap= '" + logoYol + "' where yerlesimID= '" + id + "' ", db.conn);
                int sonuc = cm.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    Response.Redirect("yerlesimDuzenle.aspx");
                }
                else
                {
                    Response.Redirect("yerlesimDuzenle.aspx?Hata");
                }
                cm.Dispose();

                db.kapat();
            }
        }

        private void mansetAltYap()
        {
            DB db = new DB();
            string olayAdi = "";
            string olayTuru = "";
            if (Request.QueryString["mansetsecID2"] != null)
            {
                id = Request.QueryString["mansetsecID2"].ToString();
                olayAdi = Request.QueryString["olayAdi2"].ToString();
                olayTuru = Request.QueryString["olayTuru2"].ToString();
                //mansetOlay();
                db.ac();
                if (olayTuru == "False" && olayAdi == "manset_alt")
                {
                    olayTuru = "True";
                    logoYol = "../resimler/manset_alt.png";
                }
                else if (olayTuru == "True" && olayAdi != "manset_alt")
                {
                    olayTuru = "True";
                    logoYol = "../resimler/manset_alt.png";
                }
                else if (olayTuru == "True" && olayAdi == "manset_alt")
                {
                    olayTuru = "False";
                    logoYol = "../resimler/manset_alt_b.png";
                }
                olayAdi = "manset_alt";
                SqlCommand cm = new SqlCommand("update yerlesimOlay set yerlesimID= '" + id + "', olayAdi= '" + olayAdi + "', olayTuru= '" + olayTuru + "', alt_manset_yap= '" + logoYol + "' where yerlesimID= '" + id + "' ", db.conn);
                int sonuc = cm.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    Response.Redirect("yerlesimDuzenle.aspx");
                }
                else
                {
                    Response.Redirect("yerlesimDuzenle.aspx?Hata");
                }
                cm.Dispose();

                db.kapat();
            }
        }

        private void sonHaberYap()
        {
            DB db = new DB();
            string olayAdi = "";
            string olayTuru = "";
            if (Request.QueryString["mansetsecID3"] != null)
            {
                id = Request.QueryString["mansetsecID3"].ToString();
                olayAdi = Request.QueryString["olayAdi3"].ToString();
                olayTuru = Request.QueryString["olayTuru3"].ToString();
                //mansetOlay();
                db.ac();
                if (olayTuru == "False" && olayAdi == "sonhaber")
                {
                    olayTuru = "True";
                    logoYol = "../resimler/sonhaber.png";
                }
                else if (olayTuru == "True" && olayAdi != "sonhaber")
                {
                    olayTuru = "True";
                    logoYol = "../resimler/sonhaber.png";
                }
                else if (olayTuru == "True" && olayAdi == "sonhaber")
                {
                    olayTuru = "False";
                    logoYol = "../resimler/sonhaber_b.png";
                }
                olayAdi = "sonhaber";
                SqlCommand cm = new SqlCommand("update yerlesimOlay set yerlesimID= '" + id + "', olayAdi= '" + olayAdi + "', olayTuru= '" + olayTuru + "', sonhaber_yap= '" + logoYol + "' where yerlesimID= '" + id + "' ", db.conn);
                int sonuc = cm.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    Response.Redirect("yerlesimDuzenle.aspx");
                }
                else
                {
                    Response.Redirect("yerlesimDuzenle.aspx?Hata");
                }
                cm.Dispose();

                db.kapat();
            }
        }

    }
}