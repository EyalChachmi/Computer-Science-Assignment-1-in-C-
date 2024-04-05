using System;
using System.Diagnostics.Contracts;
using System.Diagnostics.PerformanceData;
using System.Linq;

namespace Ex01_01
{
    class Program
    {
        static void Main()
        {
            //This is the entry point
            runBinarySeriesStatistics();
        }
        private static void runBinarySeriesStatistics()
        {
            string[] binaryNumbersStringArray = checkIfUserInputIsValidAndGetBinaryNumbersArray();
            int[] integerNumbersArray = convertBinaryNumbersArrayToIntegerNumbersArrayInAcsendingOrder(binaryNumbersStringArray);
            averageDigitsOfOneAndZeroInInputNumbers(binaryNumbersStringArray);
            checkIfNumIsPowerOf2(integerNumbersArray);
            checkIfInputNumberIsAnAscendingSeries(integerNumbersArray);
            checkTheMaxNumAndMinNum(integerNumbersArray);
        }
        private static void checkTheMaxNumAndMinNum(int[] i_IntegerNumbersArray)
        {
            Console.WriteLine(String.Format("The Max Number is:{0}", i_IntegerNumbersArray.Max()));
            Console.WriteLine(String.Format("The Min Number is:{0}", i_IntegerNumbersArray.Min()));
        }
        private static void checkIfInputNumberIsAnAscendingSeries(int[] i_IntegerNumbersArray)
        {
            int counterOfAscendingSeriesNumbers = 0;

            for (int i = 0; i < 3; i++)
            {
                bool isAcending = true;
                string integerNumberAsString = i_IntegerNumbersArray[i].ToString(); // Here we take take the specific number and convert it to string, for easier use later and readabillity

                for (int j  = 0; j < integerNumberAsString.Length - 1; j++)
                {
                    if (integerNumberAsString[j] >= integerNumberAsString[j + 1]) //Here we check whether the values in the array is in ascending order
                    {
                        isAcending = false; // if one of the values break the ascending order and don't validate it, we continue to the next value in the i_IntegerNumbersArray
                        break;
                    }
                }

                if(isAcending)
                {
                    counterOfAscendingSeriesNumbers++;
                }
            }

            Console.WriteLine(String.Format("There are {0} numbers that are an ascending sequence", counterOfAscendingSeriesNumbers));
        }
        private static void checkIfNumIsPowerOf2(int[] i_IntegerNumbersArray)
        {
            int counterNumsPowerOf2 = 0;

            for (int i = 0; i < 3; i++)
            {
                if(Math.Log(i_IntegerNumbersArray[i], 2) % 1 == 0) // Here we check if a number is a power of two using a logarithm and checking that it is exactly divisble by 1
                {
                    counterNumsPowerOf2++;
                }
            }

            Console.WriteLine(String.Format("There are {0} numbers that are a Power of 2", counterNumsPowerOf2));
        }
        private static void averageDigitsOfOneAndZeroInInputNumbers(string[] i_BinaryNumbersStringArray)
        {
            float countOfZeros = 0;
            float countOfOnes = 0;

            for (int i = 0; i < i_BinaryNumbersStringArray.Length; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (i_BinaryNumbersStringArray[i][j] == '1')
                    {
                        countOfOnes++;
                    }
                    else
                    {
                        countOfZeros++;
                    }
                }
            }

            Console.WriteLine(String.Format("The average Number of Ones is: {0}", countOfOnes / 3));
            Console.WriteLine(String.Format("The average Number of Zeros is: {0}", countOfZeros / 3));
        }
        private static string[] checkIfUserInputIsValidAndGetBinaryNumbersArray()
        {
            string[] binaryNumbersStringArray = new string[3];

            for (int i = 0; i < 3; i++)//iterates in the loop to fill the binaryNumbersStringArray with valid binary numbers
            {
                bool validBinaryNumInput = false;

                while (validBinaryNumInput != true) // validates the input
                {
                    bool validBinaryDigit = true;

                    Console.WriteLine("Please enter a binary Positive Integer Containing 9 digits ");
                    string userInput = Console.ReadLine();

                    if (userInput.Length != 9)
                    {
                        Console.WriteLine("Invalid Input! Your number must contain 9 digits!");
                    }
                    else if(userInput == "000000000") // 0 is not a positive number
                    {
                        Console.WriteLine("Invalid Input! Your number must be positive!");
                    }
                    else
                    {
                        for (int j = 0; j < 9; j++)
                        {               
                            if (userInput[j] != '0' && userInput[j] != '1')
                            {
                                Console.WriteLine("Invalid Input! Your number must contain Binary digits only!");
                                validBinaryDigit = false;// if the number didn't contain binary digits, with this flag we'll know whetever the user has to repeat the process or not
                                break;
                            }
                        }

                        if(validBinaryDigit == true)
                        {
                            binaryNumbersStringArray[i] = userInput;
                            validBinaryNumInput = true;// if the number is valid after all the checks, we'll now move over to the outer loop and check the next number
                        }
                    }
                }
            }

            return binaryNumbersStringArray;
        }
        private static int[] convertBinaryNumbersArrayToIntegerNumbersArrayInAcsendingOrder(string[] i_BinaryNumbersStringArray)
        {
            int[] integerNumbersArray = { 0, 0, 0 };

            for(int i = 0; i < i_BinaryNumbersStringArray.Length; i++)
            {
                for(int j = 8, power = 0; j >= 0; j--, power++)
                {
                    if (i_BinaryNumbersStringArray[i][j] == '1')
                    {
                        integerNumbersArray[i] += (int)Math.Pow(2, power); //Here we sum up the integer numbers that come as a result of the conversion from base 2 to 10
                    }
                }
            }

            Array.Sort(integerNumbersArray);
            Console.WriteLine(String.Format("The numbers in their Interger form and in the acsending order are: {0} {1} {2}", integerNumbersArray[0], 
                integerNumbersArray[1], integerNumbersArray[2]));

            return integerNumbersArray;
        }
    }
}
