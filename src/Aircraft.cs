using System;
using System.Data.Common;
using System.Diagnostics.Contracts;
namespace OOP
{
    
    public abstract class  Aircraft
    {
        public string id { get; set; } // Flight number 
        public AircraftState state { get; set; } // State of the Aircraft
        public int distance { get; set; } // In KM 
        public int speed { get; set; } // In KM/H 

        public string type { get; set; } // Type of aircraft
        public double fuelCapacity { get; set; } // In Litres 
        public double fuelConsumption { get; set; } // In Liters/KM 
        public double currentFuel { get; set; } // In Litres
        public enum AircraftState // Defines the possible states of the Aircraft
        {
            InFlight, // Interpreted as the Aircraft arriving at the Airport
            Waiting, // Interpreted as the Aircraft waiting for clearence to land 
            Landing, // Interpreted as the Aircraft landing and occuping a Runway
            OnGround // Interpreted as the Aircraft already landed and has exited the Runway
        }

        // Constructor
        public Aircraft(string id, AircraftState state, int distance, int speed, string type, double fuelCapacity, double fuelConsumption, double currentFuel)
        {
            this.id = id;
            this.state = state; // We don't assign any state yet as we don't have any airplanes loaded 
            this.distance = distance;
            this.speed = speed;
            this.type = type; 
            this.fuelCapacity = fuelCapacity;
            this.fuelConsumption = fuelConsumption;
            this.currentFuel = currentFuel;
        }

        public virtual void ShowAirplaneStatus() // Show information about the aircraft
        {
            Console.WriteLine($"ID: {id} | State: {state} | Distance: {distance} km | Type: {type} | Fuel Remaining: {currentFuel} L");
        }


    
    }
       
}
