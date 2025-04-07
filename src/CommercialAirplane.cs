using System; 

namespace OOP 
{
    public class CommercialAirplane : Aircraft 
    {
        public int num_passangers = 0; 

        public CommercialAirplane(string id, AircraftState state, int distance, int speed, double fuelCapacity, double fuelConsumption, double currentFuel, int num_passangers) 
        : base(id, state, distance, speed ,fuelCapacity, fuelConsumption, currentFuel)
        {
            this.id = id; 
            this.State = state; 
            this.distance = distance; 
            this.speed = speed; 
            this.fuelCapacity = fuelCapacity; 
            this.fuelConsumption = fuelConsumption; 
            this.currentFuel = currentFuel; 
            this.num_passangers = num_passangers; 

        }

    }


}