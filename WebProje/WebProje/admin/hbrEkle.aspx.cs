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
    public partial class hbrEkle : System.Web.UI.Page
    {
        DB db = new DB();
        ArrayList ktgrls = new ArrayList();
      

        protected void Page_Load(object sender, EventArgs e)
        {
            ktgrls.Clear();

            SqlDataReader rd = db.dataGetir("hbrKategori");
            while (rd.Read())
            {
                pHbrKategori hbrkgtr = new pHbrKategori();
                hbrkgtr.KatId = Convert.ToInt32(rd["ID"]);
                hbrkgtr.KatAd = rd["adi"].ToString();

                ktgrls.Add(hbrkgtr);
            }
            db.kapat();

            foreach (pHbrKategori item in ktgrls)
            {
                DropDownList1.Items.Add(new ListItem(HttpUtility.HtmlDecode("") + item.KatAd, item.KatId.ToString()));
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                db.ac();

                HttpPostedFile yukleDosya = fluDosya.PostedFile;
                string hbrResim;
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

                string hbrKatId = DropDownList1.SelectedValue;
                string hbrBaslik = txthbrBaslik.Text;
                string hbrKisaAciklama = kisaAciklama.Text;
                string hbrIcerik = txtIcerik.Text;
                //string hbrResim = "";
                string hbrDurum = DropDownList2.SelectedValue;

                string query = "INSERT INTO haberler VALUES('" + hbrKatId + "','" + hbrBaslik + "','" + hbrKisaAciklama + "','" + hbrIcerik + "','" + hbrResim + "','" + hbrDurum + "',getDate())";
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