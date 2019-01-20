using System;
using System.Linq;

namespace P05_SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            if (input == null || input == string.Empty)
            {
                Environment.Exit(0);
            }

            var dimensions = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var rows = dimensions[0];
            var cols = dimensions[1];

            var text = Console.ReadLine();

            var matrix = new char[rows][];
            var counter = 0;
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new char[cols];
                
                for (int col = 0; col < cols; col++)
                {
                    matrix[row][col] = text[counter];
                    counter++;
                    if (counter == text.Length)
                    {
                        counter = 0;
                    }
                }
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
