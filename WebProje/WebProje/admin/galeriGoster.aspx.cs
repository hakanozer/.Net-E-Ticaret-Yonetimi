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

namespace SemaDincer_GalleryManagement.admin
{
    public partial class galeriGoster : System.Web.UI.Page
    {
        public ArrayList lst = new ArrayList();
        DB db = new DB();

        public string txtAd
        {
            get
            {
                return txtYeniGaleriAdi.Text;
            }
            set
            {
                txtYeniGaleriAdi.Text = txtAd;
            }
        }
        public string txtAciklama
        {
            get
            {
                return txtYeniAciklama.Text;
            }
            set
            {
                txtYeniAciklama.Text = txtAciklama;
            }
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["galeriID"] != null)
            {
                string galeriID = Request.QueryString["galeriID"].ToString();
                // resimleri getir
                SqlDataReader rd = db.dataGetir("resimler where galeriID = '" + galeriID + "'");
                while (rd.Read())
                {
                    classResim rs = new classResim();
                    rs.ResimID = int.Parse(rd["resimID"].ToString());
                    rs.ResimAdi = rd["resimAdi"].ToString();
                    rs.Resim = rd["resim"].ToString();
                    rs.Tarih = (DateTime)rd["tarih"];
                    rs.RgaleriID = int.Parse(rd["galeriID"].ToString());
                    lst.Add(rs);
                }
                db.kapat();
            }
            else
            {
                // yönlendirme yap
                Response.Redirect("galeriler.aspx");
            }
        }

        protected void btnResimEkle_Click(object sender, EventArgs e)
        {
            try
            {
                string galeriID = Request.QueryString["galeriID"].ToString();


                HttpPostedFile yukleDosya = FileUpload1.PostedFile;
                if (yukleDosya != null)
                {
                    FileInfo dosyaBilgi = new FileInfo(yukleDosya.FileName);
                    string dosyaAdi = Path.GetFileNameWithoutExtension(yukleDosya.FileName);
                    string path = "~/resimler/";
                    string yukleYer = Server.MapPath(path + dosyaBilgi.Name);
                    FileUpload1.SaveAs(yukleYer);

                    // veritabanına yaz
                    db.ac();
                    SqlCommand cm = new SqlCommand("insert into resimler values('" + galeriID + "', '" + dosyaAdi + "','" + dosyaBilgi.Name + "', getDate())", db.conn);
                    int sonuc = cm.ExecuteNonQuery();


                    if (sonuc > 0)
                    {

                        Response.Redirect("galeriGoster.aspx?galeriID=" + galeriID + "");


                    }
                    db.kapat();
                }


            }
            catch (Exception ex)
            {

                Response.Write(ex);
            }

        }

        protected void btnDuzenle_Click(object sender, EventArgs e)
        {

            txtAd = txtYeniGaleriAdi.Text;
            txtAciklama = txtYeniAciklama.Text;
            String id = Request.Params["galeriID"];


            if (txtAd != null & txtAciklama != null)
            {
                try
                {
                    db.ac();
                    SqlCommand cm = new SqlCommand("update galeriler set galeriAdi='" + txtAd + "',galeriAciklama='" + txtAciklama + "' where galeriID=" + id + "", db.conn);
                    int sonuc = cm.ExecuteNonQuery();
                    if (sonuc > 0)
                    {
                        Response.Redirect("resimGoster.aspx");
                    }
                    db.kapat();
                }
                catch (Exception ex)
                {

                    Response.Write(ex);
                }
            }

            else
            {

                Response.Redirect("galeriGoster.aspx");
            }


        }
    }
}