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


    }
}