using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WcfService1
{
    public partial class Console : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("admin.aspx");
                Server.Transfer("admin.aspx", true);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["admin"] = null;
            Response.Redirect("admin.aspx");
            Server.Transfer("admin.aspx", true);
        }
    }
}