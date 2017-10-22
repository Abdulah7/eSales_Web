using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace eProdajaServis.Data
{

    public class Servis
    {

        public static int TotalRows;
        public static void InsertUsluge(Usluge u)
        {
            Connection.dm.insertUsluge(u.Naziv, u.Cijena, u.Komentar);
        }
        public static void insertSERVIS(Korisnici s)
        {
            try
            {
                Connection.dm.insertServis(s.Naziv, s.Adresa, s.Telefon, s.Email, s.Status, s.LozinkaHash, s.LozinkaSalt, s.ImeKorisnika);
            }
            catch (EntityException v)
            {
                Util.PomocnaKlasa.Handler(v);

            }






        }

        public static void insertIZVRSENEUSLUGE(IzvrseneUsluge i)
        {
            Connection.dm.insertIzvrseneUsluge(i.ServisID, i.UslugaID);
        }
        public static List<Korisnici> getAllSERVIS()
        {

            List<Korisnici> s = Connection.dm.getAllServis().ToList();
            Korisnici d = new Korisnici();

            d.ServisID = 0;
            d.Naziv = "";
            s.Insert(0, d);
            return s;

        }
        public static List<Usluge> getAllUSSLUGE()
        {
            List<Usluge> s = Connection.dm.getAllUsluge().ToList();
            Usluge d = new Usluge();

            d.UslugaID = 0;
            d.Naziv = "";
            s.Insert(0, d);
            return s;

        }
        public static Korisnici SelectImeKorisnika(string ime, string lozinka)
        {
            Korisnici s = Connection.dm.selectKorisnickoIme(ime).FirstOrDefault();


            if (s != null)
            {

                if (Util.UIHelper.GenerateHash(lozinka, s.LozinkaSalt) == s.LozinkaHash)
                {


                    return s;
                }


            }
            return null;




        }
        public static Kupci SelectIME(string ime, string lozinka)
        {
            Kupci s = Connection.dm.selectIme(ime).FirstOrDefault();


            if (s != null)
            {

                if (Util.UIHelper.GenerateHash(lozinka, s.LozinkaSalt) == s.LozinkaHash)

                    return s;
                else
                    throw new Exception("Unijeli ste pogrešnu lozinku.");



            }
            return null;




        }
        public static List<Korisnici> esp_SelektBy_Name(string imeKorisnika)
        {
            return Connection.dm.esp_select_by_Name(imeKorisnika).ToList();
        }
        public static void updateStatus(int servisId, bool status)
        {
            Connection.dm.esp_update_status(servisId, status);
        }
        public static Korisnici seletBYId(int servisId)
        {
            return Connection.dm.esp_ServisSelectID(servisId).First();
        }
        public static void UpdateServis(Korisnici s)
        {
            Connection.dm.Servis_Update(s.ServisID, s.Naziv, s.Adresa, s.Telefon, s.Email);
        }
        public static void ResetLozninka(Korisnici s)
        {
            Connection.dm.Servis_IzmjenaPassworda(s.ServisID, s.LozinkaSalt, s.LozinkaHash);
        }
        public static List<Model> GetModel()
        {
            List<Model> m = Connection.dm.Model.OrderBy(x => x.VrstaModela).ToList();

            Model b = new Model();
            b.ModelID = 0;
            b.Naziv = "";

            m.Insert(0, b);
            return m;

        }
        public static List<Korisnici> GetServis()
        {
            List<Korisnici> temp = Connection.dm.SelectServis().ToList();

            Korisnici b = new Korisnici();
            b.ServisID = 0;
            b.Naziv = "";

            temp.Insert(0, b);
            return temp;


        }
        public static List<SelectIDAuto_Result> getVozilaAll(int m)
        {
            return Connection.dm.SelectIDAuto(m).ToList();
        }
        public static void insertVOZILA(Vozilo v)
        {
            Connection.dm.insertVozilo(v.ServisID, v.ModelID, v.Naziv, v.Boja, v.Godiste, v.VrstaMotora, v.EmisijaCO2, v.Slika, v.SlikaThumg, v.Cijena);
        }
        public static List<Model> getModelWeb()
        {
            List<Model> temp = Connection.dm.Model.OrderBy(x => x.Naziv).ToList();
            Model d = new Model();
            d.ModelID = 0;
            d.Naziv = "";

            temp.Insert(0, d);
            return temp;
        }
        public static List<VOZILA_MODEL_Result> GetVoziloModel(int modelid, string naziv, int offset, int maxrows)
        {

            System.Data.Objects.ObjectParameter total = new System.Data.Objects.ObjectParameter("TotalRows", 0);

            List<VOZILA_MODEL_Result> model = Connection.dm.VOZILA_MODEL(modelid, naziv, offset, maxrows, total).ToList();

            TotalRows = Convert.ToInt32(total.Value);
            return model;

        }
        public static List<GETDIJELOVE_Result> getDioComplpex(string naz, int of,  int maxrow)
        {
            System.Data.Objects.ObjectParameter total = new System.Data.Objects.ObjectParameter("TotalRows", 0);
            List<GETDIJELOVE_Result> dio = Connection.dm.GETDIJELOVE(naz, of,  maxrow, total).ToList();
            TotalRows = Convert.ToInt32(total.Value);
            return dio;


        }
        public static Vozilo getVoziloID(int v)
        {

            return Connection.dm.GetVoziloID(v).FirstOrDefault();
        }
        public static void KupciInsert(Kupci k)
        {

            Connection.dm.insertKupac(k.Ime, k.Prezime, k.DatumRegistracije, k.Email, k.LozinkaHash, k.LozinkaSalt);
        }

        public static void insertNaruzdba(Narudzba narudzba, string KorIme)
        {
           

            narudzba.KupacID = Connection.dm.selectIme(KorIme).First().KupacID;

            Connection.dm.Narudzba.Add(narudzba);
            Connection.dm.SaveChanges();
        }
        public static string GetMaxBrojNarudbi()
        {
            Narudzba lastOrder = Connection.dm.Narudzba.OrderByDescending(x => x.NarudzbaID).Take(1).FirstOrDefault();

            if (lastOrder != null)
                return lastOrder.BrojNarudzbe;

            return "0-yyyy";
        }

       
        public static List<Racun> SelectRacunByDatum(DateTime d,DateTime dat)
        {
            return Connection.dm.RacunSelectByDatum(d,dat).ToList();
        }
        public static List<Dijelovi> getDetails()
        {
            List<Dijelovi> temp = Connection.dm.Dijelovi.OrderBy(x => x.Naziv).ToList();
            Dijelovi d = new Dijelovi();
            d.DijeloviID = 0;
            d.Naziv = "";

            temp.Insert(0, d);

            return temp;
        }
        public static List<Dijelovi> getALLDijelovi(string dd)
        {
             return    Connection.dm.GEtNazivDijelovaALl(dd).ToList();

        

        }
        public static List<Korisnici> GETSERVISALL()
        {
            List<Korisnici> temp = Connection.dm.Korisnici.OrderBy(x => x.Naziv).ToList();
            Korisnici d = new Korisnici();
            d.ServisID = 0;
            d.Naziv = "";

            temp.Insert(0, d);

            return temp;
        }
        public static Dijelovi getdijelovI (int d)
        {
            return Connection.dm.GETDijeloviID(d).FirstOrDefault();
            
        }
       
        public static void UGradjeniDijelovInsert(UgradjeniDijelovi u)
        {
            Connection.dm.InsertUgradjeniDijelovi(u.ServisID, u.DijeloviID, u.Kolicina);


        }
        public static List<Dijelovi> GetDijelove()
        {
            List<Dijelovi> temp = Connection.dm.Dijelovi.OrderBy(x => x.Naziv).ToList();
            Dijelovi d = new Dijelovi();
            d.DijeloviID = 0;
            d.Naziv = "";

            temp.Insert(0, d);

            return temp;
        }

        public static void RacunInsert(Racun r)
        {
            Connection.dm.InsertRacun(r.ServisID, r.Opis, r.Cijena, r.Komentar, r.PDV, r.Ukupno, r.NacinIsporuke, r.DatumFakture, r.DatumIsporuke,r.PlacanjeID);
        }
        public static List<Proizvodjac> GetProizvodjac()
        {
            List<Proizvodjac> temp = Connection.dm.Proizvodjac.OrderBy(x => x.NazivProizvodjaca).ToList();
            Proizvodjac d = new Proizvodjac();
            d.ProizvodjacID = 0;
            d.NazivProizvodjaca = "";

            temp.Insert(0, d);

            return temp;
        }
        public static void ModelInsert(Model m)
        {
            Connection.dm.InsertModel(m.ProizvodjacID, m.Naziv, m.VrstaModela, m.Kolicina);
        }
        public static void ProizovdjacInsert(Proizvodjac p)
        {
            Connection.dm.InsertProizvodjac(p.NazivProizvodjaca, p.Adresa, p.Telefon, p.Email);
        }

        public static List<Vozilo> PretragaAUTA(string naziv)
        {
            return Connection.dm.PretragaAuta(naziv).ToList();

        }
        public static void BrisiAuto(int auto)
        {
            Connection.dm.BrisanjeAuta(auto);
        }
        public static List<Narudzba> getNarudzbe(string brojnaruzdbe)
        {
            return Connection.dm.PretragaNarudzbi(brojnaruzdbe).ToList();
        }
        public static List<NarudzbaStavke> getNarudzbeStavke()
        {
            return Connection.dm.PretragaNarudzbiStavki().ToList();
        }
        public static void BrisiNaruzbu(int auto)
        {
            Connection.dm.BrisiNarudzbe(auto);
        }
        public static void BrisiStavkeNarudzbe(int auto)
        {
            Connection.dm.BrisiNarudzbeStavke(auto);
        }
        public static void BrisiDijelove(int dioID)
        {
            Connection.dm.DijeloviDelete(dioID);
        }
        public static void BrisiUgradjeneDijelove(int ugradjeniID)
        {
            Connection.dm.UgradjeniDijeloviDelete(ugradjeniID);
        }
        public static List<Dijelovi> getDijeloveNaziv(string naziv)
        {
            return Connection.dm.DijeloviSearch(naziv).ToList();
        }
        public static List<UgradjeniDijelovi> getUgradjeniDijelovi()
        {
            return Connection.dm.UgradjeniDijeloviPretraga().ToList();
        }
        public static List<Kupci> getKupciALL(string ime)
        {
            return Connection.dm.SearchKupac(ime).ToList();
        }
        public static void KupacDelete(int kupacID)
        {
            Connection.dm.DeleteKupac(kupacID);
        }
        public static void DijeloviInsert(Dijelovi d)
        {
            Connection.dm.InsertDijelove(d.Naziv, d.Model, d.Zalihe, d.Cijena);
        }
        public static List<Vozilo> GetCarAll(string naziv)
        {
            return Connection.dm.ALLCars(naziv).ToList();

        }
        public static void Insert_Ocjene(Ocjene o)
        {
            Connection.dm.Ocjena_insert(o.KupacID, o.VoziloID, o.Ocjena, o.Datum);
        }
      
        public static Kupci KorisnikKupacIme(string ime)
        {
            return Connection.dm.selectKupacKorisinickoIme(ime).FirstOrDefault();
        }
     
        public static Kupci KupacID(int k)
        {
            return Connection.dm.getIDKupac(k).FirstOrDefault();
        }
        public static void NarudzbaUpdate(int narudzbaid, bool status)
        {
            Connection.dm.updateNarudzba(narudzbaid, status);
        }
        public static List<Narudzba> getNarudzbe()
        {
            return Connection.dm.getaLLNarudzbe().ToList();
        }
        public static void GEtStatus(int n, bool s)
        {
             Connection.dm.updateNarudzbaStatus(n, s);
        }
        public static List<Narudzba> getAllNarudzbaH()
        {
           return Connection.dm.getNArudzbaHistori().ToList();
        }
        public static Narudzba getAllNarudzbaKonacno(int g)
        {
            return Connection.dm.getNArudzbaIDHistoriy(g).FirstOrDefault();
        }
        public static List<NarudzbaStavke> getStavkeNarudzba()
        {
            return Connection.dm.GetAllStavke().ToList();
        }
        public static List<NacinPlacanja> getPlacananje()
        {
            List<NacinPlacanja> temp= Connection.dm.NacinPlacanja.OrderBy(x => x.Naziv).ToList();
          
            NacinPlacanja d = new NacinPlacanja();
            d.PlacanjeID = 0;
            d.Naziv = "";

            temp.Insert(0, d);

            return temp;
        }
        public static List<Dijelovi> getDijeloviGRid()
        {
                return Connection.dm.Dijelovi.OrderBy(x=> x.Naziv).ToList();
            

        }
        public static Kupci getKupacIDNew(string k)
        {
            return Connection.dm.GetKupacIME(k).FirstOrDefault();
        }
        public static List<Kupci> getKupciIme()
        {
           List<Kupci> temp=  Connection.dm.Kupci.OrderBy(x => x.Ime).ToList();

            Kupci d = new Kupci();
            d.KupacID = 0;
            d.Ime = "Dodaj kupca";

            temp.Insert(0, d);

            return temp;

        }
        public static List<Vozilo> getAllVozila()
        {
            return Connection.dm.GEtALLAuta().ToList();
        }
        public static List<Kupci> KupciGET()
        {
           return  Connection.dm.Kupci.OrderBy(x => x.Ime).ToList();

        }
        public static List<Dijelovi> DijeloviGET()
        {
            return Connection.dm.Dijelovi.OrderBy(x => x.Naziv).ToList();
        }
        public static List<Racun> getRacun()
        {
            return Connection.dm.Racun.OrderBy(x => x.Opis).ToList();
        }

        public static Narudzba getIdNarudzba(int id)
        {

            return Connection.dm.GEtNarudzbaID(id).FirstOrDefault();
        }
        public static List<Vozilo> getvozilaAll()
        {
            List<Vozilo> temp = Connection.dm.Vozilo.OrderBy(x => x.Naziv).ToList();

            Vozilo d = new Vozilo();
            d.VoziloID = 0;
            d.Naziv = "Dodaj cijenu";

            temp.Insert(0, d);

            return temp;
        }
    }


}
