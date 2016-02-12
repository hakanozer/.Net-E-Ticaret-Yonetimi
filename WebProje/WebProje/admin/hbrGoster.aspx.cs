using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace WebProje.admin
{
    public partial class hbrGoster : System.Web.UI.Page
    {
        DB db = new DB();
        public ArrayList hbrLs = new ArrayList();
        public ArrayList ktgrls = new ArrayList();
        string katId;
        string durumId;

        protected void Page_Load(object sender, EventArgs e)
        {
            //kategori verilerinin getirilmesi
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

            //Silme İşlemi
            if (Request.QueryString["hbrID"] != null)
            {
                string hbrID = Request.QueryString["hbrID"].ToString();
                string file = Request.QueryString["hbrResim"].ToString();
                string strPhysicalFolder = Server.MapPath("..\\resimler\\hbrResim\\");
                string strFileFullPath = strPhysicalFolder + file;
                if (System.IO.File.Exists(strFileFullPath))
                {
                    System.IO.File.Delete(strFileFullPath);
                    db.ac();
                    SqlCommand cm = new SqlCommand("delete from haberler where ID='" + hbrID + "'", db.conn);
                    int silSonuc = cm.ExecuteNonQuery();
                    db.kapat();
                    if (silSonuc > 0)
                    {
                        //silme başarılı
                        Response.Redirect("haberler.aspx");
                    }
                    else { }
                }
                else { }
            }

            //Verileri Getirme
            db.ac();
            if (Request.QueryString["haberler"] != null && Request.QueryString["durum"] != null)
            {
                string katSecim = Request.QueryString["haberler"].ToString();
                string durumSecim = Request.QueryString["durum"].ToString();
                if (Request.QueryString["haberler"] == "0" && Request.QueryString["durum"] == "3")
                {
                    db.ac();
                    SqlDataReader rd = db.dataGetir("haberler");
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
                        hbrLs.Add(hbr);
                    }
                    db.kapat();
                }
                else if (Request.QueryString["haberler"] == "0" && Request.QueryString["durum"] == durumSecim)
                {
                    db.ac();
                    string value = Request.QueryString["durum"].ToString();
                    SqlDataReader rd = db.dataGetir("haberler where durum=" + value);
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
                        hbrLs.Add(hbr);
                    }
                    db.kapat();
                }
                else if (Request.QueryString["haberler"] == katSecim && Request.QueryString["durum"] == "3")
                {
                    db.ac();
                    string value = Request.QueryString["haberler"].ToString();

                    SqlDataReader rd = db.dataGetir("haberler where katID=" + value);
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
                        hbrLs.Add(hbr);
                    }
                    db.kapat();
                }
                else
                {
                    db.ac();
                    string value = Request.QueryString["haberler"].ToString();
                    string value2 = Request.QueryString["durum"].ToString();
                    SqlDataReader rd = db.dataGetir("haberler where katID=" + value + "and durum=" + value2);
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
                        hbrLs.Add(hbr);
                    }
                    db.kapat();
                }
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            katId = DropDownList1.SelectedValue;
            durumId = DropDownList2.SelectedValue;
            Response.Redirect("hbrGoster.aspx?haberler=" + katId + "&durum=" + durumId);
        }
    }
}