using System;
namespace OOP
{
    public class Airport
{
    private Runway[] runways;  // Runways array
    private Aircraft[] aircrafts;  // Aircrafts array

    public Airport(int numberOfRunways, int numberOfAircrafts)
    {
        runways = new Runway[numberOfRunways]; // Creation of arrays specific for the amount of runways 
        aircrafts = new Aircraft[numberOfAircrafts]; // Creation of arrays for specific amount of airplanes

        // Initialization of runways
        for (int i = 0; i < numberOfRunways; i++)
        {
            runways[i] = new Runway($"Runway-{i + 1}"); // We only create the runways now, since we know there are a fixed number 
        }
    }

    public void PrintMenu() // Prints the management system for the user to select an option
    {


        Console.WriteLine("_________________________________");
        Console.WriteLine("|+++++++++++ Air UFV +++++++++++|");
        Console.WriteLine("|-------------------------------|");
        Console.WriteLine("| Choose an option              |");
        Console.WriteLine("| 1. Load flight from file      |");
        Console.WriteLine("| 2. Load flight Manually       |");
        Console.WriteLine("| 3. Start Simulation(Manual)   |");
        Console.WriteLine("| 4. Start Simulation(Automatic)|");
        Console.WriteLine("| 5. Exit                       |");
        Console.WriteLine("|-------------------------------|");
        Console.WriteLine("|+++++++++++++++++++++++++++++++|");
        Console.WriteLine("|-------------------------------|");
    }


    }
}