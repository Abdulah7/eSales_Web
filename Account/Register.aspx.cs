using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Membership.OpenAuth;

using eProdajaServis.Data;
using eProdajaServis.Util;
namespace eProdaja_Web.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        

        protected void Sacuvajbuton_Click(object sender, EventArgs e)
        {
            Kupci k = new Kupci();

            k.Ime = UserName.Text;
            k.Prezime = prezimeId.Text;
            k.DatumRegistracije = Convert.ToDateTime(DatumID.Text);
            k.Email = EmailID.Text;
            k.LozinkaSalt = UIHelper.GenerateSalt();
            k.LozinkaHash = UIHelper.GenerateHash(Password.Text, k.LozinkaSalt);


            Servis.KupciInsert(k);
        }


      
    }
}