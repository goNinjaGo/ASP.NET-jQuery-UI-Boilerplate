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
        
        [WebGet(ResponseFormat=WebMessageFormat.Xml)]
        [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
        [OperationContract]
        public Stream FetchHtml(string controlName, Dictionary<string, object> args)
        {
            var html = GetControlHtml(controlName, args);  

            // we want our result interpreted as plain html
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";

            // create a stream from our html because trying to return a string adds an extra header tag
            //      to the response.  Returning a stream returns the html by itself
            var result = new MemoryStream(ASCIIEncoding.UTF8.GetBytes(html));

            // return the result
            return result;
        }

        private string GetControlHtml(string controlName, Dictionary<string, object> args)
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

    }

    
}
