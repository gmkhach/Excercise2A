using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatingAverages
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The sum of the inputted numbers is: " + sum());
        }
        static double sum()
        {
            bool keeplooping = true;
            double sum = 0;
            double decimalNumber;
            do
            {
                Console.WriteLine("Enter 10 numbers between 0 and 100, seperated with commas.");
                string input = Console.ReadLine();
                string[] numbers = input.Split(',').ToArray<string>();
                if (numbers.Count() == 10)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        string currentItem = numbers[i].Trim();
                        //validates that the input is numeric, and makes sure the value is between 0 and 100. If so, adds to the total.
                        if (double.TryParse(currentItem, out decimalNumber)
                            && double.Parse(currentItem) >= 0
                            && double.Parse(currentItem) <= 100)
                        {
                            sum += double.Parse(currentItem);
                            // verifies that 10 numbers have been summed. 
                            if (i == 9)
                            {
                                keeplooping = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid entry.");
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid entry.");
                }
            } while (keeplooping);
            return sum;
        }
    }
}
