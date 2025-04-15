using System;
using System.Security.Cryptography.X509Certificates;

namespace OOP 
{
    public class Program
    {
        public static void Main()
        {


            Console.WriteLine("Welcome to the AIRUFV management system"); 

            
            Airport airport = new Airport(0,0); // Creates the airport, variables to be defined later 
            airport.PrintMenu(); // Prints menu options

            Runway runway = new Runway("Runway-1");
            Aircraft aircraft = new Aircraft("A1", Aircraft.AircraftState.InFlight, 0, 0, 1000, 0.1, 500);


        }
    }
}
