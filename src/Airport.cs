using System;
using System.ComponentModel.Design;
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
                    
                   

                }
                else if (selection == 3)
                {
                    // Code for starting the simulation manually
                    Console.WriteLine("Starts the simulation manually"); 
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
                        string type = fields[5]; // Type of airplane 
                        double fuelCapacity = double.Parse(fields[5]); // Total fuel capacity
                        double fuelConsumption = double.Parse(fields[6]); // Fuel Comsumption per Km 
                        double currentFuel = double.Parse(fields[7]); // Current fuel remaining 

                        // We instantiate a specific object depening on the type of aircraft 
                        if (type == "Commercial")
                        {
                            int passengers = int.Parse(fields[8]); // Passenger Capacity
                            // Instantation of new Commercial Airplane 
                            aircrafts.Add(new CommercialAirplane(id, state, distance, speed, fuelCapacity, fuelConsumption, currentFuel, passengers)); 
                        }
                        else if (type == "Cargo") // If the airplane is 
                        {
                            double maxLoad = double.Parse(fields[8]); // Max cargo load
                            // Instantation of new Cargo Airplane 
                            aircrafts.Add(new CargoAirplane(id, state, distance, speed, fuelCapacity, fuelConsumption, currentFuel, maxLoad));
                        }
                        else if (type == "Private") // If the airplane is private
                        {
                            string owner = fields[8]; // Owner of the private plane (a new variable with full name could be added)

                            // Instantation of new Private Airplane 
                            aircrafts.Add(new PrivateAirplane(id, state, distance, speed, fuelCapacity, fuelConsumption, currentFuel, owner));
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

        public void ShowStatus()
    {
        // Mostrar estado de las pistas
        Console.WriteLine("\n========== RUNWAY STATUS ==========");
        foreach (var runway in runways)
        {
            Console.WriteLine(runway.GetStatus());
        }

        // Mostrar estado de los aviones
        Console.WriteLine("\n========== AIRPLANES STATUS ==========");
        foreach (var aircraft in aircrafts)
        {
            Console.WriteLine($"ID: {aircraft.id} | Estado: {aircraft.State} | Distancia: {aircraft.distance} km | Combustible: {aircraft.currentFuel} L");
        }

        Console.WriteLine("============================================\n");
}



    }
}