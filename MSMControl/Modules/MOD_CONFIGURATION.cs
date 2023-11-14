using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSMControl.Modules
{
    public class MOD_CONFIGURATION
    {
        public string ToPerform { get; set; }
        public int CID { get; set; }
        public int YearID { get; set; }
        public string Current_Year { get; set; }
        public bool? IsAdmin { get; set; }
        public int? ColorID { get; set; }
        public string Background { get; set; }
        public decimal? VAT { get; set; }
        public decimal? Discount { get; set; }
        public bool? checkDate { get; set; }
        public bool? notes { get; set; }
        public bool? returnNotes { get; set; }
        public bool? printMessage { get; set; }
        public bool? autoPrint { get; set; }
        public int? compType { get; set; }
        public string billMsg { get; set; }
    }
}
