using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlite.Classes
{
    class states
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]

        public int idstate { get; set; }
        public string name { get; set; }
        public string status { get; set; }
    }

    class cities
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]

        public int idcity { get; set; }
        public int idstate { get; set; }
        public string name { get; set; }
        public string status { get; set; }
    }
    class med_medicine
    {
        public int idmedicine { get; set; }
        public string name { get; set; }
        public string concentration { get; set; }
        public string units { get; set; }
        public string price { get; set; }
        public string cat { get; set; }
        public string status { get; set; }
    }
    class drugstores 
    {
        public int iddrugstore { get; set; }
        public int idcity { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string address { get; set; }
        public string telephones { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double rating { get; set; }
        public string status { get; set; }
    }
    public class medDrug
    {
        public int idMeddrug { get; set; }
        public int idmedicine { get; set; }
        public int iddrugstore { get; set; }
        public string status { get; set; }
    }
}
