using System;                                                       // Required for Console input and output
using System.Collections.Generic;                                   // Required for using the Dictionary data structure

namespace PeriodicTableApp                                          // Uses the same group name
{
    class Program                                                   // Main execution class
    {
        static void Main(string[] args)                             // Entry point of the C# application
        {
            Dictionary<int, Element> elements = new Dictionary<int, Element>(); // Dictionary to store elements by atomic number

            elements.Add(1, new Element(1, "Hydrogen", "Nonmetal"));            // Adds Hydrogen to dictionary
            elements.Add(2, new Element(2, "Helium", "Noble Gas"));             // Adds Helium
            elements.Add(3, new Element(3, "Lithium", "Alkali Metal"));         // Adds Lithium
            elements.Add(4, new Element(4, "Beryllium", "Alkaline Earth Metal"));// Adds Beryllium
            elements.Add(5, new Element(5, "Boron", "Metalloid"));              // Adds Boron
            elements.Add(6, new Element(6, "Carbon", "Nonmetal"));              // Adds Carbon
            elements.Add(7, new Element(7, "Nitrogen", "Nonmetal"));            // Adds Nitrogen
            elements.Add(8, new Element(8, "Oxygen", "Nonmetal"));              // Adds Oxygen
            elements.Add(9, new Element(9, "Fluorine", "Halogen"));             // Adds Fluorine
            elements.Add(10, new Element(10, "Neon", "Noble Gas"));             // Adds Neon
            elements.Add(11, new Element(11, "Sodium", "Alkali Metal"));        // Adds Sodium
            elements.Add(12, new Element(12, "Magnesium", "Alkaline Earth Metal"));// Adds Magnesium
            elements.Add(13, new Element(13, "Aluminum", "Post-transition Metal"));// Adds Aluminum
            elements.Add(14, new Element(14, "Silicon", "Metalloid"));          // Adds Silicon
            elements.Add(15, new Element(15, "Phosphorus", "Nonmetal"));        // Adds Phosphorus
            elements.Add(16, new Element(16, "Sulfur", "Nonmetal"));            // Adds Sulfur
            elements.Add(17, new Element(17, "Chlorine", "Halogen"));           // Adds Chlorine
            elements.Add(18, new Element(18, "Argon", "Noble Gas"));            // Adds Argon
            elements.Add(19, new Element(19, "Potassium", "Alkali Metal"));     // Adds Potassium
            elements.Add(20, new Element(20, "Calcium", "Alkaline Earth Metal"));// Adds Calcium
            elements.Add(21, new Element(21, "Scandium", "Transition Metal"));  // Adds Scandium
            elements.Add(22, new Element(22, "Titanium", "Transition Metal"));  // Adds Titanium
            elements.Add(23, new Element(23, "Vanadium", "Transition Metal"));  // Adds Vanadium
            elements.Add(24, new Element(24, "Chromium", "Transition Metal"));  // Adds Chromium
            elements.Add(25, new Element(25, "Manganese", "Transition Metal")); // Adds Manganese
            elements.Add(26, new Element(26, "Iron", "Transition Metal"));      // Adds Iron
            elements.Add(27, new Element(27, "Cobalt", "Transition Metal"));    // Adds Cobalt
            elements.Add(28, new Element(28, "Nickel", "Transition Metal"));    // Adds Nickel
            elements.Add(29, new Element(29, "Copper", "Transition Metal"));    // Adds Copper
            elements.Add(30, new Element(30, "Zinc", "Transition Metal"));      // Adds Zinc

            Console.WriteLine("Hi there! Happy to help!");                      // Prints the initial greeting
            
            bool isRunning = true;                                              // Boolean to control the loop
            while (isRunning)                                                   // Loop to keep asking the user
            {
                Console.Write("Provide atomic number of the element: ");        // Prompts user for input
                try                                                             // Starts exception handling block
                {
                    int atomicNum = int.Parse(Console.ReadLine());              // Converts user input to integer

                    if (elements.ContainsKey(atomicNum))                        // Checks if dictionary has this key
                    {
                        Element el = elements[atomicNum];                       // Retrieves element object from dictionary
                        Console.WriteLine($"Atomic Number: {el.AtomicNumber}"); // Prints atomic number using inherited property
                        Console.WriteLine($"Name: {el.Name}");                  // Prints element name using inherited property
                        Console.WriteLine($"Class: {el.ElementClass}");         // Prints element class using specific property
                    }
                    else                                                        // Triggered if key is not 1-30
                    {
                        Console.WriteLine("Please enter a number between 1 and 30."); // Prints validation error
                    }
                }
                catch (Exception)                                               // Catches non-integer text inputs
                {
                    Console.WriteLine("Invalid input. Please enter a valid number."); // Prints exception error message
                }

                Console.Write("Do you want to know more elements [y/n]? ");     // Prompts to continue
                string choice = Console.ReadLine().ToLower();                   // Reads choice and makes it lowercase
                if (choice == "n")                                              // Checks if user wants to exit
                {
                    isRunning = false;                                          // Stops the loop
                    Console.WriteLine("Thanks!");                               // Prints goodbye message
                }
            }
        }
    }
}