using System;
namespace OOP
{
    public class Airport
{
    private Runway[] runways;  // Array de pistas
    private Aircraft[] aircrafts;  // Array de aviones

    public Airport(int numberOfRunways, int numberOfAircrafts)
    {
        runways = new Runway[numberOfRunways];
        aircrafts = new Aircraft[numberOfAircrafts];

        // Inicializamos las pistas
        for (int i = 0; i < numberOfRunways; i++)
        {
            runways[i] = new Runway($"Runway-{i + 1}");
        }
    }


    }
}