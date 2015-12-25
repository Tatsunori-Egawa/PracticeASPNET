using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        private int pageStatus {
            get {
                int i;
                if (this.ViewState["pageStatus"] == null || !int.TryParse(this.ViewState["pageStatus"].ToString(), out i))
                    return 0;
                else
                    return i;
            }
            set {
                this.ViewState["pageStatus"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (!this.IsPostBack) {
                this.txt1.Text = "入力して。";
                this.txt1.Focus();
            } else if (this.ErrorLinkList.isErrorOrWarning && this.ErrorLinkList.ErrorListCount == 0) {
                Console.Write("");
            }
        }

        protected void btnSend_Click(object sender, EventArgs e) {
            bool result = this.InputCheck();
            if (result) {
                btnSend_Hidden_Click(null, null);
            } else {
                // エラーではなく警告のみの場合、確認メッセージ出してOKなら次画面に遷移。
                if (this.ErrorLinkList.ErrorListCount == 0 && this.ErrorLinkList.WarningListCount != 0) {
                    string confirmScript = string.Format(@"if(confirm('{0}'))document.getElementById('{1}').click();", @"警告あるよ？\n次の画面に行っても戻って修正することは可能です。", this.btnSend_Hidden.ClientID);
                    if (!this.ClientScript.IsStartupScriptRegistered(this.GetType(), "warningConfirm"))
                        this.ClientScript.RegisterStartupScript(this.GetType(), "warningConfirm", confirmScript, true);
                }
            }
        }

        private bool InputCheck() {
            this.ErrorLinkList.Clear();
            if (string.IsNullOrEmpty(this.txt1.Text.Trim())) {
                this.ErrorLinkList.Add("未入力だめ", this.txt1.ID, this.txt1.ClientID, false);
                this.ErrorLinkList.Add("未入力だめ", this.txt1.ID, this.txt1.ClientID, false);
                this.ErrorLinkList.Add("未入力だめ", this.txt1.ID, this.txt1.ClientID, false);
            }

            this.ErrorLinkList.Complete();
            return !this.ErrorLinkList.isErrorOrWarning;
        }

        protected void btnSend_Hidden_Click(object sender, EventArgs e) {
            string newId = Utility.CreateNewId();
            this.Session["guid"] = newId;
            this.Response.Redirect(string.Format("App/App1/WebForm1.aspx?guid={0}", newId));
        }
    }
}