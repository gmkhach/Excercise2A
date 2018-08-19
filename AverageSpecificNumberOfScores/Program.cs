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
            int numberOfScores;
            double average;
            bool keepLooping = true;
            do
            {
                Console.WriteLine("How many test scores are there?");
                string input = Console.ReadLine();
                //validates that the input is a natural number.
                if (int.TryParse(input.Trim(), out numberOfScores)
                    && int.Parse(input.Trim()) >= 0)
                {
                    numberOfScores = int.Parse(input.Trim());
                    keepLooping = false;
                }
                else
                {
                    Console.WriteLine("invalid entry.");
                }
            } while (keepLooping);
            average = getAverage(numberOfScores);
            Console.WriteLine("The average numeric score is: " + average);
            Console.WriteLine("The average letter grade is: " + getGrade(average));
        }
        static double getAverage(int numberOfScores)
        {
            bool keeplooping = true;
            double average = 0;
            double sum = 0;
            double decimalNumber;
            do
            {
                Console.WriteLine($"Enter {numberOfScores} numeric grades between 0 and 100, separated with commas.");
                string input = Console.ReadLine();
                List<string> numbers = input.Split(',').ToList<string>();
                if (numbers.Count() == numberOfScores)
                {
                    for (int i = 0; i < numbers.Count(); i++)
                    {
                        string currentItem = numbers[i];
                        //validates that the input is numeric, and makes sure the value is between 0 and 100. If so, adds to the total.
                        if (double.TryParse(currentItem.Trim(), out decimalNumber)
                            && double.Parse(currentItem.Trim()) >= 0
                            && double.Parse(currentItem.Trim()) <= 100)
                        {
                            sum += double.Parse(currentItem);
                            // verifies that all numbers have been summed. 
                            if (i == numberOfScores - 1)
                            {
                                average = sum / numberOfScores;
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
            return average;
        }
        static char getGrade(double average)
        {
            char grade;
            switch (Convert.ToInt32(average)/ 10)
            {
                case 9:
                    grade = 'A';
                    break;
                case 8:
                    grade = 'B';
                    break;
                case 7:
                    grade = 'C';
                    break;
                case 6:
                    grade = 'D';
                    break;
                default:
                    grade = 'F';
                    break;
            }
            return grade;
        }
    }
}
