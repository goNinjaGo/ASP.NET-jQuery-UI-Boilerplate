using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WcfBase.UserControls;

namespace WcfBase
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HandsoneDataGridOption options = new HandsoneDataGridOption();

            DataTableNetDataGridOption netOptions = new DataTableNetDataGridOption();

            using (var db = new PersonEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                var x = db.People.Select(p => p);
                options.Data = x;
                netOptions.Data = x;
            }
            
            options.Width = 800;
            options.EnterMoves = new int[] { 1, 2, 3 };
            options.MultiSelect = false;
            options.ColHeaders = true;
            options.ColumnSorting = true;
            options.Height = 600;

            netOptions.Processing = true;
            var wee = new List<IDataGridOption>();
            wee.Add(new DataTableNetDataGridOption.ColumnOptions() { Data = "Title", Title = "Title" });
            wee.Add(new DataTableNetDataGridOption.ColumnOptions() { Data = "FirstName", Title = "First Name" });
            wee.Add(new DataTableNetDataGridOption.ColumnOptions() { Data = "LastName", Title = "Last Name" });
            wee.Add(new DataTableNetDataGridOption.ColumnOptions() { Data = "AdditionalContactInfo", Title = "Contact Info" });
            //wee.Add(new DataTableNetDataGridOption.ColumnOptions() { Data = "ModifiedDate", Render = "function(data,type,full){\nreturn JSON.parse(data);\n}" });
            netOptions.Columns = wee;
            netOptions.FooterCallback = "function( nFoot, aData, iStart, iEnd, aiDisplay ) { alert('lol'); }";

            DataGrid.dataGridOptions = options;
            DataGrid2.dataGridOptions = netOptions;

        }

        //[System.Web.Services.WebMethod(BufferResponse = false)]
        //public List<Person> GetDataSource()
        //{

        //}
    }

    
}