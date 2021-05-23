using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Blackjack.Web
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Random r = new Random();
            var x = "~/images/0"+r.Next(1, 3)+ ".jpg";
            var y = "~/images/2_1.png";
            
                

        }

        
    }
}