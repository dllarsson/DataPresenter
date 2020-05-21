using System;
using System.Collections.Generic;

namespace DataClassLibrary
{
    public class DataSet
    {
        public DateTime LastUpdated { get; set; }
        public List<DailyCovidReport> DailyCovidReports { get; set; } = new List<DailyCovidReport>();
    }
}
