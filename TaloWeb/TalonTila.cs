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
    
    public partial class TalonTila
    {
        

        public int TalonTilaID { get; set; }
        public Nullable<int> TaloID { get; set; }
        public string TalonTavoiteLampotila { get; set; }
        public string TalonNykyLampotila { get; set; }
        public Nullable<System.DateTime> PVM { get; set; }

        
        public virtual Talot Talot { get; set; }
    }
}
