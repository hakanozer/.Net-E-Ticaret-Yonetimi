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
    public partial class adminGiris : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["email"] != null && Request.Params["password"] != null)
            {
                String mail = Request.Params["email"].ToString();
                String sifre = Request.Params["password"].ToString();

                if (mail != null && sifre != null)
                {
                    DB db = new DB();
                
                    // değerler var veritabanını ziyaret et
                    String query = "select *from admin where mail = '" + mail + "' and sifre = '" + DB.MD5Sifrele(sifre) + "'";
                    SqlCommand cm = new SqlCommand(query, db.conn);
                    SqlDataReader rd = cm.ExecuteReader();
                    if (rd.Read())
                    {
                        // kullanıcı var
                        Session["adminID"] = rd["id"];
                        Session["adminAdi"] = rd["adi"] + " " + rd["soyadi"];

                        // beni hatırla tıklanmış ise
                        HttpCookie cerez = new HttpCookie("adminCerez");
                        cerez["adminAdi"] = rd["adi"] + " " + rd["soyadi"];
                        if (Request.Params["remember"] != null)
                        {
                            cerez["id"] = rd["id"].ToString();
                        }
                        cerez.Expires = DateTime.Now.AddDays(3);
                        Response.Cookies.Add(cerez);
                        // sayfa yönlendirma yapılıyor
                        Response.Redirect("admin.aspx");


                    }
                    else {
                        // böyle bir kullanıcı yok
                        Response.Redirect("Default.aspx?girisHatasi=hata");
                    }

                }
                else {
                    Response.Redirect("Default.aspx");
                }
            }
            else
            {
                // istenilen değerler yok !
                Response.Redirect("Default.aspx");
            }
        }
    }
}