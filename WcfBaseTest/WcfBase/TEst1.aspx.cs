using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;

namespace WcfBase
{
    public partial class TEst1 : System.Web.UI.Page
    {
        [Serializable]
        public class TestClass
        {
            public string testStr;
            public int testInt;
            public bool testBool;
            public int[] testArray;
            public List<string> testList;
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            var jsonSerializer = new JavaScriptSerializer();
            jsonSerializer.MaxJsonLength = int.MaxValue;
            var dataString = jsonSerializer.Serialize(new TestClass());

            var x = 0;
        }
    }
}