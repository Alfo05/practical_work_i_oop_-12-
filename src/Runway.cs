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
            this.id = id; 
            runwayStatus = RunwayStatus.Free;  // By default the runway is free
            CurrentAircraft = null; // We start with runways with no planes
            TicksToFree = 3; // By default it takes 3 ticks to clear a runway 
        }
        public void LandingAircraft(Aircraft aircraft)
        {
            if (runwayStatus == RunwayStatus.Free) // Check if the runway is free 
            {
            
                runwayStatus = RunwayStatus.Ocupied; // The runway is in use by the plane which is landing 
                CurrentAircraft.State = Aircraft.AircraftState.Landing; // We assing the plane as landing 
                Console.WriteLine($"Aircraft {aircraft.id} is landing on Runway {id}"); // We show the info 

            }
            else 
            {
                Console.WriteLine($"Runway number {id} is not free"); // We tell that the runway is in use by another plane
            }
        }

        public void ReleaseRunway()
        {
            CurrentAircraft.State = Aircraft.AircraftState.OnGround; // We assign the plane as OnGroud 
            runwayStatus = RunwayStatus.Free; // We assign that the runway can now be used 
            Console.WriteLine($"Runway {id} is now clear"); // We tell that the runway is now clear


        }

        public string GetStatus()
        {
            if (runwayStatus == RunwayStatus.Free) // If the runway status is free
            {
                return $"{id}: IS FREE";
            }

            else // If the runway status is anything but free
            {
                return $"{id}: Runway is ocupied by Aircraft {CurrentAircraft.id}, {TicksToFree} remaining";
            }
}   


    }

}