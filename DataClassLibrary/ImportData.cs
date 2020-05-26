using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;


namespace DataClassLibrary
{
    public class ImportData
    {
        public DataSet Data { get; set; }

        //Loads json file into memory from file. If file is more than a day old or doesnt exist downloads a new file.
        public void LoadJson()
        {
            var url = "https://opendata.ecdc.europa.eu/covid19/casedistribution/json";
            var path = AppDomain.CurrentDomain.BaseDirectory + @"\" + "covid.json";
            string json = "";
            Data = new DataSet();
            using (WebClient wc = new WebClient())
            {
                var currentDate = DateTime.UtcNow;
                var lastDownloaded = File.GetLastWriteTimeUtc(path);

                if (lastDownloaded.DayOfYear == currentDate.DayOfYear && lastDownloaded.Year == currentDate.Year) // Check if the file is downloaded for the current day
                {
                    json = File.ReadAllText(path);
                }
                else
                {
                    Console.Write("Downloadning new data... ");
                    json = wc.DownloadString(url); //Download new file.
                    Console.Write("done!");
                }
                
                var resultObjects = AllChildren(JObject.Parse(json)).First(c => c.Type == JTokenType.Array && c.Path.Contains("records")).Children<JObject>();
                foreach (JObject result in resultObjects)
                {
                    DailyCovidReport report = result.ToObject<DailyCovidReport>();
                    Data.DailyCovidReports.Add(report);
                }
            }
            if (json != "")
            {
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\" + "covid.json", json);
            }
        }
        private static IEnumerable<JToken> AllChildren(JToken json)
        {
            foreach (var c in json.Children())
            {
                yield return c;
                foreach (var cc in AllChildren(c))
                {
                    yield return cc;
                }
            }
        }
    }
}
