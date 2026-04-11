namespace ChurrosApp                               
{
    public class MenuItem                           
    {
        public double Price { get; set; }           // Property for the price of the item
        
        public MenuItem(double price)               // Constructor to initialize the price
        {
            Price = price;                         
        }
    }
}
