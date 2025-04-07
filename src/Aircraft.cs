using System;
using System.Data.Common;
using System.Diagnostics.Contracts;
namespace OOP
{
    
    public class Aircraft
    {
        public string id { get; set; }
        public AircraftState State { get; set; }
        public int distance { get; set; }
        public int speed { get; set; }
        public double fuelCapacity { get; set; }
        public double fuelConsumption { get; set; }
        public double currentFuel { get; set; }
        public enum AircraftState
        {
            InFlight,
            Waiting,
            Landing,
            OnGround
        }

        // Constructor
        public Aircraft(string id, AircraftState state, int distance, int speed, double fuelCapacity, double fuelConsumption, double currentFuel)
        {
            this.id = id;
            this.State = state;
            this.distance = distance;
            this.speed = speed;
            this.fuelCapacity = fuelCapacity;
            this.fuelConsumption = fuelConsumption;
            this.currentFuel = currentFuel;
        }


    }
       
}
