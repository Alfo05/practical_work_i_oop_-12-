using System; 

namespace OOP 
{

    public class Runway 
    {

        public string Id { get; set; }
        public bool IsFree { get; set; }
        public Aircraft CurrentAircraft { get; set; }
        public int TicksToFree { get; set; }

    public Runway(string id)
    {
        Id = id;
        IsFree = true;  // By default the runway is clear
        CurrentAircraft = null;
        TicksToFree = 0;
    }
    public void LandingAircraft(Aircraft aircraft)
    {
        if (IsFree)
        {
            CurrentAircraft = aircraft;
            IsFree = false;
            TicksToFree = 0;
            Console.WriteLine($"Aircraft {aircraft.Id} is landing on Runway {Id}");

        }
        else 
        {
            Console.WriteLine($"{Id} is not free");
        }
    }

    }

}