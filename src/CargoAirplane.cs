using System; 

namespace OOP 
{

    public class CargoAirplane : Aircraft 
    {
        public double maxLoad = 0; // In TONS (1000KG)
        public CargoAirplane(string id, AircraftState state, int distance, int speed, string type, double fuelCapacity, double fuelConsumption, double currentFuel, double maxLoad) 
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
            this.maxLoad = maxLoad; 

        }

        public override void ShowAirplaneStatus() // Shows the information about the aircraft
        {
            Console.WriteLine($"ID: {id} | State: {state} | Distance: {distance} km | Type: {type} | Fuel Remaining: {currentFuel} L | Max Load (tons): {maxLoad}");
        }  

    }
}