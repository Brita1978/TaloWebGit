using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaloWeb.Models
{
    public class TalonTilaModel
    {
        public int? TaloID { get; set; }
        public int TalonTilaID { get; set; }

        public string TalonNykyLampotila { get; set; }

        public string TalonTavoiteLampotila { get; set; }

        public string TalonSijainti { get; set; }




        public DateTime? PVM { get; set; }

        public virtual Talot Talot { get; set; }

        public virtual ICollection<TalonTila> TalonTila { get; set; }
        
    }
}