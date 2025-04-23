using System;
using System.Data.Common;
using System.Diagnostics.Contracts;
namespace OOP
{
    
    public abstract class  Aircraft
    {
        public string id { get; set; } // Flight number 
        public AircraftState State { get; set; } // State of the Aircraft
        public int distance { get; set; } // In KM 
        public int speed { get; set; } // In KM/H 
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
        public Aircraft(string id, AircraftState state, int distance, int speed, double fuelCapacity, double fuelConsumption, double currentFuel)
        {
            this.id = id;
            this.State = state; // We don't assign any state yet as we don't have any airplanes loaded 
            this.distance = distance;
            this.speed = speed;
            this.fuelCapacity = fuelCapacity;
            this.fuelConsumption = fuelConsumption;
            this.currentFuel = currentFuel;
        }

    
    }
       
}
