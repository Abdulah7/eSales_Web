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
    
    public partial class PretragaAuta_Result
    {
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
    }
}
