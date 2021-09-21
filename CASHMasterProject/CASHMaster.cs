using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASHMasterProject
{
    public class CASHMaster
    {
        decimal[] denomination = { 0.01M, 0.05M, 0.10M, 0.25M, 0.50M, 1.00M, 2.00M, 5.00M, 10.00M, 20.00M, 50.00M, 100.00M }; // US DENOMINATION
                                                                                                                              //decimal[] denomination = { 0.05M, 0.10M, 0.20M, 0.50M, 1.00M, 2.00M, 5.00M, 10.00M, 20.00M, 50.00M, 100.00M }; //MX DENOMINATION
        public static void Main(string[] args)
        {

        }

        //This function will return a list of decimal values. 
        //Each value represents a coin or a bill.
        //
        public List<decimal> calculateChange(decimal price, decimal[] bc)
        {
            //You will received the price and the array of bills and coins
            decimal totalBC = 0;
            decimal sub = 0;
            List<decimal> change = new List<decimal>();

            //you need to subtract the total of your bills and coins to know what will be your change
            foreach (decimal b in bc)
            {
                Console.WriteLine("(POS) is receiving: $" + b);
                totalBC += b;
            }

            Console.WriteLine("Total Received: $" + totalBC);
            if (price <= totalBC) //if this is false, this means that your array of bills and coins are not enough to purchase the article
            {
                if (totalBC != price)
                {
                    sub = totalBC - price;
                    do
                    {
                        for (var i = 0; i < denomination.Length; i++)
                        {
                            if (sub == denomination[i])//if this is true you will subtract this value from "sub" variable.
                            {
                                sub -= denomination[i];
                                change.Add(denomination[i]);
                                break;
                            }

                            if (sub <= denomination[i])//If this is true, you will take the last value before this and subtract this value from your "sub" variable.
                            {
                                sub -= i == 0 ? denomination[i] : denomination[i - 1];
                                change.Add(i == 0 ? denomination[i] : denomination[i - 1]);
                                break;
                            }
                        }
                        //you will keep doing this until the "sub" variable equals 0
                    } while (sub != 0);
                }
                else
                {// this means you don't have to give change, the bills and coins sum the exact amount of the article
                    Console.WriteLine("--No change--");
                }
            }
            else
            {
                Console.WriteLine("--Article price: " + price + "--");
                Console.WriteLine("--Insufficient Funds--");

            }

            return change;
        }
    }
}
