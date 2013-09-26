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
            UserControls.HandsoneDataGridOption options = new UserControls.HandsoneDataGridOption();

            using (var db = new PersonEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                options.Data = db.People.Select(p => p);
            }
            
            options.Width = 800;
            options.EnterMoves = new int[] { 1, 2, 3 };
            options.MultiSelect = false;
            options.ColHeaders = true;
            options.ColumnSorting = true;
            options.Height = 600;

            DataGrid.dataGridOptions = options;

            UserControls.DataTableNetDataGridOption netOptions = new UserControls.DataTableNetDataGridOption();

            netOptions.
        }
    }
}