using System;
using System.Data.Common;
using System.Diagnostics.Contracts;
namespace OOP
{
    
    public class Aircraft
    {
        // Define attributes of Aircraft class 
        private string id = ""; 

        private int distance = 0; 

        private int speed = 0; 

        private double fuel_capacity = 0; 

        private double fuel_consumption = 0; 

        public enum AircraftState
        {
        InFlight,
        Waiting,
        Landing,
        OnGround
        }         
        public AircraftState State { get; set; }
        public Aircraft(string id, int distance, int speed, double fuel_capacity, double fuel_consumption, AircraftState state)
        {
            this.id = id; 
            this.distance = distance; 
            this.speed = speed; 
            this.fuel_capacity = fuel_capacity; 
            this.fuel_consumption = fuel_consumption; 
            State = state; 
            

        }
       
    }
}