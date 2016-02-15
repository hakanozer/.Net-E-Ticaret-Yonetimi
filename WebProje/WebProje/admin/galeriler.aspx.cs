using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Data.SqlClient;


namespace SemaDincer_GalleryManagement.admin
{
    public partial class galeriler : System.Web.UI.Page
    {
        public ArrayList ls = new ArrayList();
        

        DB db = new DB();
        String galeriAdi;
        String galeriAciklama;
        String galeriID;

        
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataReader rd = db.dataGetir("galeriler");
            while (rd.Read())
            {

                classGaleri classGaleri = new classGaleri();
                classGaleri.GaleriID = int.Parse(rd["galeriID"].ToString());
                classGaleri.GaleriAdi = rd["galeriAdi"].ToString();

                ls.Add(classGaleri);

            }

            rd.Close();

        }

        protected void btnGaleriOlustur_Click(object sender, EventArgs e)
        {
            galeriAdi = Request.Params["galeriAdi"];
            galeriAciklama = Request.Params["galeriAciklama"];

            try
            {
                db.ac();
                SqlCommand cm = new SqlCommand("insert into galeriler values('" + galeriAdi + "','" + galeriAciklama + "',getDate())", db.conn);
                int sonuc = cm.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    SqlDataReader rd = db.dataGetir("galeriler");
                    while (rd.Read())
                    {
                        galeriID = rd["galeriID"].ToString(); ;
                    }

                    Response.Redirect("galeriler.aspx");

                    db.kapat();
                }

                else
                    Response.Redirect("admin.aspx");

            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }

        }
    }
}