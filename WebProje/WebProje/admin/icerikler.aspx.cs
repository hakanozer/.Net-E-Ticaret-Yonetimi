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
    public partial class icerikler : System.Web.UI.Page
    {

        public ArrayList pils = new ArrayList();
        DB db = new DB();

      
        protected void Page_Load(object sender, EventArgs e)
        {
            
            SqlDataReader py = db.dataGetir("icerikYonetimi");
            while (py.Read())
            {
                pIcerikYonetimi piy = new pIcerikYonetimi();
                piy.IcerikID = Convert.ToInt32(py["icerikID"]);
                piy.Baslik = py["baslik"].ToString();
                piy.KisaAciklama = py["kisaAciklama"].ToString();
                piy.Detay = py["detay"].ToString();
                piy.EklenmeTarihi = Convert.ToDateTime(py["eklenmeTarihi"]);
                pils.Add(piy);
            }
                    
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            Response.Redirect("icerikler.aspx");
        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            Response.Redirect("icerikler.aspx");
        }
    }
}