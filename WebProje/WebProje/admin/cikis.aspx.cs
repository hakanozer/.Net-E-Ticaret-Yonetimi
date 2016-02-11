using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProje.admin
{
    public partial class cikis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // sessionlar siliniyor
            Session.RemoveAll(); // bütün oturumları kapat
            // çerezleri sil
            HttpCookie cerez = new HttpCookie("adminCerez");
            cerez.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cerez);
            // sayfa yönlendirmesi yapılıyor
            Response.Redirect("Default.aspx");

        }
    }
}