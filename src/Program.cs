using System;
using System.Security.Cryptography.X509Certificates;

namespace OOP 
{
    public class Program
    {
        public static void Main()
        {


            Console.WriteLine("Welcome to the AIRUFV management system"); 

            
            Airport airport = new Airport(2,0); // Creates the airport, variables to be defined later 
            airport.PrintMenu(); // Prints menu options


        }
    }
}
