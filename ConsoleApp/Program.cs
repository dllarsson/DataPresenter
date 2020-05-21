using DataClassLibrary;
using System;

namespace ConsoleApp
{
    class Program
    {
        static DataSet currentData;
        static void Main(string[] args)
        {
            ImportData id = new ImportData();
            id.LoadJson();
            currentData = id.Data;
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
            switch (choice)
            {
                case "1":
                    Console.WriteLine(seachEngine.SearchCountry(Console.ReadLine(), currentData));
                    break;
                case "2":
                    Console.WriteLine(seachEngine.CompareCountries(Console.ReadLine(), Console.ReadLine(), currentData));
                    break;
                default:
                    break;
            }
        }
    }
}
