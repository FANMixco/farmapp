using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pillsSV.Classes
{
    public class result
    {
        public string total { get; set; }
    }

    public class status
    {
        public int idstatus { get; set; }
        public DateTime updateCity { get; set; }
        public DateTime updateState { get; set; }
        public DateTime updateDrugstore { get; set; }
        public DateTime updateMedicine { get; set; }
    }

    public class comments
    {
        public string name { get; set; }
        public string comment { get; set; }
        public int rating { get; set; }
        public DateTime rDate { get; set; }
    }

    public class rates
    {
        public int rating { get; set; }
    }
}