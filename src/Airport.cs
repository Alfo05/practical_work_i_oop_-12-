using System;
namespace OOP
{
    public class Airport
    {
        // Array for runways the airport has 
        private Runway[] runways;

        // List of aircrafts in the Airport or bound for the Airport 
        private List<Aircraft> aircrafts;

        public Airport() 
        {
            runways = new Runway[1]; // We create 2 runways  

            aircrafts = new List<Aircraft>(); // We start to load the airplanes  
        }


    }
}