using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2.Components {
    /// <summary>
    /// エラーリストです。最初に<see cref="Clear"/>を呼び出し、必要な分だけ<see cref="Add"/>を行い、最後に<see cref="Complete"/>を呼び出してください。エラーの数は<see cref="ErrorListCount"/>プロパティで取得できます。
    /// </summary>
    public partial class ErrorLinkList : System.Web.UI.UserControl {
        /// <summary>
        /// エラーリスト
        /// </summary>
        private List<string> errorList = new List<string>();

        /// <summary>
        /// 警告リスト
        /// </summary>
        private List<string> warningList = new List<string>();

        /// <summary>
        /// エラーリストの件数を返します。
        /// </summary>
        public int ErrorListCount {
            get { return this.errorList.Count; }
        }

        /// <summary>
        /// 警告リストの件数を返します。
        /// </summary>
        public int WarningListCount {
            get { return this.warningList.Count; }
        }

        /// <summary>
        /// エラーまたは警告があるかどうかを返します。
        /// </summary>
        public bool isErrorOrWarning { get { return this.ErrorListCount + this.WarningListCount != 0; } }

        /// <summary>
        /// エラーリストの中身をクリアします。
        /// </summary>
        public void Clear() {
            this.errorList.Clear();
            this.warningList.Clear();
        }

        /// <summary>
        /// エラーリストにエラー内容を追加します。これによってエラーの原因となるコントロールへのハイパーリンクが作成されます。
        /// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="clientId">エラーの元になったコントロールのclientId</param>
        /// <param name="isError">エラー扱いの場合true、警告扱いの場合false</param>
        public void Add(string message, string Id, string clientId, bool isError = true) {
            string s = string.IsNullOrEmpty(clientId) ? message : @"<a href=""" + @"#" + clientId + @""">" + message + @"</a>";
            WebControl c = null;
            if (this.Page.Master == null)
                c = this.Page.FindControl(Id) as WebControl;
            else
                c = this.Page.Master.FindControl(ConstantsValues.CONTENTPLACEHOLDER_BODY_ID).FindControl(Id) as WebControl;

            if (c != null) c.CssClass = Utility.AddCssClass(c.CssClass, "inputError");
            if (isError)
                this.errorList.Add(s);
            else
                this.warningList.Add(s);
        }

        /// <summary>
        /// エラーリストの内容を確定します。これによってコントロールへのデータバインドが行われます。
        /// </summary>
        public void Complete() {
            if (this.ErrorListCount == 0) {
                this.LinkList_Error.Visible = false;
            } else {
                this.LinkList_Error.Visible = true;
                this.LinkList_Error.DataSource = this.errorList;
                this.LinkList_Error.DataBind();
            }

            if (this.WarningListCount == 0) {
                this.LinkList_Warning.Visible = false;
            } else {
                this.LinkList_Warning.Visible = true;
                this.LinkList_Warning.DataSource = this.warningList;
                this.LinkList_Warning.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e) {
            //--
        }
    }
}