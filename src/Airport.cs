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

            }
            catch (FileNotFoundException)
            {
                // Returns a message stating that the file with the specified path was not found
                Console.WriteLine("File was not found please try again, or check system code, you will be returned to the main menu");
                PrintMenu(); // Returns to the menu

            }
            catch (Exception e0)
            {
                // Shows the error message to the user, of the error that has been found
                Console.WriteLine($"An error was found: {e0.Message}, you will be returned to the main menu");
                PrintMenu(); // Returns to the menu
            }
        }
    }
}