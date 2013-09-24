using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WcfBase
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var db = new PersonEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                DataGrid.Data =  db.People.Select(p => p);
            }
            
            
            
            DataGrid.Width = 500;
            DataGrid.EnterMoves = new int[] { 1, 2, 3 };
            DataGrid.MultiSelect = false;
        }
    }
}