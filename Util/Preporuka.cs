using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eProdajaServis.Data;
namespace eProdajaServis.Util
{
    public static class Preporuka
    {
        public static Dictionary<int, List<Ocjene>> vozilo = new Dictionary<int, List<Ocjene>>();

        #region Item-based preporuka


        public static List<Vozilo> GetSlicneProizvode(int voziloID, int kupacID)
        {
            UcitajProizvode(voziloID, kupacID);

            List<Ocjene> ocjene = Connection.dm.Ocjene.Where(x => x.VoziloID == voziloID).OrderBy(x => x.KupacID).ToList();
            List<Ocjene> zajednickeOcjene1 = new List<Ocjene>();
            List<Ocjene> zajednickeOcjene2 = new List<Ocjene>();

            List<Vozilo> preporuceno = new List<Vozilo>();

            foreach (var item in vozilo)
            {
                foreach (Ocjene ocjena1 in ocjene)
                {
                    if (item.Value.Where(x => x.KupacID == ocjena1.KupacID).Count() != 0)
                    {
                        zajednickeOcjene1.Add(ocjena1);
                        zajednickeOcjene2.Add(item.Value.Where(x => x.KupacID == ocjena1.KupacID).First());
                    }
                }

                double slicnost = GetSlicnost(zajednickeOcjene1, zajednickeOcjene2);

                if (slicnost > 0.6)
                    preporuceno.Add(Servis.getVoziloID(item.Key));

                zajednickeOcjene1.Clear();
                zajednickeOcjene2.Clear();

            }



            return preporuceno;
        }

        public static void UcitajProizvode(int voziloID, int k)
        {
            List<NarudzbaStavke> NaruceneStavke = new List<NarudzbaStavke>();
            NaruceneStavke = Connection.dm.NarudzbaStavke.Where(x => x.Narudzba.KupacID == k).ToList();
            List<Vozilo> aktivniProizvodi = Connection.dm.Vozilo.Where(x=>  x.VoziloID != voziloID).ToList();
            if (k > 0)
            {
                foreach (var AktProizvod in aktivniProizvodi.ToList())
                {
                    foreach (var item in NaruceneStavke.ToList())
                    {
                        if (AktProizvod.VoziloID == item.VoziloID)
                            aktivniProizvodi.Remove(AktProizvod);
                    }

                }
            }


            List<Ocjene> ocjene = new List<Ocjene>();
            vozilo = new Dictionary<int, List<Ocjene>>();
            foreach (Vozilo item in aktivniProizvodi)
            {
                ocjene = Connection.dm.Ocjene.Where(x => x.VoziloID == item.VoziloID).OrderBy(x => x.KupacID).ToList();
                if (ocjene.Count > 0)
                    vozilo.Add(item.VoziloID, ocjene);
            }
        }

        public static double GetSlicnost(List<Ocjene> ocjene1, List<Ocjene> ocjene2)
        {
            if (ocjene1.Count != ocjene2.Count)
                return 0;

            int brojnik = 0;
            double int1 = 0;
            double int2 = 0;

            for (int i = 0; i < ocjene1.Count; i++)
            {
                brojnik +=Convert.ToInt32(ocjene1[i].Ocjena * ocjene2[i].Ocjena);

                int1 +=Convert.ToDouble(ocjene1[i].Ocjena * ocjene1[i].Ocjena);
                int2 += Convert.ToDouble(ocjene2[i].Ocjena * ocjene2[i].Ocjena);
            }

            int1 = Math.Sqrt(int1);
            int2 = Math.Sqrt(int2);

            double nazivnik = int1 * int2;

            if (nazivnik != 0)
                return brojnik / nazivnik;

            return 0;

        }

        #endregion
    }
}
