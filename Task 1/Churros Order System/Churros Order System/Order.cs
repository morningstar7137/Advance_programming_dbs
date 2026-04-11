using System;                                       

namespace ChurrosApp                                
{
    public class Order                              
    {
        public int OrderNo { get; set; }            // Property for order number and bill
        public string Details { get; set; }         
        public int Quantity { get; set; }          
        public double Bill { get; set; }           

        public Order(int orderNo)                   // Constructor
        {
            OrderNo = orderNo;                      
        }

        public void PlaceOrder(Churros item, int qty) // Method to calculate order details
        {
            Details = item.Flavor;                  // Sets details to the churro flavor
            Quantity = qty;                         
            Bill = item.Price * qty;                // Calculates total bill using inherited price
        }

        public double PayBill()                    
        {
            return Bill;                            // Returns the calculated bill amount
        }

        public void CollectOrder()                  
        {
            Console.WriteLine($"Order {OrderNo} collected!"); // Prints collection message
        }
    }
}
