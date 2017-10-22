using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eProdajaServis.Data;
namespace eProdaja_Web.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];

            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void Loginbox_Authenticate(object sender, AuthenticateEventArgs e)
        {
            Kupci k = Servis.SelectIME(Loginbox.UserName, Loginbox.Password);

            try
            {
                if (k == null)
                {
                    Loginbox.FailureText = "Korisnik nije pronađen ";
                    e.Authenticated = false;
                }
                else
                    e.Authenticated = true;
            }
            catch (Exception ey)
            {
                Loginbox.FailureText = ey.Message;
                e.Authenticated = false;
                
            }
        }


    }
}