using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WcfBase.UserControls
{
    public partial class BaseUserControl : System.Web.UI.UserControl
    {
        public Dictionary<string, string> args = new Dictionary<string, string>();

        protected void Page_Int(object sender, EventArgs e)
        {
            this.ViewStateMode = System.Web.UI.ViewStateMode.Disabled;
        }

    }
}