using System;                                       // Required for Console input/output
using System.Collections.Generic;                   // Required for Queue data structure

namespace ChurrosApp                                // Uses the same group name to link files
{
    class Program                                   // Main application class
    {
        static void Main(string[] args)             // Entry point of the program
        {
            Queue<Order> queue = new Queue<Order>();// Initializes Queue for handling orders
            int currentOrderNo = 1;                 // Tracks the next order number

            Churros[] menu = {                      // Array storing the menu items
                new Churros("Plain sugar", 6.00),   // Menu item index 0
                new Churros("Cinnamon sugar", 6.00),// Menu item index 1
                new Churros("Chocolate sauce", 8.00),// Menu item index 2
                new Churros("Nutella", 8.00)        // Menu item index 3
            };

            bool isRunning = true;                  // Controls the main loop
            while (isRunning)                       // Keeps the menu active
            {
                Console.WriteLine("\nDelicious Churros:"); // Prints menu header
                Console.WriteLine("1. Place order");       // Prints option 1
                Console.WriteLine("2. Deliver order");     // Prints option 2
                Console.WriteLine("0. Exit");              // Prints option 0
                Console.Write("Choose your option: ");     // Prompts for input

                string choice = Console.ReadLine(); // Reads user input

                if (choice == "1")                  // If user wants to order
                {
                    Console.Write("Enter item (1-4): "); // Prompts for item
                    int index = int.Parse(Console.ReadLine()) - 1; // Gets array index
                    
                    Console.Write("Enter quantity: "); // Prompts for quantity
                    int qty = int.Parse(Console.ReadLine()); // Gets quantity

                    Order newOrder = new Order(currentOrderNo++); // Creates a new order
                    newOrder.PlaceOrder(menu[index], qty); // Calculates the bill
                    queue.Enqueue(newOrder);        // Adds order to the queue

                    Console.WriteLine($"Total Bill: €{newOrder.PayBill()}"); // Shows bill
                }
                else if (choice == "2")             // If user wants to deliver
                {
                    if (queue.Count > 0)            // Checks if orders exist in queue
                    {
                        Order ready = queue.Dequeue(); // Removes first order from queue
                        ready.CollectOrder();       // Delivers the order
                    }
                    else                            // If queue is empty
                    {
                        Console.WriteLine("Queue is empty."); // Prints empty message
                    }
                }
                else if (choice == "0")             // If user wants to exit
                {
                    isRunning = false;              // Stops the loop
                }
            }
        }
    }
}