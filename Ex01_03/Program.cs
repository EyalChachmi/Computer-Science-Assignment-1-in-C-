using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_03
{
    class Program
    {
        static void Main()
        {
            getInputFromUserToPrintDiamondShapeRecursivly();
        }
        private static void printDiamondShapeRecursivly(int i_DiamondHeight = 9, int i_StarsNumberInRow = 1)
        {
            if (i_StarsNumberInRow > i_DiamondHeight)// stop condition, if we passed the desired max stars in the widest row based on the user's diamond height input
            {
                return;
            }

            int starsInTheCurrentRow = i_StarsNumberInRow % 2 == 0 ? i_StarsNumberInRow + 1 : i_StarsNumberInRow;// to create a diamond shape pattern in each row.
            int spacesForStarsCenter = (i_DiamondHeight - starsInTheCurrentRow) / 2; // calculates the number of spaces needed to center the stars within a row
            StringBuilder currentStringRow = new StringBuilder();

            currentStringRow.Append(' ', spacesForStarsCenter);//appends necessary spaces at the beginning and then appends the stars.
            currentStringRow.Append('*', starsInTheCurrentRow);
            Console.WriteLine(currentStringRow.ToString());
            printDiamondShapeRecursivly(i_DiamondHeight, i_StarsNumberInRow + 2);
            StringBuilder mirroredStringRow = new StringBuilder();

            if (i_StarsNumberInRow < i_DiamondHeight)// printing the mirrored part of each row, the if statement ensures the last row of the first half is not duplicated. If the diamond height is even, the last row of the first half will be duplicated
            {
                mirroredStringRow.Append(' ', spacesForStarsCenter);
                mirroredStringRow.Append('*', starsInTheCurrentRow);
                Console.WriteLine(mirroredStringRow.ToString());
            }
        }
        private static void getInputFromUserToPrintDiamondShapeRecursivly()
        {
            while (true)
            {
                Console.WriteLine("Please enter a height number for the diamond shape height!");
                if (int.TryParse(Console.ReadLine(), out int height) && height > 0) // validates users input
                {
                    printDiamondShapeRecursivly(height);
                    break;
                }
                else
                {
                    Console.WriteLine("Your input is incorrect! Please enter a number that represents a diamond shape height bigger than 0");
                }
            }
        }
    }
}
