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
    
    public partial class UgradjeniDijelovi
    {
        public int UgradjeniID { get; set; }
        public Nullable<int> ServisID { get; set; }
        public Nullable<int> DijeloviID { get; set; }
        public Nullable<int> Kolicina { get; set; }
    
        public virtual Dijelovi Dijelovi { get; set; }
        public virtual Korisnici Korisnici { get; set; }
    }
}
