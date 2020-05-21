using DataClassLibrary;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ConsoleApp
{
    public class SeachEngine
    {
        public string SearchCountry(string searchInput, DataSet dataSet)
        {
            searchInput = FormatSearchString(searchInput);
            int totalCases = 0;
            int totalDeaths = 0;
            if (dataSet.DailyCovidReports != null)
            {
                foreach (var item in dataSet.DailyCovidReports)
                {
                    if (item.countriesAndTerritories == searchInput)
                    {
                        totalCases += item.cases;
                        totalDeaths += item.deaths;
                    }
                }
            }
            return searchInput.ToUpper() + " has " + totalCases + " total cases" + " and " + totalDeaths + " total deaths.";
        }



        public string CompareCountries(string firstCountry, string secondCountry, DataSet dataSet)
        {
            firstCountry = FormatSearchString(firstCountry);
            secondCountry = FormatSearchString(secondCountry);
            int totalCases = 0;
            int totalDeaths = 0;
            decimal deathsPerMillion = 0;
            int totalCases2 = 0;
            int totalDeaths2 = 0;
            decimal deathsPerMillion2 = 0;
            int pop = 0;
            int pop2 = 0;
            if (dataSet.DailyCovidReports != null)
            {
                foreach (var item in dataSet.DailyCovidReports)
                {
                    if (item.countriesAndTerritories.ToLower() == firstCountry.ToLower())
                    {
                        totalCases += item.cases;
                        totalDeaths += item.deaths;
                        pop = int.Parse(item.popData2018);
                    }
                    if (item.countriesAndTerritories.ToLower() == secondCountry.ToLower())
                    {
                        totalCases2 += item.cases;
                        totalDeaths2 += item.deaths;
                        pop2 = int.Parse(item.popData2018);
                    }
                }
                if (totalCases == 0 || totalCases2 == 0)
                {
                    return "countries not found";
                }
            }
            deathsPerMillion = totalDeaths / (pop/1000000);
            deathsPerMillion2 = totalDeaths2 / (pop2/1000000);

            if (deathsPerMillion > deathsPerMillion2)
            {
                decimal differancePresentage = (deathsPerMillion - deathsPerMillion2) / deathsPerMillion2;
                var diff = differancePresentage.ToString("P1", System.Globalization.CultureInfo.InvariantCulture);
                return $"{firstCountry} has {totalDeaths} total deaths and {deathsPerMillion} deaths per million. " +
                    $"{secondCountry} has {totalDeaths2} total deaths and {deathsPerMillion2} deaths per million.\n{firstCountry} has {diff} more deaths per million.";
            }
            else
            {
                decimal differancePresentage = (deathsPerMillion2 - deathsPerMillion) / deathsPerMillion;
                var diff = differancePresentage.ToString("P1", System.Globalization.CultureInfo.InvariantCulture);

                return $"{firstCountry} has {totalDeaths} total deaths and {deathsPerMillion} deaths per million. " +
                    $"{secondCountry} has {totalDeaths2} total deaths and {deathsPerMillion2} deaths per million.\n{secondCountry} has {diff} more deaths per million.";
            }

        }


        public string FormatSearchString(string input)
        {
            StringBuilder sr = new StringBuilder(input);
            
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ')
                {
                    sr[i] = '_';
                }
            }
            sr[0] = char.ToUpper(sr[0]);
            return sr.ToString();
        }
    }
}
