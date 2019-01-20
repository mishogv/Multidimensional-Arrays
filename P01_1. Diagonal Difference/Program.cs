using System;
using System.Linq;

namespace P01_1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentRows = int.Parse(Console.ReadLine());

            var matrix = new int[currentRows][];

            var firstDiagonal = 0;
            var secondDiagonal = 0;

            for (int rows = 0; rows < currentRows; rows++)
            {
                var input = Console.ReadLine().Split(' ' , StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                matrix[rows] = new int[input.Length];
                matrix[rows] = input;
            }

            for (int rows = 0; rows < currentRows; rows++)
            {
                firstDiagonal += matrix[rows][rows];
            }

            for (int rows = 0; rows < currentRows; rows++)
            {
                secondDiagonal += matrix[rows][currentRows - rows - 1];
            }

            var difference = Math.Abs(firstDiagonal - secondDiagonal);

            Console.WriteLine(difference);
        }
    }
}
