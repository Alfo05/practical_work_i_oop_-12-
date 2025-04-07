using System; 

namespace OOP 
{

    public class Runway 
    {

        public string id { get; set; } // Number of the runway 
        public RunwayStatus runwayStatus { get; set; } // Status of the Runway (Free, Ocupied)
        public Aircraft CurrentAircraft { get; set; } // Information about the Aircraft if occuping the Runway
        public int TicksToFree { get; set; } // The amount of ticks needed for a Aircraft to exit the Runway

        public enum RunwayStatus // Possible states of the Runway
        {
            Free,
            Ocupied
        }

    public Runway(string id)
    {
        id = id; 
        runwayStatus = RunwayStatus.Free;  // By default the runway is free
        CurrentAircraft = null; // We start with runways with no planes
        TicksToFree = 3; // By default it takes 3 ticks to clear a runway 
    }
    public void LandingAircraft(Aircraft aircraft)
    {
        if (IsFree)
        {
            CurrentAircraft = aircraft;
            IsFree = false;
            TicksToFree = 0;
            aircraft.AircraftState = AircraftState.Landing;
            Console.WriteLine($"Aircraft {aircraft.Id} is landing on Runway {Id}");

        }
        else 
        {
            Console.WriteLine($"{Id} is not free");
        }
    }

    }

}