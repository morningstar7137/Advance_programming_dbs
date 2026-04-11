using System;                                       
using System.Collections.Generic;                   

namespace ChurrosApp                                
{
    class Program                                   
    {
        static void Main(string[] args)             
        {
            Queue<Order> queue = new Queue<Order>();// Initializes Queue for handling orders
            int currentOrderNo = 1;                 // Tracks the next order number

            Churros[] menu = {                      // Array storing the menu items
                new Churros("Plain sugar", 6.00),   
                new Churros("Cinnamon sugar", 6.00),
                new Churros("Chocolate sauce", 8.00),
                new Churros("Nutella", 8.00)        
            };

            bool isRunning = true;                  // Controls the main loop
            while (isRunning)                       // Keeps the menu active
            {
                Console.WriteLine("\nDelicious Churros:"); // Prints menu header
                Console.WriteLine("1. Place order");       
                Console.WriteLine("2. Deliver order");     
                Console.WriteLine("0. Exit");             
                Console.Write("Choose your option: ");     

                string choice = Console.ReadLine(); // Reads user input

                if (choice == "1")                  // If user wants to order
                {
                    Console.Write("Enter item (1-4): "); 
                    int index = int.Parse(Console.ReadLine()) - 1; 
                    
                    Console.Write("Enter quantity: "); 
                    int qty = int.Parse(Console.ReadLine()); 

                    Order newOrder = new Order(currentOrderNo++); // Creates a new order
                    newOrder.PlaceOrder(menu[index], qty); 
                    queue.Enqueue(newOrder);        

                    Console.WriteLine($"Total Bill: €{newOrder.PayBill()}"); // Shows bill
                }
                else if (choice == "2")            
                {
                    if (queue.Count > 0)            
                    {
                        Order ready = queue.Dequeue(); // Removes first order from queue
                        ready.CollectOrder();       
                    }
                    else                            // If queue is empty prints empty message
                    {
                        Console.WriteLine("Queue is empty."); 
                    }
                }
                else if (choice == "0")             // If user wants to exit
                {
                    isRunning = false;             
                }
            }
        }
    }
}
