using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WcfBase.UserControls
{
    public class DataGridOptions
    {
        private double _maxRows = Double.PositiveInfinity;
        private double _maxCols = Double.PositiveInfinity;
        
        public IEnumerable<object> Data { get; set; }
        public Unit Width { get; set; }
        public Unit Height { get; set; }
        public int StartRows { get; set; }
        public int StartCols { get; set; }
        public int MinRows { get; set; }
        public int MinCols { get; set; }
        public double MaxRows { get { return Math.Ceiling(_maxRows); } set { _maxRows = value; } }
        public double MaxCols { get { return Math.Ceiling(_maxCols); } set { _maxCols = value; } }
        
        //minSpareRows: 0,
        //minSpareCols: 0,
        //multiSelect: true,
        //fillHandle: true,
        //fixedRowsTop: 0,
        //fixedColumnsLeft: 0,
        //outsideClickDeselects: true,
        //enterBeginsEditing: true,
        //enterMoves: {row: 1, col: 0},
        //tabMoves: {row: 0, col: 1},
        //autoWrapRow: false,
        //autoWrapCol: false,
        //copyRowsLimit: 1000,
        //copyColsLimit: 1000,
        //pasteMode: 'overwrite',
        //currentRowClassName: void 0,
        //currentColClassName: void 0,
        //stretchH: 'hybrid',
        //isEmptyRow: void 0,
        //isEmptyCol: void 0,
        //observeDOMVisibility: true,
        //allowInvalid: true,
        //invalidCellClassName: 'htInvalid',
        //fragmentSelection: false,
        //readOnly: false,
        //scrollbarModelV: 'dragdealer',
        //scrollbarModelH: 'dragdealer'
    }

    public partial class DataGrid : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}