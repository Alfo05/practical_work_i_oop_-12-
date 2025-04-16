using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
namespace OOP
{
    public class Airport
    {
        private Runway[] runways;  // Runways array
        private List<Aircraft> aircrafts; // Aircrafts lists 



        public Airport(int numberOfRunways, int numberOfAircrafts)
        {
            runways = new Runway[numberOfRunways]; // Creation of arrays specific for the amount of runways 
            aircrafts = new List<Aircraft>(); // Creation of lists for the Airplanes 


            // Initialization of runways
            for (int i = 0; i < numberOfRunways; i++)
            {
            runways[i] = new Runway($"Runway-{i + 1}"); // We only create the runways now, since we know there are a fixed number 
            }
        }

        public void PrintMenu() // Prints the management system for the user to select an option
        {


            Console.WriteLine("_________________________________");
            Console.WriteLine("|+++++++++++ Air UFV +++++++++++|");
            Console.WriteLine("|-------------------------------|");
            Console.WriteLine("| Choose an option              |");
            Console.WriteLine("| 1. Load flight from file      |");
            Console.WriteLine("| 2. Load flight Manually       |");
            Console.WriteLine("| 3. Start Simulation(Manual)   |");
            Console.WriteLine("| 4. Start Simulation(Automatic)|");
            Console.WriteLine("| 5. Exit                       |");
            Console.WriteLine("|-------------------------------|");
            Console.WriteLine("|+++++++++++++++++++++++++++++++|");
            Console.WriteLine("|-------------------------------|");

            SelectOption(); // Calls the SelectOption method

        }

        public void SelectOption()
        {
            // Tells the user to print an option
            Console.WriteLine("Please select an option: ");
            string input = Console.ReadLine(); 


            // We start the exceptions
            try
            {
                // We create a variable to store the selection
                int selection = int.Parse(input); 
                
                if (selection == 1)
                {
                    // Code for loading flights from the file 
                    Console.WriteLine("Load flights from file");

                    LoadAircraftFromFile(); // Calls the method to load aircrafts from file 
                }
                else if (selection == 2)
                {
                    // Code for loading flights manually
                    Console.WriteLine("Load flights manually"); 
                    
                   PrintTypesAircraft(); // Shows the user the options to add flights

                }
                else if (selection == 3)
                {
                    // Code for starting the simulation manually
                    Console.WriteLine("Starts the simulation manually"); 

                    StartManualSimulation(); 
                }
                else if (selection == 4)
                {
                    // Code for starting the simulation automatically
                    Console.WriteLine("Stats the simulation automatically");
                }

                else if (selection == 5)
                {
                    // Code for exiting the code 
                    Console.WriteLine("Code finished successfully"); 

                }
                else 
                {
                    // Tells the user that that option does not exist
                    Console.WriteLine("This option is not valid "); 

                    // Prints the menu again 
                    PrintMenu(); 

                }
            }
            catch (FormatException) // If the selection format is invalid
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                PrintMenu(); 
            }
            catch (ArgumentNullException) // If the selection is null
            {
                Console.WriteLine("Input can't be null. "); 
                PrintMenu(); 
            }    
            
        }

        public void LoadAircraftManually(int option)
        {
            

            try 
            {
                
                Console.Write("Airplane ID: ");
                string id = Console.ReadLine();

                Console.Write("Select a State (InFlight, Waiting, Landing, OnGround): ");
                Aircraft.AircraftState state = Enum.Parse<Aircraft.AircraftState>(Console.ReadLine());

                Console.Write("Distance to the airport (km): ");
                int distance = int.Parse(Console.ReadLine());

                Console.Write("Speed of the airplane (km/h): ");
                int speed = int.Parse(Console.ReadLine());

                Console.Write("Fuel Capacity (Liters): ");
                double fuelCapacity = double.Parse(Console.ReadLine());

                Console.Write("Fuel consumption (Liters/km): ");
                double fuelConsumption = double.Parse(Console.ReadLine());

                Console.Write("Current Consumption (L): ");
                double currentFuel = double.Parse(Console.ReadLine());

                if (option == 1) // Cargo Airplane
                {
                    string type = "Cargo";

                    Console.WriteLine("Please enter the MaxLoad of the Cargo Airplane: "); 
                    double maxLoad = double.Parse(Console.ReadLine()); 

                    
                    aircrafts.Add(new CargoAirplane(id, state, distance, speed, fuelCapacity, fuelConsumption, currentFuel, maxLoad));
                    PrintTypesAircraft(); 

                }
                else if (option == 2) // Commercial Airplane
                {
                    string type = "Commercial"; 
                    
                    Console.WriteLine("Please enter the passenger quantity of the Commercial Airplane"); 
                    int passengers = int.Parse(Console.ReadLine()); 

                    aircrafts.Add(new CommercialAirplane(id, state, distance, speed, fuelCapacity, fuelConsumption, currentFuel, passengers));
                    PrintTypesAircraft(); 
                }
                else if (option == 3) // Private Airplane 
                {

                    string type = "Private"; 

                    Console.WriteLine("Please enter the name of the owner of the plane: "); 
                    string owner = Console.ReadLine(); 

                    aircrafts.Add(new PrivateAirplane(id, state, distance, speed, fuelCapacity, fuelConsumption, currentFuel, owner));
                    PrintTypesAircraft(); 

                }
                else 
                {

                    Console.WriteLine("This option is not valid"); 
                    PrintTypesAircraft(); // Returns the user to the menu 
                }


            }
            catch (Exception ex0)
            {
                Console.WriteLine($"There was an error introducing the data, you will be returned to the menu"); 
                PrintTypesAircraft(); 
            }


        }

