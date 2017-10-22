using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using eProdajaServis.Data;
using eProdajaServis.Util;


namespace eProdaja_Web.Vozila

{
    public partial class Car : System.Web.UI.Page
    {
        public Vozilo OdabraniProizvod { get; set; }

        protected List<Vozilo> preporuceniProizvodi;

        Vozilo proizvodPrikaz = new Vozilo();

        Vozilo voziloPrikaz = new Vozilo();
        protected int proizvodID { get; set; }
        Vozilo vozilo;

        protected bool kupioNarucio { get; set; }
        protected bool vecOcjenjivao { get; set; }

        public Narudzba narudžba
        {
            get { return (Narudzba)Session["narudzba"]; }
            set { Session["narudzba"] = value; }

        }

        decimal iznosRacuna
        {
            set { Session["iznos"] = value; }
            get { return (decimal)Session["iznos"]; }

        }




        protected void Page_Load(object sender, EventArgs e)
        {

            proizvodID = Convert.ToInt32(Request.QueryString["VoziloID"]);





            if (proizvodID > 0)
            {


                proizvodPrikaz = Servis.getVoziloID(proizvodID);
                OdabraniProizvod = proizvodPrikaz;

                preporuceniProizvodi = new List<Vozilo>();

                Kupci k = new Kupci();
                k = Servis.KorisnikKupacIme(User.Identity.Name);
                if (k != null)
                    preporuceniProizvodi = Preporuka.GetSlicneProizvode(proizvodPrikaz.VoziloID, k.KupacID);
                else
                    preporuceniProizvodi = Preporuka.GetSlicneProizvode(proizvodPrikaz.VoziloID, 0);




                BindPreporuceniProizvodi();



                BindProsjecnaOcjena();







            }

        }


       

        private void BindProsjecnaOcjena()
        {

            switch (proizvodID)
            {
                case 1: ddlOcjene.Text = ("Proizvod je loš!");
                    break;
                case 2: ddlOcjene.Text = ("Proizvod je ispodprosječan");
                    break;
                case 3: ddlOcjene.Text = ("Proizvod dobar");
                    break;
                case 4: ddlOcjene.Text = ("Proizvod je vrlo dobar");
                    break;
                case 5: ddlOcjene.Text = ("Proizvod je odličan!");
                    break;

            }



        }

        private void BindPreporuceniProizvodi()
        {
            Grid.DataSource = preporuceniProizvodi;
            Grid.DataBind();


        }


        protected void btnOcjeni_Click(object sender, EventArgs e)
        {

            Kupci k = new Kupci();
            k = Servis.KorisnikKupacIme(User.Identity.Name);

            if (Convert.ToInt32(ddlOcjene.SelectedValue) != 0)
            {
                Ocjene ocjena = new Ocjene();
                ocjena.KupacID = k.KupacID;
                ocjena.Ocjena = Convert.ToInt32(ddlOcjene.SelectedValue);
                ocjena.VoziloID = proizvodID;
                ocjena.Datum = DateTime.Now;
                Servis.Insert_Ocjene(ocjena);
                BindProsjecnaOcjena();
                BindPreporuceniProizvodi();




                Label12.Text = "Ocjenili ste auto!";
                ddlOcjene.SelectedValue = "0";

            }
            else
            {
                Label12.Text = "Molimo, odaberite ocjenu iz liste!";
            }

        }










        protected void Grid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {



            double suma = 0;
            int b = 0;
            double kk = 0;

            if (e.Item.ItemIndex != -1)
            {
                System.Web.UI.WebControls.Image image = (System.Web.UI.WebControls.Image)e.Item.FindControl("imageID");
                image.ImageUrl = "/ImageHandler.ashx?VOZILOID=" + preporuceniProizvodi[e.Item.ItemIndex].VoziloID;




                foreach (Ocjene mm in preporuceniProizvodi[e.Item.ItemIndex].Ocjene)
                {

                    suma += mm.Ocjena.Value;
                    b++;

                    kk = suma / b;



                }

                Label label = (Label)e.Item.FindControl("Label5");
                label.Text = kk.ToString();

             



            }

        }

        protected void Grid_ItemCommand(object source, DataGridCommandEventArgs e)
        {
         
           
                int temp = Convert.ToInt32(e.CommandArgument);

                vozilo = Servis.getVoziloID(temp);

                Label17.Text = vozilo.Boja;
                Label19.Text = vozilo.EmisijaCO2;

                Label22.Text = vozilo.Naziv;

                Label24.Text = vozilo.VrstaMotora;
                Label26.Text = vozilo.Cijena.ToString();
                Label28.Text = vozilo.Godiste.ToString();


             

             

            
        }

       
    }
}