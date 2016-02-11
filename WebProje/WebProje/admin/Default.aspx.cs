using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProje.admin
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["adminCerez"] != null)
            {
                if (Request.Cookies["adminCerez"]["adminAdi"] != null)
                {
                    Session["adminAdi"] = Request.Cookies["adminCerez"]["adminAdi"].ToString();
                }

                if (Request.Cookies["adminCerez"]["id"] != null)
                {
                    // cerez var session oluştur
                    Session["adminID"] = Request.Cookies["adminCerez"]["id"].ToString();
                    // sayfa yönlendir
                    Response.Redirect("admin.aspx");

                }
            }

        }
    }
}