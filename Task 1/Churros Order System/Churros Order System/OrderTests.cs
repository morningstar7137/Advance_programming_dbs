using Microsoft.VisualStudio.TestTools.UnitTesting; // Imports the Unit Testing framework

namespace ChurrosApp.Tests                          // Logical namespace for tests
{
    [TestClass]                                     // Defines this as a test class
    public class OrderTests                         // Name of the test class
    {
        [TestMethod]                                // Defines this as a test case
        public void PayBillTest()                   // Name of the specific test
        {
            Churros testItem = new Churros("Test", 5.00); // Sets up test data
            Order testOrder = new Order(99);        // Creates a test order
            testOrder.PlaceOrder(testItem, 3);      // Executes the method to test
            
            double expected = 15.00;                // Defines expected result (5 * 3)
            double actual = testOrder.PayBill();    // Gets actual result

            Assert.AreEqual(expected, actual);      // Checks if actual matches expected
        }
    }
}