namespace PeriodicTableApp                                  
{
    public class Matter                                     
    {
        public int AtomicNumber { get; protected set; }     // Property accessible by this class and its children
        public string Name { get; protected set; }          

        public Matter(int atomicNumber, string name)        // Constructor
        {
            AtomicNumber = atomicNumber;                    // Assigns the atomic number and element name
            Name = name;                                    
        }
    }
}
