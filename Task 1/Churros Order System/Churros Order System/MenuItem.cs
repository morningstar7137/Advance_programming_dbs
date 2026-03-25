namespace ChurrosApp                                // Groups related files together
{
    public class MenuItem                           // Defines the base parent class
    {
        public double Price { get; set; }           // Property for the price of the item
        
        public MenuItem(double price)               // Constructor to initialize the price
        {
            Price = price;                          // Assigns the price value
        }
    }
}