using System;                                       // Required for Console output

namespace ChurrosApp                                // Uses the same group name to link files
{
    public class Order                              // Defines the Order class
    {
        public int OrderNo { get; set; }            // Property for order number
        public string Details { get; set; }         // Property for order details
        public int Quantity { get; set; }           // Property for quantity
        public double Bill { get; set; }            // Property for total bill

        public Order(int orderNo)                   // Constructor requiring an order number
        {
            OrderNo = orderNo;                      // Initializes the order number
        }

        public void PlaceOrder(Churros item, int qty) // Method to calculate order details
        {
            Details = item.Flavor;                  // Sets details to the churro flavor
            Quantity = qty;                         // Sets the quantity
            Bill = item.Price * qty;                // Calculates total bill using inherited price
        }

        public double PayBill()                     // Method to return the total bill
        {
            return Bill;                            // Returns the calculated bill amount
        }

        public void CollectOrder()                  // Method to process collection
        {
            Console.WriteLine($"Order {OrderNo} collected!"); // Prints collection message
        }
    }
}