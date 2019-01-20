using System;
using System.Linq;

namespace P02_Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var parameters = Console.ReadLine().Split(' ' , StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = parameters[0];
            var cols = parameters[1];

            var matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new char[cols];
                matrix[row] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            }

            var counter = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    if (matrix[row][col] == matrix[row][col + 1] 
                        && matrix[row + 1][col] == matrix[row + 1][col + 1] 
                        && matrix[row][col] == matrix[row + 1][col]
                        && matrix[row][col + 1] == matrix[row + 1][col + 1])
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
