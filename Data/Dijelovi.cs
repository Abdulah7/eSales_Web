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
    
    public partial class Dijelovi
    {
        public Dijelovi()
        {
            this.NarudzbaStavke = new HashSet<NarudzbaStavke>();
            this.UgradjeniDijelovi = new HashSet<UgradjeniDijelovi>();
        }
    
        public int DijeloviID { get; set; }
        public string Naziv { get; set; }
        public string Model { get; set; }
        public string Zalihe { get; set; }
        public Nullable<double> Cijena { get; set; }
    
        public virtual ICollection<NarudzbaStavke> NarudzbaStavke { get; set; }
        public virtual ICollection<UgradjeniDijelovi> UgradjeniDijelovi { get; set; }
    }
}