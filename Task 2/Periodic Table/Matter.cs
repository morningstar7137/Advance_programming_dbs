namespace PeriodicTableApp                                  // Groups the related files together
{
    public class Matter                                     // Defines the base parent class
    {
        public int AtomicNumber { get; protected set; }     // Property accessible by this class and its children
        public string Name { get; protected set; }          // Property accessible by this class and its children

        public Matter(int atomicNumber, string name)        // Constructor for the parent class
        {
            AtomicNumber = atomicNumber;                    // Assigns the atomic number
            Name = name;                                    // Assigns the element name
        }
    }
}