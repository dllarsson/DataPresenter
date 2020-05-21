using System;
using System.Collections.Generic;
using System.Text;

namespace DataClassLibrary
{
    public class DailyCovidReport
    {
        public string dateRep { get; set; }
        public string day { get; set; }
        public string month { get; set; }
        public string year { get; set; }
        public int cases { get; set; }
        public int deaths { get; set; }
        public string countriesAndTerritories { get; set; }
        public string geoId { get; set; }
        public string countryterritoryCode { get; set; }
        public string popData2018 { get; set; }
        public string continentExp { get; set; }
    }
}
