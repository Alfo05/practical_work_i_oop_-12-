using System; 

namespace OOP 
{
    public class Private : Aircraft 
    {
        public string owner = ""; // Full name of the owner in a string

        public Private(string id, AircraftState state, int distance, int speed, string type, double fuelCapacity, double fuelConsumption, double currentFuel, string owner) 
        : base(id, state, distance, speed, type, fuelCapacity, fuelConsumption, currentFuel)
        {
            this.id = id; 
            this.state = state; 
            this.distance = distance; 
            this.speed = speed; 
            this.type = type; 
            this.fuelCapacity = fuelCapacity; 
            this.fuelConsumption = fuelConsumption; 
            this.currentFuel = currentFuel; 
            this.owner = owner; 

        }

        public override void ShowAirplaneInfo() // Shows the information of the aircraft
        {
            base.ShowAirplaneInfo(); 
            Console.WriteLine($" | Owner: {owner}");
        }       


    }


}