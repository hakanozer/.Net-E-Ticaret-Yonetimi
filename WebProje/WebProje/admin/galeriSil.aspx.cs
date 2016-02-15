using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace SemaDincer_GalleryManagement.admin
{
    public partial class galeriSil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DB db = new DB();
            db.ac();

            string galeriID = Request.Params["galeriID"];
            SqlCommand cm = new SqlCommand("delete from galeriler where galeriID='" + galeriID + "'", db.conn);
            int sonuc = cm.ExecuteNonQuery();
            if (sonuc > 0)
            {
                Response.Redirect("galeriler.aspx");
                db.kapat();
            }
        }
    }
}