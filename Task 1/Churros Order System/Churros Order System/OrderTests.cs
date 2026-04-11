using Microsoft.VisualStudio.TestTools.UnitTesting; 

namespace ChurrosApp.Tests                          
{
    [TestClass]                                     
    public class OrderTests                         // Name of the test class
    {
        [TestMethod]                                
        public void PayBillTest()                  
        {
            Churros testItem = new Churros("Test", 5.00); // Sets up test data
            Order testOrder = new Order(99);        // Creates a test order
            testOrder.PlaceOrder(testItem, 3);      // Executes the method to test
            
            double expected = 15.00;                
            double actual = testOrder.PayBill();    // Gets actual result

            Assert.AreEqual(expected, actual);      
        }
    }
}
