using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Web.Script.Serialization;

namespace WcfBase.UserControls
{

    public interface IDataGridOption
    {
        
    }

    public class DataGridOption : IDataGridOption
    {
        public string pluginName = "";
        public string tagName = "";
        
        public Dictionary<string, string> SetProperties = new Dictionary<string, string>();
                
        protected string GetSerializedValue(object datObj)
        {
            var jsonSerializer = new JavaScriptSerializer();
            jsonSerializer.MaxJsonLength = int.MaxValue;
            var dataString = jsonSerializer.Serialize(datObj);
            return dataString;
        }

        protected string GetStringOptionValue(string val)
        {
            return "'" + val + "'";
        }

        protected string GetMaxOptionValue(double val)
        {
            if (val == double.PositiveInfinity)
                return "Infinity";
            else if (val == double.NegativeInfinity)
                return "-Infinity";
            else
                return Math.Ceiling(val).ToString();
        }

        protected string GetBooleanOptionValue(bool val)
        {
            return val.ToString().ToLower();
        }

        protected string GetNumberArrayOptionValue(int[] valArray)
        {
            string retVal = "[";
            valArray.ToList().ForEach(num => retVal += num + ",");
            return retVal.Remove(retVal.LastIndexOf(",")) + "]";
        }

        public string GetOptionName(string setName)
        {
            string name = setName.Replace("set_", "");
            name = name.Substring(0, 1).ToLower() + name.Substring(1);
            return name;
        }
    }

    public class HandsoneDataGridOption : DataGridOption
    {
        #region Properties
        public IEnumerable<object> Data
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = GetSerializedValue(value);
            }
        }
        public int Width
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = value.ToString();
            }
        }
        public int Height
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = value.ToString();
            }
        }
        public int StartRows
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = value.ToString();
            }
        }
        public int StartCols
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = value.ToString();
            }
        }
        public int MinRows
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = value.ToString();
            }
        }
        public int MinCols
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = value.ToString();
            }
        }
        public double MaxRows
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = GetMaxOptionValue(value);
            }
        }
        public double MaxCols
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = GetMaxOptionValue(value);
            }
        }
        public int MinSpareRows
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = value.ToString();
            }
        }
        public int MinSpareCols
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = value.ToString();
            }
        }
        public bool MultiSelect
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = GetBooleanOptionValue(value);
            }
        }
        public int FillHandle
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = value.ToString();
            }
        }
        public int FixedRowsTop
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = value.ToString();
            }
        }
        public int FixedColumnsLeft
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = value.ToString();
            }
        }
        public bool OutsideClickDeselects
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = GetBooleanOptionValue(value);
            }
        }
        public bool EnterBeginsEditing
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = GetBooleanOptionValue(value);
            }
        }
        public int[] EnterMoves
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = GetNumberArrayOptionValue(value);
            }
        }
        public int[] TabMoves
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = GetNumberArrayOptionValue(value);
            }
        }
        public bool AutoWrapRow
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = GetBooleanOptionValue(value);
            }
        }
        public bool AutoWrapCol
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = GetBooleanOptionValue(value);
            }
        }
        public int CopyRowsLimit
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = value.ToString();
            }
        }
        public int CopyColsLimit
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = value.ToString();
            }
        }
        public string PasteMode
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = GetStringOptionValue(value);
            }
        }
        public string CurrentRowClassName
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = GetStringOptionValue(value);
            }
        }
        public string CurrentColClassName
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = GetStringOptionValue(value);
            }
        }
        public string StretchH
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = GetStringOptionValue(value);
            }
        }
        public string IsEmptyRow
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = value.ToString();
            }
        } //function
        public string IsEmptyCol
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = value.ToString();
            }
        } //function
        public bool ObserveDOMVisibility
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = GetBooleanOptionValue(value);
            }
        }
        public bool AllowInvalid
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = GetBooleanOptionValue(value);
            }
        }
        public string NvalidCellClassName
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = GetStringOptionValue(value);
            }
        }
        public bool FragmentSelection
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = GetBooleanOptionValue(value);
            }
        }
        public bool ReadOnly
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = GetBooleanOptionValue(value);
            }
        }
        public string ScrollbarModelV
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = GetStringOptionValue(value);
            }
        }
        public string ScrollbarModelH
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = GetStringOptionValue(value);
            }
        }
        public bool ColHeaders
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = GetBooleanOptionValue(value);
            }
        }
        public bool ColumnSorting
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = GetBooleanOptionValue(value);
            }
        }
        #endregion

        public HandsoneDataGridOption()
        {
            pluginName = "handsontable";
            tagName = "div";
        }
        
    }

    public class DataTableNetDataGridOption : DataGridOption
    {

        #region Properties

        public bool Destroy
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = GetBooleanOptionValue(value);
            }
        }
        public bool Retrieve
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = GetBooleanOptionValue(value);
            }
        } 
        public bool ScrollAutoCss
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = GetBooleanOptionValue(value);
            }
        } 
        public bool ScrollCollapse
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = GetBooleanOptionValue(value);
            }
        }
        public bool SortCellsTop
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = GetBooleanOptionValue(value);
            }
        }
        public int CookieDuration
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = value.ToString();
            }
        } 
        public int DeferLoading
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = value.ToString();
            }
        } 
        public int DisplayLength
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = value.ToString();
            }
        } 
        public int DisplayStart
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = value.ToString();
            }
        } 
        public int ScrollLoadGap
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = value.ToString();
            }
        }
        public int TabIndex
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = value.ToString();
            }
        }
        public Dictionary<string, string> Search
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = value.ToString();
            }
        }
        public string AjaxDataProp
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = GetStringOptionValue(value);
            }
        }
        public string AjaxSource
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = GetStringOptionValue(value);
            }
        }
        public string CookiePrefix
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = GetStringOptionValue(value);
            }
        }
        public string Dom
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = GetStringOptionValue(value);
            }
        }
        public string PaginationType
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = GetStringOptionValue(value);
            }
        }
        public string ScrollXInner
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = GetStringOptionValue(value);
            }
        }
        public string ServerMethod
        {
            set
            {
                SetProperties[MethodBase.GetCurrentMethod().Name] = GetStringOptionValue(value);
            }
        }

        #endregion

        public DataTableNetDataGridOption()
        {
            pluginName = "dataTable";
            tagName = "table";
        }

    }
    
    public partial class DataGrid : BaseUserControl
    {

        public IDataGridOption dataGridOptions;

        

        
       
        protected void Page_PreRender(object sender, EventArgs e) 
        {
            if (dataGridOptions != null)
            {
                var options = (DataGridOption)dataGridOptions;

                dataGrid.TagName = options.

                string datascriptString = "<script>$(function(){$('#" + dataGrid.ClientID + "')." + options.pluginName + "({";
                
                foreach (string key in options.SetProperties.Keys)
                {
                    datascriptString += options.GetOptionName(key) + " : " + options.SetProperties[key] + ", ";
                }
                datascriptString = datascriptString.Remove(datascriptString.LastIndexOf(",")) + "});});</script>";

                this.Controls.Add(new LiteralControl(datascriptString));
            }
        }

        
    }
}