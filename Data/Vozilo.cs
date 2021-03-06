//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eProdajaServis.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vozilo
    {
        public Vozilo()
        {
            this.NarudzbaStavke = new HashSet<NarudzbaStavke>();
            this.Ocjene = new HashSet<Ocjene>();
        }
    
        public int VoziloID { get; set; }
        public Nullable<int> ServisID { get; set; }
        public string Naziv { get; set; }
        public string Godiste { get; set; }
        public string Boja { get; set; }
        public string VrstaMotora { get; set; }
        public string EmisijaCO2 { get; set; }
        public Nullable<int> ModelID { get; set; }
        public byte[] SlikaThumg { get; set; }
        public byte[] Slika { get; set; }
        public Nullable<decimal> Cijena { get; set; }
    
        public virtual Korisnici Korisnici { get; set; }
        public virtual Model Model { get; set; }
        public virtual ICollection<NarudzbaStavke> NarudzbaStavke { get; set; }
        public virtual ICollection<Ocjene> Ocjene { get; set; }
    }
}
