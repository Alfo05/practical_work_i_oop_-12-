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

    }

}