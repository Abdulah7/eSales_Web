using eProdajaServis.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;




namespace eProdaja_Web.Order
{
    public partial class Orders : System.Web.UI.Page
    {
       Narudzba bb = new Narudzba();

       
        public Narudzba narudzba
        {
            get { return (Narudzba) Session["narudzba"]; }
            set { Session["narudzba"] = value; }
        }
     
        private decimal iznosRacuna
        {
            set { Session["iznos"] = value; }
            get { return (decimal)Session["iznos"]; }
        }
        private decimal ukupno
        {
            set { Session["XX"] = value; }
            get { return (decimal)Session["XX"]; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        

            
            if (!IsPostBack)
            {

               

                    bindgrid();

                    narudzebe();



                   
            }

        }

       

      

       

        private void narudzebe()
        {
            GridView1.DataSource = Servis.getNarudzbe();

            GridView1.DataBind();
            
        }

      

        private void bindgrid()
        {
            if (narudzba != null)
            {
                narudzbaGrid.DataSource = narudzba.NarudzbaStavke;
                narudzbaGrid.DataBind();
                Label2.Text = Math.Round(iznosRacuna, 2).ToString() + " KM";
                Label4.Text =Math.Round(ukupno, 2).ToString() + " KM";

                
            }
        }

        protected void narudzbaiD_Click(object sender, EventArgs e)
        {
            if (narudzba !=null)
            {
                Servis.insertNaruzdba(narudzba, User.Identity.Name);
                narudzba = null;
                iznosRacuna = 0;
                ukupno = 0;
                narudzbaGrid.DataBind();
                Label2.Text = "0 KM";
                Label4.Text = "0 KM";

                HyperLink temp = (HyperLink)this.Master.FindControl("temp");

                temp.Text = "My Cart";

                GridView1.DataSource = Servis.getNarudzbe();
                GridView1.DataBind();
            }
            else
            {
                
            }
        }

  

      

        

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
            if(e.CommandName=="otkazi") 
            {

              int temp  = Convert.ToInt32(e.CommandArgument);

                Servis.NarudzbaUpdate(temp, true);

                
                Servis.GEtStatus(temp, false);


        
               

            }
        

            
              

         
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            narudzbaGrid.DataSource = null;
            narudzbaGrid.DataBind();

            
        }
    }
}