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
    
    public partial class Ocjene
    {
        public int OcjenaId { get; set; }
        public Nullable<int> KupacID { get; set; }
        public Nullable<int> VoziloID { get; set; }
        public Nullable<int> Ocjena { get; set; }
        public Nullable<System.DateTime> Datum { get; set; }
    
        public virtual Kupci Kupci { get; set; }
        public virtual Vozilo Vozilo { get; set; }
    }
}
