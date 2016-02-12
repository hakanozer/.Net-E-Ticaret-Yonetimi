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
    public partial class Siparisler : System.Web.UI.Page
    {
        DB db = new DB();
        protected void Page_Load(object sender, EventArgs e)
        {
            string sorgu = "select s.siparisID,m.mail,m.musteriID,s.tutar,s.detay,s.adres,s.tarih from siparisler as s inner join musteriler as m on s.musteriID = m.musteriID";
            SqlCommand cmd = new SqlCommand(sorgu, db.conn);
            SqlDataReader rd = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rd);
            rpSiparisListesi.DataSource = dt;
            rpSiparisListesi.DataBind();
        }
    }
}