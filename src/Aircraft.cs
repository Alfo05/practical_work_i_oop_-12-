using System;
using System.Data.Common;
using System.Diagnostics.Contracts;
namespace OOP
{
    
    public class Aircraft
    {
        public string Id { get; set; }
        public AircraftState State { get; set; }
        public int Distance { get; set; }
        public int Speed { get; set; }
        public double FuelCapacity { get; set; }
        public double FuelConsumption { get; set; }
        public double CurrentFuel { get; set; }

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
            Id = id;
            State = state;
            Distance = distance;
            Speed = speed;
            FuelCapacity = fuelCapacity;
            FuelConsumption = fuelConsumption;
            CurrentFuel = currentFuel;
        }


    }
       
}
