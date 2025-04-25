using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
namespace OOP
{
    public class Airport
    {
        private Runway[] runways;  // Runways array
        private List<Aircraft> aircrafts; // Aircrafts list 



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

                    StartManualSimulation();   // Start the manual simulation 
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
            catch (FormatException ex1) // If the selection format is invalid
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                PrintMenu(); 
            }
            catch (ArgumentNullException ex2) // If the selection is null
            {
                Console.WriteLine("Input can't be null. "); 
                PrintMenu(); 
            }    
            
        }

        public void LoadAircraftManually()
        {
            try 
            {

                Console.WriteLine("Please Select an Option"); 

                string input = Console.ReadLine(); 

                int option = int.Parse(input); 

                if (option == 1 || option == 2 || option == 3)
                {


                
                
                
                    Console.Write("Airplane ID: ");
                    string id = Console.ReadLine();

                    CheckID(id); 

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

                    Console.Write("Current Fuel (L): ");
                    double currentFuel = double.Parse(Console.ReadLine());

                    


                    if (option == 1) // Cargo Airplane
                    {
                        string type = "Cargo";

                        Console.WriteLine("Please enter the MaxLoad of the Cargo Airplane: "); 
                        double maxLoad = double.Parse(Console.ReadLine()); 

                    
                        aircrafts.Add(new CargoAirplane(id, state, distance, speed, type, fuelCapacity, fuelConsumption, currentFuel, maxLoad));
                        
                        

                    }
                    else if (option == 2) // Commercial Airplane
                    {
                        string type = "Commercial"; 
                    
                        Console.WriteLine("Please enter the passenger quantity of the Commercial Airplane"); 
                        int passengers = int.Parse(Console.ReadLine()); 

                        aircrafts.Add(new CommercialAirplane(id, state, distance, speed, type, fuelCapacity, fuelConsumption, currentFuel, passengers));
                         
                        
                    }   
                    else if (option == 3) // Private Airplane 
                    {

                        string type = "Private"; 

                        Console.WriteLine("Please enter the name of the owner of the plane: "); 
                        string owner = Console.ReadLine(); 

                        aircrafts.Add(new PrivateAirplane(id, state, distance, speed, type, fuelCapacity, fuelConsumption, currentFuel, owner)); 
                         

                    }
                

                }

            
                else if (option == 4) // The user decides to exit the menu
                {   
                    Console.WriteLine("Exiting to the main menu....."); 
                    PrintMenu();  
                }
            
                else // The input is anything but the options labelled above
                {
                    Console.WriteLine("The entered input is not valid"); 
                    PrintTypesAircraft(); 

                }




            }
            catch (ArgumentNullException ex3)
            {
                Console.WriteLine("A variable can't be left blank"); 
                PrintTypesAircraft(); 
            }
            catch (FormatException ex4)
            {
                Console.WriteLine("The input is not a number");
                PrintTypesAircraft();  
            }
            catch (Exception ex5)
            {
                Console.WriteLine($"An error occurred: {ex5.Message}"); 
                PrintTypesAircraft(); 
            }

            DefineStateProperties(); 
            ShowStatus(); 
            PrintMenu(); 
        }

        public void PrintTypesAircraft()
        {
            Console.WriteLine("Please Select an aircraft you will like to introduce: ");
            Console.WriteLine("______________________________________");
            
            Console.WriteLine("|-------------------------------------|");
            Console.WriteLine("| Choose an option                    |");
            Console.WriteLine("| 1. Cargo Airplane                   |");
            Console.WriteLine("| 2. Commercial Airplane              |");
            Console.WriteLine("| 3. Private Airplane                 |");
            Console.WriteLine("| 4. Exit to Main Menu                |");
            Console.WriteLine("|-------------------------------------|");

            LoadAircraftManually(); 
        }


        public void LoadAircraftFromFile()
        {

            try 
            {
                string path = "../../../../files/flights_info.csv"; // Path for the file where airplanes file will be stored 

                // Opens the file with streamreader 
                using (StreamReader sr = new StreamReader(path))
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
                        CheckID(id); // Checks if plane already exists

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
                            int numPassengers = int.Parse(fields[8]); // Passenger Capacity
                            // Instantation of new Commercial Airplane 
                            aircrafts.Add(new CommercialAirplane(id, state, distance, speed, type, fuelCapacity, fuelConsumption, currentFuel, numPassengers)); 
                            
                            
                        }
                        else if (type == "Cargo") // If the airplane is 
                        {
                            double maxLoad = double.Parse(fields[8]); // Max cargo load
                            // Instantation of new Cargo Airplane 
                            aircrafts.Add(new CargoAirplane(id, state, distance, speed, type, fuelCapacity, fuelConsumption, currentFuel, maxLoad));
                            
                            
                        }
                        else if (type == "Private") // If the airplane is private
                        {
                            string owner = fields[8]; // Owner of the private plane (a new variable with full name could be added)

                            // Instantation of new Private Airplane 
                            aircrafts.Add(new PrivateAirplane(id, state, distance, speed, type, fuelCapacity, fuelConsumption, currentFuel, owner));
                            
                             
                         
                        }
                        else // If the type of airplane is not found
                        {
                            // Message showing to the user that the airplane type was not found
                            Console.WriteLine("Type of airplane could not be identified"); 
                            PrintMenu(); 
                            

                        }

                    }
                }

            }
            catch (FileNotFoundException ex6)
            {
                // Returns a message stating that the file with the specified path was not found
                Console.WriteLine("File was not found, please try again, or check system code, you will be returned to the main menu");
                PrintTypesAircraft(); 

            }
            catch (FormatException ex7)
            {
                // Returns a message stating that there is an error in the Format of the variables
                Console.WriteLine("A format error has been found, please try again, or check the system code, you will be returned to the main menu ");
                PrintTypesAircraft(); 

            }
            catch (Exception ex8)
            {
                // Shows the error message to the user, of the error that has been found
                Console.WriteLine($"An error was found: {ex8.Message}, you will be returned to the main menu");
                PrintTypesAircraft(); 
            }


            DefineStateProperties(); 

            
            ShowStatus(); 
            PrintMenu(); 
        }

        
        public void DefineStateProperties() // For specific states will change some variables when loading airplanes
        {

            foreach (var aircraft in aircrafts) // Looks at all aircrafts
            {
                if (aircraft.state == Aircraft.AircraftState.Landing) // If the aircraft is landing 
                {
                    bool alreadyExists = false; // We suppose that the airplane does not exist in a runway
                    int i = 0; // Counter for the loop

                    while (i < runways.Length && !alreadyExists) // We loop around the runways
                    {
                        // If the airplane is found in a certain runway
                        if (runways[i].CurrentAircraft != null && runways[i].CurrentAircraft.id == aircraft.id)
                        {
                            alreadyExists = true; // Aircraft is already in a exists in a runway
                        }
                        i++; // Checks in the other Runway(s)

                        // If plane is not found then the bool keeps being false
                    }



                    if (!alreadyExists) // If the assignation is false
                    {
                        bool assignedRunway = false; // We create another bool

                        aircraft.distance = 0; // Landing state means he is already at the airport

                        foreach (var runway in runways) // Looks at all the airplanes
                        {
                            // If not runway has been assigned and a runway is free 
                            if (!assignedRunway && runway.runwayStatus == Runway.RunwayStatus.Free)
                            {
                                runway.RequestRunway(aircraft); // We attemp to assign a runway to the airplane
                                assignedRunway = true; // We should mark it as assigned to continue
                            }
                        
                        }

                        /* An airplane may have been assigned a runway, but if it is there is another plane in the same runway its meant to land, 
                        he can abort the landing, and go back to waiting waiting for another clear runway */ 
                    
                        // If no runways are available 
                        if (!assignedRunway)
                        {
                            Console.WriteLine($"Flight {aircraft.id} is still waiting due to no runways being available" ); 
                            aircraft.state = Aircraft.AircraftState.Waiting; // Changes the state of the airplane to waiting  
                        }
                    }

                }
                if (aircraft.state == Aircraft.AircraftState.OnGround) // If the aircraft is on ground 
                {
                    aircraft.distance = 0; // OnGround means the airport is on the Airport's premises
                    aircraft.speed = 0;  // OnGround means he is park somewhere in the Airport
                }
                if (aircraft.state == Aircraft.AircraftState.Waiting) // If the aircraft is waiting for a runway
                {
                    aircraft.distance = 0; // Waiting means the airplane is by the airport
                }
            }

        }


        public void CheckID(string id) // Checks if id just inputted already exists
        {
            foreach (var aircraft in aircrafts) // Looks for all airplanes 
            {
                if (aircraft.id == id) // If the same id is found 
                {
                    Console.WriteLine($"Airplane with ID: {id} already exists"); 
                    PrintTypesAircraft(); 

                }
            }

        }


        public void StartManualSimulation() // Control method for ticks
        {
            Console.Clear(); 
            AdvanceTick(); 
        }       


        public void ShowStatus()
        {

            Console.Clear(); 
            // Shows the status of the Runways 
            Console.WriteLine("\n================= RUNWAY STATUS =================");
            foreach (var runway in runways)
            {
                Console.WriteLine(runway.GetStatus()); // Shows the status of every runway
            }

            // Shows the status of the Airplanes
            Console.WriteLine("\n=============== AIRPLANES STATUS ================");
            foreach (var aircraft in aircrafts)
            {
               aircraft.ShowAirplaneStatus(); // Shows the information of every airplane
            }

            Console.WriteLine("=================================================\n");
        }




        
        public void AdvanceTick()
        {
            double tickHours = 0.25; // Every tick represents 15 minutes 

            

            foreach (var aircraft in aircrafts) // For every airplane loaded
            {
                if (aircraft.state == Aircraft.AircraftState.InFlight) // If there are airplanes in the air 
                {
                    double distanceTravelled = aircraft.speed * tickHours; // Calculates the distance travelled 
                    double fuelUsed = distanceTravelled * aircraft.fuelConsumption; // Calculates the fuel used 

                    aircraft.currentFuel = Math.Max(0, aircraft.currentFuel - fuelUsed); // Substracts the current fuel
                    aircraft.distance = Math.Max(0, aircraft.distance - (int)distanceTravelled); // Substracts the distance 

                    Console.WriteLine($" Flight: {aircraft.id} - In-Flight | Distance: {aircraft.distance} km | Fuel Remaining: {aircraft.currentFuel:F2} Liters");

                    if (aircraft.distance == 0) // If the plane has reached the airport 
                    {
                        aircraft.state = Aircraft.AircraftState.Waiting; // Changes the state of the airplane to waiting 
                        Console.WriteLine($"Flight {aircraft.id} reached the airport and is waiting to be assigned a runway"); 
                    
                    }
                }   

            

            
            
                else if (aircraft.state == Aircraft.AircraftState.Waiting)
                {
                    bool assinged = false; // Indication of the airplane being assigned a runway

                    foreach (var runway in runways) // We look in every runway
                    {
                        // If has not being assigned and runway is free 
                        if (!assinged && runway.runwayStatus == Runway.RunwayStatus.Free)
                        {
                            runway.RequestRunway(aircraft); // We attemp to assign a runway to the airplane
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

            foreach (var runway in runways) // We look in every runway
            {
                runway.UpdateTick();  // Calls the advance tick method in the RunwayClass
            }

            ShowStatus(); // Shows the status of the runways and the airplanes 
            
            // Asks the user if we want to make another tick or wants to go back to the menu
            Console.WriteLine("Press anything to make another tick or type 'menu' to go back to the menu"); 

            string input = Console.ReadLine();

            // If the user wants to go back to the menu 
            if (input.ToLower() == "menu") 
            {
                PrintMenu(); 
            }
            else // Otherwise
            {
                StartManualSimulation(); // We call startmanualsimulation
            }
            
            
        }




    }
}