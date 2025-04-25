using System;
using System.Security.Cryptography.X509Certificates;

namespace OOP 
{
    public class Program
    {
        public static void Main()
        {


            Console.WriteLine("Welcome to the AIRUFV management system"); 

            
            Airport airport = new Airport(2,0); // Instantiates the Aiport; Number of Runways, Number of Aircrafts
            airport.PrintMenu(); // Prints menu options


        }
    }
}
