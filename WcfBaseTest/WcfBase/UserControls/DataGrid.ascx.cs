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
        string GetScript(string clientId);
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
            //return "'" + val + "'";
            //return GetSerializedValue(val);
            return val;
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
            //return val.ToString().ToLower();
            return GetSerializedValue(val);
        }

        protected string GetNumberArrayOptionValue(int[] valArray)
        {
            //string retVal = "[";
            //valArray.ToList().ForEach(num => retVal += num + ",");
            //return retVal.Remove(retVal.LastIndexOf(",")) + "]";

            return GetSerializedValue(valArray);
        }

        protected string GetStringArrayOptionValue(string[] valArray)
        {
            //string retVal = "[";
            //valArray.ToList().ForEach(str => retVal += "'" + str + "',");
            //return retVal.Remove(retVal.LastIndexOf(",")) + "]";

            return GetSerializedValue(valArray);
        }

        public virtual string GetOptionName(string setName)
        {
            string name = setName.Replace("set_", "");
            name = name.Substring(0, 1).ToLower() + name.Substring(1);
            return name;
        }
        
        public virtual string GetScript(string clientId)
        {
            string datascriptString = "<script>$(function(){$('#" + clientId + "')." + pluginName + "({";

            foreach (string key in SetProperties.Keys)
            {
                datascriptString += GetOptionName(key) + " : " + SetProperties[key] + ", ";
            }
            return datascriptString.Remove(datascriptString.LastIndexOf(",")) + "});});</script>";           
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

        public class ColumnOptions : DataGridOption
        {
            public int[] DataSortArray 
            {
                set
                {
                    SetProperties["aDataSort"] = GetNumberArrayOptionValue(value);
                }
            }
            public string[] Sorting 
            {
                set
                {
                    SetProperties["asSorting"] = GetStringArrayOptionValue(value);
                }
            }
            public bool Searchable 
            {
                set
                {
                    SetProperties["bSearchable"] = GetBooleanOptionValue(value);
                }
            }
            public bool Sortable 
            {
                set
                {
                    SetProperties["bSortable"] = GetBooleanOptionValue(value);
                }
            }
            [Obsolete]
            public bool UseRendered 
            {
                set
                {
                    SetProperties["bUseRendered"] = GetBooleanOptionValue(value);
                }
            }
            public bool Visible
            {
                set
                {
                    SetProperties["bVisible"] = GetBooleanOptionValue(value);
                }
            }
            public string CreatedCell 
            {
                set
                {
                    SetProperties["fnCreatedCell"] = value.ToString();
                }
            } //function
            [Obsolete]
            public string RenderFunction 
            {
                set
                {
                    SetProperties["fnRender"] = value.ToString();
                }
            } //function
            public int DataSort 
            {
                set
                {
                    SetProperties["iDataSort"] = value.ToString();
                }
            }
            public string Data
            {
                set
                {
                    SetProperties["mData"] = value.ToString();
                }
            } //function, int, string, null
            public string Render
            {
                set
                {
                    SetProperties["mRender"] = value.ToString();
                }
            } //function, int, string
            public string CellType 
            {
                set
                {
                    SetProperties["sCellType"] = GetStringOptionValue(value);
                }
            }
            public string Class 
            {
                set
                {
                    SetProperties["sClass"] = GetStringOptionValue(value);
                }
            }
            public string ContentPadding 
            {
                set
                {
                    SetProperties["sContentPadding"] = GetStringOptionValue(value);
                }
            }
            public string DefaultContent 
            {
                set
                {
                    SetProperties["sDefaultContent"] = GetStringOptionValue(value);
                }
            }
            public string Name
            {
                set
                {
                    SetProperties["sName"] = GetStringOptionValue(value);
                }
            }
            public string SortDataType 
            {
                set
                {
                    SetProperties["sSortDataType"] = GetStringOptionValue(value);
                }
            }
            public string Title 
            {
                set
                {
                    SetProperties["sTitle"] = GetStringOptionValue(value);
                }
            }
            public string Type 
            {
                set
                {
                    SetProperties["sType"] = GetStringOptionValue(value);
                }
            }
            public string Width 
            {
                set
                {
                    SetProperties["sWidth"] = GetStringOptionValue(value);
                }
            }

            public override string GetScript(string clientId)
            {
                return GetSerializedValue(SetProperties);
            }
        }

        public class ColumnDef : ColumnOptions
        {
            public int[] Targets
            {
                set
                {
                    SetProperties["aDataSort"] = GetNumberArrayOptionValue(value);
                }
            }
        }
        
        #region Properties

        #region Options
        
        public IEnumerable<object> Data
        {
            set
            {
                SetProperties["aaData"] = GetSerializedValue(value);
            }
        }
        public IEnumerable<object> Sorting
        {
            set
            {
                SetProperties["aaSorting"] = GetSerializedValue(value);
            }
        }
        public IEnumerable<object> SortingFixed
        {
            set
            {
                SetProperties["aaSortingFixed"] = GetSerializedValue(value);
            }
        }
        public int[] LengthMenu
        {
            set
            {
                SetProperties["aLengthMenu"] = GetNumberArrayOptionValue(value);
            }
        }
        public IEnumerable<object> SearchCols
        {
            set
            {
                SetProperties["aoSearchCols"] = GetSerializedValue(value);
            }
        }
        public string[] StripeClasses
        {
            set
            {
                SetProperties["asStripeClasses"] = GetStringArrayOptionValue(value);
            }
        }
        public bool Destroy
        {
            set
            {
                SetProperties["bDestroy"] = GetBooleanOptionValue(value);
            }
        }
        public bool Retrieve
        {
            set
            {
                SetProperties["bRetrieve"] = GetBooleanOptionValue(value);
            }
        } 
        public bool ScrollAutoCss
        {
            set
            {
                SetProperties["bScrollAutoCss"] = GetBooleanOptionValue(value);
            }
        } 
        public bool ScrollCollapse
        {
            set
            {
                SetProperties["bScrollCollapse"] = GetBooleanOptionValue(value);
            }
        }
        public bool SortCellsTop
        {
            set
            {
                SetProperties["bSortCellsTop"] = GetBooleanOptionValue(value);
            }
        }
        public int CookieDuration
        {
            set
            {
                SetProperties["iCookieDuration"] = value.ToString();
            }
        } 
        public int DeferLoading
        {
            set
            {
                SetProperties["iDeferLoading"] = value.ToString();
            }
        } 
        public int DisplayLength
        {
            set
            {
                SetProperties["iDisplayLength"] = value.ToString();
            }
        } 
        public int DisplayStart
        {
            set
            {
                SetProperties["iDisplayStart"] = value.ToString();
            }
        } 
        public int ScrollLoadGap
        {
            set
            {
                SetProperties["iScrollLoadGap"] = value.ToString();
            }
        }
        public int TabIndex
        {
            set
            {
                SetProperties["iTabIndex"] = value.ToString();
            }
        }
        public Dictionary<string, string> Search
        {
            set
            {
                SetProperties["oSearch"] = value.ToString();
            }
        }
        public string AjaxDataProp
        {
            set
            {
                SetProperties["sAjaxDataProp"] = GetStringOptionValue(value);
            }
        }
        public string AjaxSource
        {
            set
            {
                SetProperties["sAjaxSource"] = GetStringOptionValue(value);
            }
        }
        public string CookiePrefix
        {
            set
            {
                SetProperties["sCookiePrefix"] = GetStringOptionValue(value);
            }
        }
        public string Dom
        {
            set
            {
                SetProperties["sDom"] = GetStringOptionValue(value);
            }
        }
        public string PaginationType
        {
            set
            {
                SetProperties["sPaginationType"] = GetStringOptionValue(value);
            }
        }
        public string ScrollXInner
        {
            set
            {
                SetProperties["sScrollXInner"] = GetStringOptionValue(value);
            }
        }
        public string ServerMethod
        {
            set
            {
                SetProperties["sServerMethod"] = GetStringOptionValue(value);
            }
        }

        #endregion

        #region Features

        public bool AutoWidth
        {
            set
            {
                SetProperties["bAutoWidth"] = GetBooleanOptionValue(value);
            }
        }
        public bool DeferRender 
        {
            set
            {
                SetProperties["bDeferRender"] = GetBooleanOptionValue(value);
            }
        }
        public bool Filter 
        {
            set
            {
                SetProperties["bFilter"] = GetBooleanOptionValue(value);
            }
        }
        public bool Info
        {
            set
            {
                SetProperties["bInfo"] = GetBooleanOptionValue(value);
            }
        }
        public bool JQueryUI 
        {
            set
            {
                SetProperties["bJQueryUI"] = GetBooleanOptionValue(value);
            }
        }
        public bool LengthChange 
        {
            set
            {
                SetProperties["bLengthChange"] = GetBooleanOptionValue(value);
            }
        }
        public bool Paginate 
        {
            set
            {
                SetProperties["bPaginate"] = GetBooleanOptionValue(value);
            }
        }
        public bool Processing 
        {
            set
            {
                SetProperties["bProcessing"] = GetBooleanOptionValue(value);
            }
        }
        public bool ScrollInfinite
        {
            set
            {
                SetProperties["bScrollInfinite"] = GetBooleanOptionValue(value);
            }
        }
        public bool ServerSide 
        {
            set
            {
                SetProperties["bServerSide"] = GetBooleanOptionValue(value);
            }
        }
        public bool Sort
        {
            set
            {
                SetProperties["bSort"] = GetBooleanOptionValue(value);
            }
        }
        public bool SortClasses
        {
            set
            {
                SetProperties["bSortClasses"] = GetBooleanOptionValue(value);
            }
        }
        public bool EnableStateSave 
        {
            set
            {
                SetProperties["bStateSave"] = GetBooleanOptionValue(value);
            }
        }
        public string ScrollX 
        {
            set
            {
                SetProperties["sScrollX"] = GetStringOptionValue(value);
            }
        }
        public string ScrollY 
        {
            set
            {
                SetProperties["sScrollY"] = GetStringOptionValue(value);
            }
        }

        #endregion

        #region JS Functions

        public string CookieCallback 
        {
            set
            {
                SetProperties["fnCookieCallback"] = value.ToString();
            }
        } //function
        public string CreatedRow 
        {
            set
            {
                SetProperties["fnCreatedRow"] = value.ToString();
            }
        } //function
        public string DrawCallback 
        {
            set
            {
                SetProperties["fnDrawCallback"] = value.ToString();
            }
        } //function
        public string FooterCallback 
        {
            set
            {
                SetProperties["fnFooterCallback"] = value.ToString();
            }
        } //function
        public string FormatNumber 
        {
            set
            {
                SetProperties["fnFormatNumber"] = value.ToString();
            }
        } //function
        public string HeaderCallback 
        {
            set
            {
                SetProperties["fnHeaderCallback"] = value.ToString();
            }
        } //function
        public string InfoCallback 
        {
            set
            {
                SetProperties["fnInfoCallback"] = value.ToString();
            }
        } //function
        public string InitComplete 
        {
            set
            {
                SetProperties["fnInitComplete"] = value.ToString();
            }
        } //function
        public string PreDrawCallback 
        {
            set
            {
                SetProperties["fnPreDrawCallback"] = value.ToString();
            }
        } //function
        public string RowCallback 
        {
            set
            {
                SetProperties["fnRowCallback"] = value.ToString();
            }
        } //function
        public string ServerData 
        {
            set
            {
                SetProperties["fnServerData"] = value.ToString();
            }
        } //function
        public string ServerParams 
        {
            set
            {
                SetProperties["fnServerParams"] = value.ToString();
            }
        } //function
        public string StateLoad 
        {
            set
            {
                SetProperties["fnStateLoad"] = value.ToString();
            }
        } //function
        public string StateLoadParams
        {
            set
            {
                SetProperties["fnStateLoadParams"] = value.ToString();
            }
        } //function
        public string StateLoaded 
        {
            set
            {
                SetProperties["fnStateLoaded"] = value.ToString();
            }
        } //function
        public string StateSave 
        {
            set
            {
                SetProperties["fnStateSave"] = value.ToString();
            }
        } //function
        public string StateSaveParams 
        {
            set
            {
                SetProperties["fnStateSaveParams"] = value.ToString();
            }
        } //function
        
        #endregion

        #region Column Info

        public List<IDataGridOption> Columns
        {
            set
            {
                SetProperties["aoColumns"] = GetJsonValue(value);
            }
        }

        public List<IDataGridOption> ColumnDefs
        {
            set
            {
                SetProperties["aoColumnDefs"] = GetJsonValue(value);
            }
        }

        private string GetJsonValue(List<IDataGridOption> cols)
        {
            var scriptString = "";
            cols.ForEach(c => scriptString += c.GetScript("") + ",");
            scriptString = scriptString.Remove(scriptString.LastIndexOf(","));
            return "[" + scriptString + "]";
        }

        #endregion

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

                dataGrid.TagName = options.tagName;

                this.Controls.Add(new LiteralControl(options.GetScript(dataGrid.ClientID)));
            }
        }

        
    }
}