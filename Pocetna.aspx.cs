using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eProdaja_Web
{
    public partial class Pocetna : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                SetImage();
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            SetImage();
        }

        private void SetImage()
        {
            Random temp = new Random();
            int i = temp.Next(1, 6);
            
            Image2.ImageUrl = "~/Pictures/" + i.ToString() + ".jpg";
        }
    }
}