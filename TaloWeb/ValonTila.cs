//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TaloWeb
{
    using System;
    using System.Collections.Generic;
    
    public partial class ValonTila
    {
        public int ValonTilaID { get; set; }
        public Nullable<int> ValoID { get; set; }
        public string valonTila1 { get; set; }
        public string ValonMaara { get; set; }
        public Nullable<System.DateTime> PVM { get; set; }
    
        public virtual Valot Valot { get; set; }
    }
}
