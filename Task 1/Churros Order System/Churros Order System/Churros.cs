namespace ChurrosApp                                
{
    public class Churros : MenuItem                 // Inherits from the MenuItem class
    {
        public string Flavor { get; set; }          // Property specific to Churros
        
        public Churros(string flavor, double price) : base(price) // Passes price up to parent class
        {
            Flavor = flavor;                        
        }
    }
}
