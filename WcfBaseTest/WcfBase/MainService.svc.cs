using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.IO;
using System.Web;
using System.Web.UI;
using WcfBase.UserControls;

namespace WcfBase
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class MainService
    {
        
        [DataContract]
        public class DataTableModel<T>
        {
            [DataMember] 
            public string sEcho { get; set; }
            [DataMember]
            public int iTotalRecords { get; set; }
            [DataMember]
            public int iTotalDisplayRecords { get; set; }
            [DataMember]
            public List<T> aaData { get; set; }
        }

        [WebInvoke(Method = "GET", 
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, 
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        public DataTableModel<Person> GetData()
        {
            using (var db = new PersonEntities())
            {
                var echo = HttpContext.Current.Request.Params["sEcho"];
                
                db.Configuration.ProxyCreationEnabled = false;
                var x = db.People.Select(p => p).ToList();
                return new DataTableModel<Person>()
                {
                    aaData = x,
                    iTotalRecords = x.Count,
                    iTotalDisplayRecords = x.Count,
                    sEcho = 1.ToString() //Convert.ToInt32(args["sEcho"]).ToString()
                };
            }
        }

        //[WebGet(ResponseFormat = WebMessageFormat.Xml)]
        //[OperationContract]
        //public Stream FetchHtml(string controlName, Dictionary<string, string> args)
        //{
        //    var html = GetControlHtml(controlName, args);

        //    // we want our result interpreted as plain html
        //    WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";

        //    // create a stream from our html because trying to return a string adds an extra header tag
        //    //      to the response.  Returning a stream returns the html by itself
        //    var result = new MemoryStream(ASCIIEncoding.UTF8.GetBytes(html));

        //    // return the result
        //    return result;
        //}

        private string GetControlHtml(string controlName, Dictionary<string, string> args)
        {
            Page tempPage = new Page();

            string path = "~/UserControls/" + controlName + ".ascx";


            tempPage.Controls.Add(tempPage.LoadControl(path));

            BaseUserControl myControl = (BaseUserControl)tempPage.Controls[0];
            myControl.args = args;

            StringWriter sw = new StringWriter();

            HttpContext.Current.Server.Execute(tempPage, sw, false);

            return sw.ToString();
        }

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public string TestFunction()
        {
            return "blah";
        }
    }


}
