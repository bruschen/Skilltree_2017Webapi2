using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace D1_Lab01_XMLWebService
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var calc = new XmlWs.XmlWebService();
            var result = calc.Add(1, 2);
            lblResult.Text = result.ToString();
        }
    }
}