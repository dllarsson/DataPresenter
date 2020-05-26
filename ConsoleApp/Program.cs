using DataClassLibrary;
using System;

namespace ConsoleApp
{
    class Program
    {
        static DataSet currentData;
        static void Main(string[] args)
        {

            while (true)
            {
                Menu();
            }
        }
        public static void Menu()
        {
            SeachEngine seachEngine = new SeachEngine();
            Console.WriteLine("1 = Search country.");
            Console.WriteLine("2 = Compare country");
            var choice = Console.ReadLine();
            ImportData id = new ImportData();
            id.LoadJson();
            currentData = id.Data;
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Search by country name: ");
                    Console.WriteLine(seachEngine.SearchCountry(Console.ReadLine(), currentData));
                    break;
                case "2":
                    Console.WriteLine("First country: ");
                    var first = Console.ReadLine();
                    Console.WriteLine("Second country: ");
                    var second = Console.ReadLine();
                    Console.WriteLine(seachEngine.CompareCountries(first, second, currentData));
                    break;
                default:
                    break;
            }
        }
    }
}
