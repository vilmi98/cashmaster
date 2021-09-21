using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CASHMasterProject;
using System.Collections.Generic;

namespace CashMasterTest
{
    [TestClass]
    public class CASHMasterTest
    {
        [TestMethod]
        public void POSTest()
        {
            //Arrange
            decimal price = 6.37M;
            decimal[] bc = { 1.0M, 1.0M, 5.00M };
            List<decimal> change = new List<decimal>();
            decimal totalChange = 0;
            CASHMaster cashMaster = new CASHMaster();


            //Act
            change = cashMaster.calculateChange(1,bc);


            if (change.Count > 0)
            {
                Console.WriteLine("This is your change: ");
                foreach (decimal c in change)
                {
                    Console.WriteLine("->" + c);
                    totalChange += c;
                }
                Console.WriteLine("Your total change is: " + totalChange);
                Console.WriteLine("Thank you for purchase");
                Console.WriteLine("CASH Master Ends");
            }
            else
            {
                Console.WriteLine("Thank you for purchase");
                Console.WriteLine("CASH Master Ends");
            }
        }
    }
}
