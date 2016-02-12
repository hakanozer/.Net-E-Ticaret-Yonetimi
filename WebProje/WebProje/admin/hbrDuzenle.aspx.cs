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
    public partial class hbrDuzenle : System.Web.UI.Page
    {
        public static ArrayList hbrList = new ArrayList();
        public static ArrayList ktgrls = new ArrayList();
        DB db = new DB();
        protected void Page_Load(object sender, EventArgs e)
        {
            ktgrls.Clear();
            SqlDataReader krd = db.dataGetir("hbrKategori");
            while (krd.Read())
            {
                pHbrKategori hbrkgtr = new pHbrKategori();
                hbrkgtr.KatId = Convert.ToInt32(krd["ID"]);
                hbrkgtr.KatAd = krd["adi"].ToString();
                ktgrls.Add(hbrkgtr);
            }
            db.kapat();

            foreach (pHbrKategori item in ktgrls)
            {
                DropDownList1.Items.Add(new ListItem(HttpUtility.HtmlDecode("") + item.KatAd, item.KatId.ToString()));
            }

            try
            {
                db.ac();
                SqlCommand cm = new SqlCommand("select * from haberler where ID = '" + Request.QueryString["hbrID"].ToString() + "'", db.conn);
                SqlDataReader rd = cm.ExecuteReader();
                while (rd.Read())
                {
                    pHaberler hbr = new pHaberler();
                    hbr.HbrID = Convert.ToInt32(rd["ID"]);
                    hbr.HbrKatId = Convert.ToInt32(rd["katID"]);
                    hbr.HbrBaslik = rd["baslik"].ToString();
                    hbr.HbrAciklama = rd["kisaAciklama"].ToString();
                    hbr.HbrIcerik = rd["icerik"].ToString();
                    hbr.HbrDurum = Convert.ToInt32(rd["durum"]);
                    hbr.HbrTarih = Convert.ToDateTime(rd["tarih"]);
                    hbr.HbrResim = rd["resim"].ToString();
                    hbrList.Add(hbr);
                }
                db.kapat();
                pHaberler lst = (pHaberler)hbrDuzenle.hbrList[0];
                txthbrBaslik.Text = lst.HbrBaslik;
                txtIcerik.Text = lst.HbrIcerik;
                txtKisaAciklama.Text = lst.HbrAciklama;
                FileInfo dosyaBilgi = new FileInfo(fluDosya.FileName);
                
            }
            catch (Exception ex)
            {
                // hata
            }
        }
        string hbrResim;
        protected void btnGuncelle_Click(object sender, EventArgs e)
        {

            if (Request.QueryString["hbrID"] != null)
            {
                string hbrID = Request.QueryString["hbrID"].ToString();
                db.ac();
                SqlCommand cm = new SqlCommand("select * from haberler where ID = '" + Request.QueryString["hbrID"].ToString() + "'", db.conn);
                SqlDataReader rd = cm.ExecuteReader();
                rd.Read();
                string file = rd["resim"].ToString();
                string strPhysicalFolder = Server.MapPath("..\\resimler\\hbrResim\\");
                string strFileFullPath = strPhysicalFolder + file;
                db.kapat();
                if (System.IO.File.Exists(strFileFullPath))
                {
                    System.IO.File.Delete(strFileFullPath);
                }
                else
                {

                }
            }

            try
            {
                db.ac();
                
                HttpPostedFile yukleDosya = fluDosya.PostedFile;
                
                if (yukleDosya != null)
                {
                    Random rdn = new Random();
                    int say = rdn.Next(0, 999999999);
                    FileInfo dosyaBilgi = new FileInfo(yukleDosya.FileName);
                    hbrResim = "" + say + "_" + dosyaBilgi.Name;
                    string path = "../resimler/hbrResim/";
                    string yukleYer = Server.MapPath(path + hbrResim);
                    fluDosya.SaveAs(yukleYer);
                }
                else
                {
                    hbrResim = "default.jpg";
                }
                int hbrID=Convert.ToInt32(Request.QueryString["hbrID"]);
                string hbrKatId = DropDownList1.SelectedValue;
                string hbrBaslik = txthbrBaslik.Text;
                string hbrKisaAciklama = txtKisaAciklama.Text;
                string hbrIcerik = txtIcerik.Text;
                //string hbrResim = "";
                string hbrDurum = DropDownList2.SelectedValue;

                string query = "UPDATE haberler SET katID='"+hbrKatId+ "', baslik='" + hbrBaslik + "', kisaAciklama='" + hbrKisaAciklama + "', icerik='" + hbrIcerik + "', resim='" + hbrResim + "', durum='" + hbrDurum + "', tarih=getDate() WHERE ID='"+hbrID+"' ";

   
                 SqlCommand cm = new SqlCommand(query, db.conn);
                int sonuc = cm.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    Response.Redirect("haberler.aspx");
                }
                else
                {
                    Response.Redirect("hbrYonetim.aspx?Hata");
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
    }
}