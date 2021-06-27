using System;

namespace NumberToWordConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            ////-------------UNIT TESTING, Please uncomment code below if you need to test the units---------- -
            //foreach (string i in unitTesting.testingList)
            //{
            //    System.Console.Write("{0} ", i);
            //    System.Console.Write("");
            //    System.Console.Write(numToWords.ConvertAmount(decimal.Parse(i)));
            //    System.Console.WriteLine("");
            //}

            try
            {
                Console.WriteLine("Please Type Numbers To Convert To Words:");
                string number = Console.ReadLine();
                number = numToWords.ConvertAmount(decimal.Parse(number));

                if (number.Length > 0)
                {
                    Console.WriteLine("---------");
                    Console.WriteLine("");
                    Console.WriteLine("Number in words: \n{0}", number);
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("Value was either too large"))
                {
                    Console.WriteLine("");
                    Console.WriteLine("Please Check Your Input, the value allowed is around: (0 to 10^18) !! ");
                }
                else if (ex.ToString().Contains("Input string was not in a correct format"))
                {
                    Console.WriteLine("");
                    Console.WriteLine("Please Check Your Input, string value not allowed! ");
                }
                else
                {
                    Console.WriteLine("Please Check Your Input: " + ex.ToString());
                }

            }
        }
    }
}
