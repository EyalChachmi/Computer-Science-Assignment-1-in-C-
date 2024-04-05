using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_04
{
    class Program
    {
        static void Main()
        {
            runStringAnalysis();
        }
        private static void runStringAnalysis()
        {
            while (true)
            {
                Console.WriteLine("Please enter a string in a length of 8 that contains digits only or letters only!");
                string userStringInput = Console.ReadLine();

                if (checkIfTheInputIsValid(userStringInput))
                {
                    if (IsPalindrome(userStringInput, 0, userStringInput.Length - 1))
                    {
                        Console.WriteLine("This String is a Palindrome!");
                    }
                    else
                    {
                        Console.WriteLine("This String is not a Palindrome!");
                    }

                    if (checkIfStringContainsOnlyDigits(userStringInput))
                    {
                        int num = int.Parse(userStringInput);

                        if (num % 5 == 0) // will check if the number is divisble by 5
                        {
                            Console.WriteLine(String.Format("The number {0} can be dvided by 5", num));
                        }
                        else
                        {
                            Console.WriteLine(String.Format("{0} can not be dvided by 5", num));
                        }
                    }
                    else
                    {
                        int lowerCaseLetterCount = CountLowercaseLetters(userStringInput);

                        Console.WriteLine(String.Format("There are {0} lower case letters inside the string", lowerCaseLetterCount));
                    }

                    break;
                }
                else
                {
                    Console.WriteLine("Your Input Is Incorrect");
                }
            }
        }
        private static bool checkIfStringContainsOnlyLetters(string i_UserStringInput)
        {
            bool hasNonLetterCharacter = false;

            foreach (char character in i_UserStringInput)
            {
                if (!(character >= 'A' && character <= 'Z') && !(character >= 'a' && character <= 'z')) // will verify if the characters are only small letters or capital letters
                {
                    hasNonLetterCharacter = true;
                    break;
                }
            }

            return !hasNonLetterCharacter;
        }
        private static bool checkIfStringContainsOnlyDigits(string i_UserStringInput)
        {
            int userInputAsNumber;

            return int.TryParse(i_UserStringInput, out userInputAsNumber);
        }
        private static bool checkIfTheInputIsValid(string i_UserStringInput)
        {
            bool isLengthValid = i_UserStringInput.Length == 8;
            bool containsOnlyLetters = checkIfStringContainsOnlyLetters(i_UserStringInput);
            bool containsOnlyDigits = checkIfStringContainsOnlyDigits(i_UserStringInput);

            return isLengthValid && (containsOnlyLetters || containsOnlyDigits);//Firstly the string must contain 8 letters, then if string doesn't contain only letters, check if it contains only digits and return the value correspondingly
        }

        private static bool IsPalindrome(string i_UserStringInput, int i_StringStartingIndex, int i_StringEndIndex)
        {
            bool areIndexesValid = i_StringStartingIndex >= i_StringEndIndex;//Stop condition, it means the method has compared all characters in the substring by iterating on the following indexes
            bool areCharactersEqual = i_UserStringInput[i_StringStartingIndex] == i_UserStringInput[i_StringEndIndex];// If the characters at the indexes are equal, then it proceeds in recursion as seen in the return statement

            return areIndexesValid || (areCharactersEqual && IsPalindrome(i_UserStringInput, i_StringStartingIndex + 1, i_StringEndIndex - 1));
        }
        private static int CountLowercaseLetters(string i_UserStringInput)
        {
            int lowerCaseLettersCount = 0;

            foreach (char character in i_UserStringInput)
            {
                if (char.IsLower(character))
                {
                    lowerCaseLettersCount++;
                }
            }

            return lowerCaseLettersCount;
        }
    }
}
