using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WikEasyUIDemo
{
    public partial class Index : System.Web.UI.Page
    {
        protected int IsLogin=0;
        string username = "";
        string userpwd = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            if (Session["username"] != null)
                IsLogin = 1;
            //}
        }

      
    }
}