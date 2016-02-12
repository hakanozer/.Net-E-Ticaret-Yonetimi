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
    public partial class icerikEkle : System.Web.UI.Page
    {

        DB db = new DB();
        ArrayList ie = new ArrayList();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            ie.Clear();

            SqlDataReader ierd = db.dataGetir("icerikYonetimi");
            while (ierd.Read())
            {
                pIcerikYonetimi piy = new pIcerikYonetimi();
                piy.IcerikID = Convert.ToInt32(ierd["icerikID"]);
                piy.Baslik = ierd["baslik"].ToString();
                piy.KisaAciklama = ierd["kisaAciklama"].ToString();
                piy.Detay = ierd["detay"].ToString();
                piy.EklenmeTarihi = Convert.ToDateTime(ierd["eklenmeTarihi"]);
                ie.Add(piy);
            }
            db.kapat();
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                db.ac();
                string pBaslik = baslik.Text;
                string pKisaAciklama = kisaAciklama.Text;
                string pDetay = detay.Text;
                if (string.IsNullOrEmpty(pBaslik) || string.IsNullOrEmpty(pKisaAciklama) || string.IsNullOrEmpty(pDetay))
                {
                    Response.Write("Boş alanları doldurunuz");
                }
                else
                {
                    SqlCommand cm = new SqlCommand("insert into icerikYonetimi values ('" + pBaslik + "', '" + pKisaAciklama + "', '" + pDetay + "', getDate())", db.conn);
                    int sonuc = cm.ExecuteNonQuery();
                    if (sonuc > 0)
                    {
                        Response.Redirect("icerikler.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Kayıt işlemi başarısız . Lütfen tekrar deneyiniz.");

            }
        }
    }
}