using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.App.App1 {
    public partial class WebForm1 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!this.IsPostBack) {
                if (this.Session["guid"] != null && Request.QueryString["guid"] != null && this.Session["guid"].ToString() == Request.QueryString["guid"].ToString()) {
                    this.lblResult.Text = "ページ遷移正常";
                } else {
                    this.lblResult.CssClass = Utility.AddCssClass(this.lblResult.CssClass, "inputError");
                    this.lblResult.Text = "ページ遷移不正";
                }
            }
        }

        protected void btnSend_Click(object sender, EventArgs e) {

        }
    }
}