using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_05
{
    class Program
    {
        static void Main()
        {
            runNumberStatistics();
        }
        private static bool checkIfTheInputIsValid(string i_UserStringInput)
        {
            int result;

            return i_UserStringInput.Length == 9 && int.TryParse(i_UserStringInput, out result) && result>0;
        }
        private static int[] getArrayOfDigits(string i_UserStringInput)//the method converts a string input to an integer, extracts its digits, and stores them in an array
        {
            int integerInput;
            int.TryParse(i_UserStringInput, out integerInput);
            int[] digitsArray=new int[9];

            for (int i = 9; i > 0; i--)
            {
                digitsArray[i-1] = integerInput % 10;
                integerInput /= 10;
            }

            return digitsArray;
        }
        private static int countOfDigitsDividableByFour(int[] i_DigitsArray)
        {
            int countOfDigitsDividableByFour = 0;

            foreach (int digit in i_DigitsArray)
            {
                if (digit % 4 == 0)
                {
                    countOfDigitsDividableByFour++;
                }
            }

            return countOfDigitsDividableByFour;
        }
        private static int countOfDigitsThatAreGreaterThanUnitsDigit(int[] i_DigitsArray)
        {
            int countOfDigitsThatAreGreaterThanUnitsDigit = 0;

            foreach (int digit in i_DigitsArray)
            {
                if (digit > i_DigitsArray[8])
                {
                    countOfDigitsThatAreGreaterThanUnitsDigit++;
                }
            }

            return countOfDigitsThatAreGreaterThanUnitsDigit;
        }
        private static void runNumberStatistics()
        {
            while (true)
            {
                Console.WriteLine("Please enter a Valid Positive Integer that contains only 9 digits");
                string userStringInput = Console.ReadLine();

                if (!checkIfTheInputIsValid(userStringInput))
                {
                    Console.WriteLine("This input is not valid, Please repeat");
                }
                else
                {
                    int[] digitsArray = getArrayOfDigits(userStringInput);

                    Console.WriteLine(String.Format("The Max digit in the current number is: {0}", digitsArray.Max()));
                    Console.WriteLine(String.Format("The Min digit in the current number is: {0}", digitsArray.Min()));
                    Console.WriteLine(String.Format("The amount of digits in the current number that are dividable by 4 are: {0}",
                        countOfDigitsDividableByFour(digitsArray)));
                    Console.WriteLine(String.Format("The amount of digits in the current number that are greater than the units Digit are: {0}",
                        countOfDigitsThatAreGreaterThanUnitsDigit(digitsArray)));
                    break;
                }
            }
        }
    }
}
