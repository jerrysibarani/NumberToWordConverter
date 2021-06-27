using System;
using System.Collections.Generic;
using System.Text;

namespace NumberToWordConverter
{
    class numToWords
    {
        private static String[] units = { "ZERO", "ONE", "TWO", "THREE","FOUR", "FIVE",
                                          "SIX","SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN",
                                          "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN",
                                          "SIXTEEN","SEVENTEEN", "EIGHTEEN", "NINETEEN" };

        private static String[] tens = { "", "", "TWENTY", "THIRTY", "FORTY","FIFTY",
                                        "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };
        public static String ConvertAmount(decimal amount)
        {
            try
            {
                long count_to_int = (long)amount;
                long count_to_dec = (long)Math.Round((amount - (decimal)(count_to_int)) * 100); // toRoundup the comma 

                if (count_to_int == 0 && count_to_dec == 0)
                {
                    return Convert(count_to_int) + "."; // if zero only
                }
                else if (count_to_int == 0 && count_to_dec > 0)
                {
                    return Convert(count_to_dec) + " CENTS."; // if cent only
                }
                else if (count_to_int == 1 && count_to_dec == 0)
                {
                    return Convert(count_to_int) + " DOLLAR."; // if one only
                }
                else if (count_to_int > 1 && count_to_dec == 0)
                {
                    return Convert(count_to_int) + " DOLLARS."; // if one above only
                }
                else if (count_to_int == 1 && count_to_dec > 0)
                {
                    return Convert(count_to_int) + " DOLLARS AND " + Convert(count_to_dec) + " CENTS.";  // if one with cents 
                }
                else
                {
                    return Convert(count_to_int) + " DOLLARS AND " + Convert(count_to_dec) + " CENTS."; //more than 0ne dollar include cents
                }
            }
            catch (Exception e)
            {
                if (e.ToString().Contains("Value was either too large"))
                {
                    Console.WriteLine("");
                    Console.WriteLine("Please check your input, the max value allowable is around: (0 to 10^18) !! ");
                }
                else if (e.ToString().Contains("outside the bounds of the array"))
                {
                    Console.WriteLine("");
                    Console.WriteLine("Please check your input, the walue  allowed is around (0 to 10^18)! ");
                }
                else if (e.ToString().Contains("Input string was not in a correct format"))
                {
                    Console.WriteLine("");
                    Console.WriteLine("Please check your input, string value not allowed! ");
                }               
                else
                {
                    Console.WriteLine("Please Check Please check your input: " + e);
                }                
            }
            return "";
        }

        public static String Convert(long i)
        {             
                    if (i < 20)
                    {
                        return units[i];
                    }

                    if (i < 100)
                    {
                        return tens[i / 10] + ((i % 10 > 0) ? " " + Convert(i % 10) : "");
                    }

                    if (i < (Math.Pow(10, 3)))
                    {
                        return units[i / 100] + " HUNDRED" + ((i % 100 > 0) ? " AND " + Convert(i % 100) : "");
                    }

                    if (i < (Math.Pow(10, 5)))
                    {
                        return Convert(i / 1000) + " THOUSAND " + ((i % 1000 > 0) ? "" + Convert(i % 1000) : "");
                    }

                    if (i < (Math.Pow(10, 6))) // < 1000.000
                    {
                        if (i == 900000)
                        {
                            return Convert(i / 100000) + " HUNDRED THOUSAND " + ((i % 100000 > 0) ? "" + Convert(i % 100000) : "");
                        }
                        return Convert(i / 100000) + " HUNDRED " + ((i % 100000 > 0) ? "" + Convert(i % 100000) : "");
                    }

                    if (i < (Math.Pow(10, 8))) // < 100.000.000
                    {
                        if (i == 1000000)
                        {
                            return Convert(i / 1000000) + " MILLION " + ((i % 1000000 > 0) ? "" + Convert(i % 1000000) : "");
                        }
                        return Convert(i / 1000000) + " MILLION " + ((i % 1000000 > 0) ? "" + Convert(i % 1000000) : "");
                    }

                    if (i < (Math.Pow(10, 9))) // < 1000.000.000
                    {
                        if (i == 100000000)
                        {
                            return Convert(i / 100000000) + " HUNDRED MILLION " + ((i % 100000000 > 0) ? "" + Convert(i % 100000000) : "");
                        }
                        return Convert(i / 100000000) + " HUNDRED " + ((i % 100000000 > 0) ? "" + Convert(i % 100000000) : "");
                    }

                    if (i < (Math.Pow(10, 11))) // < 100.000.000.000
                    {
                        if (i == 1000000000)
                        {
                            return Convert(i / 1000000000) + " BILLION " + ((i % 1000000000 > 0) ? "" + Convert(i % 1000000000) : "");
                        }
                        return Convert(i / 1000000000) + " BILLION " + ((i % 1000000000 > 0) ? "" + Convert(i % 1000000000) : "");
                    }

                    if (i < (Math.Pow(10, 12))) // < 1000.000.000.000
                    {
                        if (i == 100000000000)
                        {
                            return Convert(i / 100000000000) + " HUNDRED BILLION " + ((i % 100000000000 > 0) ? "" + Convert(i % 100000000000) : "");
                        }
                        return Convert(i / 100000000000) + " HUNDRED " + ((i % 100000000000 > 0) ? "" + Convert(i % 100000000000) : "");
                    }

                    if (i < (Math.Pow(10, 14))) //100.000.000.000.000 < 100.000.000.000.000
                    {
                        if (i == 1000000000000)
                        {
                            return Convert(i / 1000000000000) + " TRILLION " + ((i % 1000000000000 > 0) ? "" + Convert(i % 1000000000000) : "");
                        }
                        return Convert(i / 1000000000000) + " TRILLION " + ((i % 1000000000000 > 0) ? "" + Convert(i % 1000000000000) : "");
                    }            

                    if (i < (Math.Pow(10, 16))) // < 10.000.000.000.000.000
                    {
                        if (i == 100000000000000)
                        {
                            return Convert(i / 100000000000000) + " HUNDRED TRILLION " + ((i % 100000000000000 > 0) ? "" + Convert(i % 100000000000000) : "");
                        }
                        return Convert(i / 100000000000000) + " HUNDRED " + ((i % 100000000000000 > 0) ? "" + Convert(i % 100000000000000) : "");
                    }

                    if (i < (Math.Pow(10, 18))) // < 1.000.000.000.000.000.000
                    {
                        if (i == 10000000000000000)
                        {
                            return Convert(i / 10000000000000000) + " QUADRILLION " + ((i % 10000000000000000 > 0) ? "" + Convert(i % 10000000000000000) : "");
                        }
                        return Convert(i / 10000000000000000) + " QUADRILLION " + ((i % 10000000000000000 > 0) ? "" + Convert(i % 10000000000000000) : "");
                    }
               
                    if (i <= (9 * (Math.Pow(10, 18))))  // Since Long max val is: 9,223,372,036,854,775,807  //9*10^18 // Nine QUANTILLION
                    {
                        if (i == (Math.Pow(10, 18)))
                        {
                            return Convert(i / 1000000000000000000) + " QUANTILLION " + ((i % 1000000000000000000 > 0) ? "" + Convert(i % 1000000000000000000) : "");  //10^18
                        }
                        return Convert(i / 1000000000000000000) + " QUANTILLION " + ((i % 1000000000000000000 > 0) ? "" + Convert(i % 1000000000000000000) : "");
                    }
                return Convert(i / 1000000000000000000) + " QUANTILLION " + ((i % 1000000000000000000 > 0) ? "" + Convert(i % 1000000000000000000) : ""); //"Please Insert the proper value";
        }
    }
}
