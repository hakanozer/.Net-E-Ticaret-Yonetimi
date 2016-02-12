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
    public partial class hbrKategori : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        DB db = new DB();
        protected void Button1_Click(object sender, EventArgs e)
        {
            String hbrAd = txtHbrKtgr.Text;
            if (!hbrAd.Equals(""))
            {
                String query = "INSERT INTO hbrKategori VALUES('" + hbrAd + "',getDate())";
                SqlCommand cm = new SqlCommand(query, db.conn);
                try
                {
                    int sonuc = cm.ExecuteNonQuery();
                    if (sonuc > 0)
                    {
                        Response.Redirect("hbrKategori.aspx");
                    }
                    else
                    {
                        Response.Redirect("hbrKategori.aspx?EklemeHatasi");
                    }
                }
                catch (Exception)
                {
                    Response.Redirect("hbrKategori.aspx?Hata");
                }
            }
            else
            {
                Response.Redirect("hbrKategori.aspx");
            }
        }
    }
}