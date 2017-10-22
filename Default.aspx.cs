using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

using eProdajaServis.Data;
namespace eProdaja_Web
{
    public partial class Default : Page
    {
      
    

               double kk=0.05;
               private List<GETDIJELOVE_Result> dijelovi;
        private List<VOZILA_MODEL_Result> vozilo;
        protected int n { get; set; }

        private Narudzba narudz = new Narudzba();
     public Narudzba narudzba
     {
        get { return (Narudzba) Session["narudzba"];}
        set { Session["narudzba"] =value ;}
        
       }
     private   decimal iznosRacuna
     {
         set { Session["iznos"] = value; }
         get { return (decimal)Session["iznos"]; }
     }
     private decimal  iznosPopust
     {
         set { Session["vv"] = value; }
         get { return (decimal)Session["vv"]; }
     }

     private decimal ukupno
     {
         set { Session["ll"] = value; }
         get { return (decimal)Session["ll"]; }
     }
     private decimal iznos
     {
         set { Session["nn"] = value; }
         get { return (decimal)Session["nn"]; }
     }
     private decimal iznos1
     {
         set { Session["bb"] = value; }
         get { return (decimal)Session["bb"]; }
     }
        protected void Page_Load(object sender, EventArgs e)
        
      
        {
            bindModel();
            //NarudzbaID.DataSource = Servis.getAllNarudzbaH();
            //NarudzbaID.DataBind();

      
        }

       

        private void bindModel()
        {
         vrstaModela.DataSource = Servis.getModelWeb();
         vrstaModela.DataBind();
        }

        private void bindGrid()
        {
            int voziloID = 0;
            if (vrstaModela.SelectedIndex > 0)
                voziloID = Convert.ToInt32(vrstaModela.SelectedValue);

            int offset = vozilaGrid.CurrentPageIndex * vozilaGrid.PageSize;
            vozilo = Servis.GetVoziloModel(voziloID, nazivInput.Text.Trim(), offset, vozilaGrid.PageSize);

            vozilaGrid.DataSource = vozilo;
            vozilaGrid.VirtualItemCount = Servis.TotalRows;

            vozilaGrid.DataBind();

        }

        protected void traziButton_Click(object sender, EventArgs e)
        {

            vozilaGrid.CurrentPageIndex = 0;
            bindGrid();
        }

      

        protected void vozilaGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemIndex != -1)
            {
                Image i = (Image)e.Item.FindControl("ImageID");
                i.ImageUrl = "ImageHandler.ashx?VOZILOID=" + vozilo[e.Item.ItemIndex].VoziloID;
            }
        }

        protected void vozilaGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            vozilaGrid.CurrentPageIndex = e.NewPageIndex;
            bindGrid();
        }

        protected void vozilaGrid_ItemCommand(object source, DataGridCommandEventArgs e)
        {


            if (e.CommandName == "AddToCart")
            {
                int vozId = Convert.ToInt32(e.CommandArgument);

                TextBox p = (TextBox)e.Item.FindControl("kk");
                int broj = Convert.ToInt32(p.Text);






                if (narudzba == null)
                {
                    narudzba = new Narudzba();


                    string maxbr = Servis.GetMaxBrojNarudbi();
                    int r = Convert.ToInt32(maxbr.Split('-')[0]) + 1;
                    narudzba.BrojNarudzbe = r + "-" + DateTime.Now.Year;
                    narudzba.Datum = DateTime.Now;



                    narudzba.Otkazano = false;
                    narudzba.Status = true;


                    iznosRacuna = 0;

                    iznosPopust = 0;
                    ukupno = 0;
                    iznos1 = 0;
                    iznos = 0;
                    iznos1 += broj;

                }
                foreach (NarudzbaStavke k in narudzba.NarudzbaStavke)
                {

             


                    if (k.VoziloID == vozId)
                    {
                        iznos1 = 0;
                        k.Kolicina += broj;
                        iznosRacuna += Convert.ToDecimal(k.Vozilo.Cijena* broj);
                        iznos1 += broj;


                        for (int i = 1; i <= iznos1; i++)
                        {
                            if (i % 3 == 0)
                            {
                                iznosPopust = Convert.ToDecimal(k.Vozilo.Cijena * Convert.ToDecimal(kk));
                                ukupno = iznosRacuna;
                                ukupno -= iznosPopust;


                            }
                            if (i == iznos1)
                            {
                                iznos1 = 0;
                                return;
                            }
                        }

                        


                    }


                }

                NarudzbaStavke stavka = new NarudzbaStavke();

                stavka.Kolicina = broj;
                stavka.Vozilo = Servis.getVoziloID(vozId);
                stavka.VoziloID = vozId;

                narudzba.NarudzbaStavke.Add(stavka);

                iznosRacuna +=Convert.ToDecimal(broj * stavka.Vozilo.Cijena);
                iznos += broj;

                for (int i = 1; i <= iznos; i++)
                {
                    if (i % 3 == 0)
                    {
                        iznosPopust =Convert.ToDecimal(stavka.Vozilo.Cijena) * Convert.ToDecimal(kk);
                        ukupno = iznosRacuna;
                        ukupno -= iznosPopust;


                    }
                    if (i == iznos)
                    {
                        iznos = 0;
                        return;
                    }
                }



                HyperLink temp = (HyperLink)this.Master.FindControl("temp");
                temp.Text = string.Format("My Cart({0})", narudzba.NarudzbaStavke.Count);
           

            }
      
        }

       

       
        
      

   

       

      
      

    }
}