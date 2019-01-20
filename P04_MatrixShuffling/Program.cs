using System;
using System.Linq;

namespace P04_MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            var parameters = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = parameters[0];
            var cols = parameters[1];
            
            var matrix = new string[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new string[cols];
                matrix[row] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                var command = input.Split(' ' , StringSplitOptions.RemoveEmptyEntries)[0];

                if (command == "swap")
                {
                    var splittedInput = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
                    splittedInput.RemoveAt(0);
                    var @params = splittedInput.Select(int.Parse).ToArray();
                    var firstRow = @params[0];
                    var firstCol = @params[1];
                    var secondRow = @params[2];
                    var secondCol = @params[3];

                    if (firstRow < rows
                        && firstCol < cols
                        && secondCol < cols
                        && secondRow < cols
                        && firstRow >= 0
                        && firstCol >= 0
                        && secondCol >= 0
                        && secondRow >= 0)
                    {
                        var swap = matrix[firstRow][firstCol];
                        matrix[firstRow][firstCol] = matrix[secondRow][secondCol];
                        matrix[secondRow][secondCol] = swap;
                        foreach (var row in matrix)
                        {
                            Console.WriteLine(string.Join(" ", row));
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid input!");
                }
            }
        }
    }
}
