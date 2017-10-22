using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eProdajaServis.Data;

namespace eProdaja_Web
{

    public partial class WebDijelovi : System.Web.UI.Page
    {
        double kk = 0.05;
        private List<GETDIJELOVE_Result> dijelovi;
     
        protected int n { get; set; }

        private Narudzba narudz = new Narudzba();
        public Narudzba narudzba
        {
            get { return (Narudzba)Session["narudzba"]; }
            set { Session["narudzba"] = value; }

        }
        private decimal iznosRacuna
        {
            set { Session["iznos"] = value; }
            get { return (decimal)Session["iznos"]; }
        }
        private decimal iznosPopust
        {
            set { Session["vv"] = value; }
            get { return (decimal)Session["vv"]; }
        }

        private decimal ukupno
        {
            set { Session["XX"] = value; }
            get { return (decimal)Session["XX"]; }
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


        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dijelovibind()
        {
            int offset = gridDijelovi.CurrentPageIndex * gridDijelovi.PageSize;
            dijelovi = Servis.getDioComplpex(TextBox1.Text.Trim(), offset, gridDijelovi.PageSize);

            gridDijelovi.DataSource = dijelovi;
            gridDijelovi.VirtualItemCount = Servis.TotalRows;

            gridDijelovi.DataBind();
        }


        protected void Button2_Click1(object sender, EventArgs e)
        {
            dijelovibind();
        }

        protected void gridDijelovi_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            gridDijelovi.CurrentPageIndex = e.NewPageIndex;
            dijelovibind();

        }

        protected void gridDijelovi_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "dio")
            {
                int dijeloviid = Convert.ToInt32(e.CommandArgument);

                TextBox p = (TextBox)e.Item.FindControl("hh");
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




                    if (k.DijeloviID == dijeloviid)
                    {
                        iznos1 = 0;
                        k.Kolicina += broj;
                        iznosRacuna += Convert.ToDecimal(k.Dijelovi.Cijena) * broj;
                        iznos1 += broj;


                        for (int i = 1; i <= iznos1; i++)
                        {
                            if (i % 3 == 0)
                            {
                                iznosPopust = Convert.ToDecimal(k.Dijelovi.Cijena) * Convert.ToDecimal(kk);
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
                stavka.Dijelovi = Servis.getdijelovI(dijeloviid);
                stavka.DijeloviID = dijeloviid;

                narudzba.NarudzbaStavke.Add(stavka);

                iznosRacuna += broj * Convert.ToDecimal(stavka.Dijelovi.Cijena);
                iznos += broj;

                for (int i = 1; i <= iznos; i++)
                {
                    if (i % 3 == 0)
                    {
                        iznosPopust = Convert.ToDecimal(stavka.Dijelovi.Cijena) * Convert.ToDecimal(kk);
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