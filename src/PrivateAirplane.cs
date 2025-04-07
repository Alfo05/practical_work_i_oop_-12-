using System; 

namespace OOP 
{
    public class PrivateAirplane : Aircraft 
    {
        public string owner = ""; 

        public PrivateAirplane(string id, AircraftState state, int distance, int speed, double fuelCapacity, double fuelConsumption, double currentFuel, string owner) 
        : base(id, state, distance, speed ,fuelCapacity, fuelConsumption, currentFuel)
        {
            this.id = id; 
            this.State = state; 
            this.distance = distance; 
            this.speed = speed; 
            this.fuelCapacity = fuelCapacity; 
            this.fuelConsumption = fuelConsumption; 
            this.currentFuel = currentFuel; 
            this.owner = owner; 

        }

    }


}