using System; 

namespace OOP 
{

    public class CargoAirplane : Aircraft 
    {
        public double max_load = 0; 
        public CargoAirplane(string id, AircraftState state, int distance, int speed, double fuelCapacity, double fuelConsumption, double currentFuel, double max_load) 
        : base(id, state, distance, speed ,fuelCapacity, fuelConsumption, currentFuel)
        {
            this.id = id; 
            this.State = state; 
            this.distance = distance; 
            this.speed = speed; 
            this.fuelCapacity = fuelCapacity; 
            this.fuelConsumption = fuelConsumption; 
            this.currentFuel = currentFuel; 
            this.max_load = max_load; 

        }

    }
}