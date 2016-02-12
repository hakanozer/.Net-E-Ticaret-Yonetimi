using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebProje.admin
{
    public partial class SiparisUrunleri : System.Web.UI.Page
    {
        DB db = new DB();
        decimal toplamTutar;
        decimal toplamPiyasaTutar;
        protected void Page_Load(object sender, EventArgs e)
        {
            string siparisID = Request.QueryString["siparisID"];
            string id = Request.QueryString["musteriID"];

            string sorguMusteri = "select *from musteriler where musteriID='" + id + "'";
            SqlCommand cmmd = new SqlCommand(sorguMusteri, db.conn);
            SqlDataReader rdMusteri = cmmd.ExecuteReader();
            while (rdMusteri.Read())
            {
                lblMusteri.Text = "" + rdMusteri["adiSoyadi"].ToString().ToUpper() + ",  " + rdMusteri["mail"];
            }
            rdMusteri.Close();

            string sorgu = "select *from siparisUrunleri as su left join urunler as u on su.urunID = u.urunID where su.siparisID = '" + siparisID + "'";
            SqlCommand cmd = new SqlCommand(sorgu, db.conn);
            SqlDataReader rd = cmd.ExecuteReader();
            DataTable dt = new DataTable();

            dt.Load(rd);
            rpSiparisUrunleriListesi.DataSource = dt;
            rpSiparisUrunleriListesi.DataBind();

            string sorguTutar = "select u.fiyat,u.piyasaFiyat from siparisUrunleri as su left join urunler as u on su.urunID = u.urunID where su.siparisID = '" + siparisID + "'";
            SqlCommand cm = new SqlCommand(sorgu, db.conn);
            SqlDataReader dataRead = cm.ExecuteReader();
            while (dataRead.Read())
            {
                toplamTutar += Convert.ToDecimal(dataRead["fiyat"].ToString());
                toplamPiyasaTutar += Convert.ToDecimal(dataRead["piyasaFiyat"].ToString());
            }

            lblTutar.Text = string.Format("{0:C}", toplamTutar);
            lblPiyasaTutar.Text = string.Format("{0:C}", toplamPiyasaTutar);
        }
    }
}