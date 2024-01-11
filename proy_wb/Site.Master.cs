using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proy_wb
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"]==null)
            {
                Response.Redirect("~/PageLogin");
            }
        }

        protected void btnCloseSession(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect("~/PageLogin");
        }
    }
}