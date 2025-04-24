using System; 

namespace OOP 
{
    public class PrivateAirplane : Aircraft 
    {
        public string owner = ""; // Full name of the owner in a string

        public PrivateAirplane(string id, AircraftState state, int distance, int speed, string type, double fuelCapacity, double fuelConsumption, double currentFuel, string owner) 
        : base(id, state, distance, speed, type, fuelCapacity, fuelConsumption, currentFuel)
        {
            this.id = id; 
            this.State = state; 
            this.distance = distance; 
            this.speed = speed; 
            this.type = type; 
            this.fuelCapacity = fuelCapacity; 
            this.fuelConsumption = fuelConsumption; 
            this.currentFuel = currentFuel; 
            this.owner = owner; 

        }

        public override void ShowAirplaneStatus() // Shows the information of the aircraft
        {
            Console.WriteLine($"ID: {id} | State: {State} | Distance: {distance} km | Type: {type} | Fuel Remaining: {currentFuel} L | Owner: {owner}");
        }       


    }


}