        public void PrintTypesAircraft()
        {
            Console.WriteLine("Please Select an aircraft you will like to introduce: ");
            Console.WriteLine("_________________________________");
            
            Console.WriteLine("|-------------------------------|");
            Console.WriteLine("| Choose an option              |");
            Console.WriteLine("| 1. Cargo Airplane    |");
            Console.WriteLine("| 2. Commercial Airplane      |");
            Console.WriteLine("| 3. Private Airplane   |");
            Console.WriteLine("| 4. Exit to Menu   |");
            Console.WriteLine("|-------------------------------|");
            
            Console.WriteLine("|-------------------------------|");

            Console.WriteLine("Introduce your option: ");
            int option = int.Parse(Console.ReadLine()); 

            

            LoadAircraftManually(option); 
        }


        public void LoadAircraftFromFile()
        {

            try 
            {
                string file_path = "flights_info.csv"; // Path for the file where airplanes will be stored 

                // Opens the file with streamreader 
                using (StreamReader sr = new StreamReader(file_path))
                {

                    string line;

                    string separator = ",";

                    // Reads the file per line until it is blank
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Separates the file contents into fields to it can be organized easily
                        string[] fields = line.Split(separator);


                        // We assign airplane data 
                        string id = fields[0]; // Airplane ID 
                        Aircraft.AircraftState state = Enum.Parse<Aircraft.AircraftState>(fields[1]); // State of the airplane
                        int distance = int.Parse(fields[2]); // Distance
                        int speed = int.Parse(fields[3]); // Speed
                        string type = fields[4]; // Type of airplane 
                        double fuelCapacity = double.Parse(fields[5]); // Total fuel capacity
                        double fuelConsumption = double.Parse(fields[6]); // Fuel Comsumption per Km 
                        double currentFuel = double.Parse(fields[7]); // Current fuel remaining 

                        // We instantiate a specific object depening on the type of aircraft 
                        if (type == "Commercial")
                        {
                            int passengers = int.Parse(fields[8]); // Passenger Capacity
                            // Instantation of new Commercial Airplane 
                            aircrafts.Add(new CommercialAirplane(id, state, distance, speed, fuelCapacity, fuelConsumption, currentFuel, passengers)); 
                            PrintMenu(); 
                        }
                        else if (type == "Cargo") // If the airplane is 
                        {
                            double maxLoad = double.Parse(fields[8]); // Max cargo load
                            // Instantation of new Cargo Airplane 
                            aircrafts.Add(new CargoAirplane(id, state, distance, speed, fuelCapacity, fuelConsumption, currentFuel, maxLoad));
                            PrintMenu(); 
                        }
                        else if (type == "Private") // If the airplane is private
                        {
                            string owner = fields[8]; // Owner of the private plane (a new variable with full name could be added)

                            // Instantation of new Private Airplane 
                            aircrafts.Add(new PrivateAirplane(id, state, distance, speed, fuelCapacity, fuelConsumption, currentFuel, owner));
                            PrintMenu(); 
                        }
                        else // If the type of airplane is not found
                        {
                            // Message showing to the user that the airplane type was not found
                            Console.WriteLine("Type of airplane could not be identified, you will be returned to the main menu"); 
                            PrintMenu(); // Returns the user to the main menu

                        }

                    }
                }

            }
            catch (FileNotFoundException)
            {
                // Returns a message stating that the file with the specified path was not found
                Console.WriteLine("File was not found, please try again, or check system code, you will be returned to the main menu");
                PrintMenu(); // Returns to the main menu 

            }
            catch (FormatException)
            {
                // Returns a message stating that there is an error in the Format of the variables
                Console.WriteLine("A format error has been found, please try again, or check the system code, you will be returned to the main menu ");
                PrintMenu(); // Returns to the main menu

            }
            catch (Exception e0)
            {
                // Shows the error message to the user, of the error that has been found
                Console.WriteLine($"An error was found: {e0.Message}, you will be returned to the main menu");
                PrintMenu(); // Returns to the menu
            }
        }



        public void StartManualSimulation()
    {
        bool control = true; // Control variable to control de loop

        while (control) // The loop is working as the control variable is still true 
        {
            AdvanceTick(); // The simulation advaces a tick (15 minutes)

            // Message for the user to keep on the loop or go back to the menu
            Console.WriteLine("Press ENTER to continue or type 'menu' to return to main menu:");
        
            string input = Console.ReadLine(); 

            if (input.ToLower() == "menu") // If the user writes menu
            {
                control = false; // We change the variable to exit the loop
                PrintMenu(); // And we go back to the main menu
            }
            // Otherwise the loop will keep on being executed
        }
}


        public void ShowStatus()
        {
            // Shows the status of the Runways 
            Console.WriteLine("\n========== RUNWAY STATUS ==========");
            foreach (var runway in runways)
            {
                Console.WriteLine(runway.GetStatus());
            }

            // Shows the status of the Airplanes
            Console.WriteLine("\n========== AIRPLANES STATUS ==========");
            foreach (var aircraft in aircrafts)
            {
                Console.WriteLine($"ID: {aircraft.id} | Estado: {aircraft.State} | Distancia: {aircraft.distance} km | Combustible: {aircraft.currentFuel} L");
            }

            Console.WriteLine("============================================\n");
        }




        
        public void AdvanceTick()
        {
            double tickHours = 0.25; // Every tick represents 15 minutes 

            Console.WriteLine("\n========== ADVANCED SIMULATION ==========");

            foreach (var aircraft in aircrafts) // For every airplane loaded
            {
                if (aircraft.State == Aircraft.AircraftState.InFlight) // If there are airplanes in the air 
                {
                    double distanceTravelled = aircraft.speed * tickHours; // Calculates the distance travelled 
                    double fuelUsed = distanceTravelled * aircraft.fuelConsumption; // Calculates the fuel used 

                    aircraft.currentFuel = Math.Max(0, aircraft.currentFuel - fuelUsed); // Substracts the current fuel
                    aircraft.distance = Math.Max(0, aircraft.distance - (int)distanceTravelled); // Substracts the distance 

                    Console.WriteLine($" Flight: {aircraft.id} - In-Flight | Distance: {aircraft.distance} km | Fuel Remaining: {aircraft.currentFuel:F2} Liters");

                    if (aircraft.distance == 0) // If the plane has reached the airport 
                    {
                        aircraft.State = Aircraft.AircraftState.Waiting; // Changes the state of the airplane to waiting 
                        Console.WriteLine($"Flight {aircraft.id} reached the airport and is requesting a runway"); 
                    
                    }
                }   

            }

            foreach (var aircraft in aircrafts) // Again loads all of the airplanes 
            {
                if (aircraft.State == Aircraft.AircraftState.Waiting)
                {
                    bool assinged = false; // Indication of the airplane being assigned a runway

                    foreach (var runway in runways)
                    {
                        // If has not being assigned and runway is free 
                        if (!assinged && runway.runwayStatus == Runway.RunwayStatus.Free)
                        {
                            runway.LandingAircraft(aircraft); // We assign a runway to the airplane
                            assinged = true; // We should mark it as assigned to continue
                        }
                    }
                    
                    // If no runways are available 
                    if (!assinged)
                    {
                        Console.WriteLine($"Flight {aircraft.id} is still waiting due to no runways being available" ); 
                    }
                }
            }

            foreach (var runway in runways)
            {
                runway.AdvanceTick();  // Calls the advance tick method in the RunwayClass
            }

            ShowStatus(); 

            Console.WriteLine("Press anything to make another tick or type 'menu' to go back to the menu"); 

            string input = Console.ReadLine(); 
            if (input.ToLower() == "menu")
            {
                PrintMenu(); 
            }
            
        }




    }
}