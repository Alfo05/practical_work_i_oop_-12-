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

        public override void ShowAirplaneInfo() // Shows the information about the aircraft
        {
            base.ShowAirplaneInfo();
            Console.WriteLine($" | Max Load (tons): {maxLoad}");
        }  

    }
}