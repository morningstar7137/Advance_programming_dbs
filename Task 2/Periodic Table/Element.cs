namespace PeriodicTableApp                                  
{
    public class Element : Matter                          
    {
        public string ElementClass { get; private set; }    // Property specific only to the Element class

        public Element(int num, string name, string eClass) : base(num, name) // 'base' sends data to the Matter constructor
        {
            ElementClass = eClass;                          
        }
    }
}
