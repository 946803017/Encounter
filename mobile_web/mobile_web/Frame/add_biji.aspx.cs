using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mobile_web.Frame
{
    public partial class add_biji : System.Web.UI.Page
    {
        public string userid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] != null)
            {
                userid = Session["userid"].ToString();
            }
        }
    }
}