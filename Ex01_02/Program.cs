using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_02
{
    class Program
    {
        static void Main()
        {
            printDiamondShapeRecursivly();
        }
        private static void printDiamondShapeRecursivly(int i_StarsNumberInRow = 1)
        {
            if (i_StarsNumberInRow > 9) // stop condition, if we passed the desired max stars in the widest row (9 stars)
            {
                return;
            }

            int starsInTheCurrentRow = i_StarsNumberInRow % 2 == 0 ? i_StarsNumberInRow + 1 : i_StarsNumberInRow; // to create a diamond shape pattern in each row.
            int spacesForStarsCenter = (9 - starsInTheCurrentRow) / 2; // calculates the number of spaces needed to center the stars within a row
            StringBuilder currentStringRow = new StringBuilder();

            currentStringRow.Append(' ', spacesForStarsCenter);
            currentStringRow.Append('*', starsInTheCurrentRow);//appends necessary spaces at the beginning and then appends the stars.
            Console.WriteLine(currentStringRow.ToString());
            printDiamondShapeRecursivly(i_StarsNumberInRow + 2);
            StringBuilder mirroredStringRow = new StringBuilder();

            if (i_StarsNumberInRow < 9)// printing the mirrored part of each row, the if statement ensures the last row of the first half is not duplicated
            {
                mirroredStringRow.Append(' ', spacesForStarsCenter);
                mirroredStringRow.Append('*', starsInTheCurrentRow);
                Console.WriteLine(mirroredStringRow.ToString());
            }
        }
    }
}
