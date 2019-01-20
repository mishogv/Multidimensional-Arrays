using System;
using System.Linq;

namespace P03_MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var parameters = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = parameters[0];
            var cols = parameters[1];

            var matrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new int[cols];
                matrix[row] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            var theBestSum = int.MinValue;
            var theBestMatrix = new int[3][];

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    var currentSum = matrix[row][col] + matrix[row][col + 1]
                                                      + matrix[row][col + 2]
                                                      + matrix[row + 1][col]
                                                      + matrix[row + 1][col + 1]
                                                      + matrix[row + 1][col + 2]
                                                      + matrix[row + 2][col]
                                                      + matrix[row + 2][col + 1]
                                                      + matrix[row + 2][col + 2];

                    if (currentSum > theBestSum)
                    {
                        theBestSum = currentSum;

                        theBestMatrix[0] = new int[3];
                        theBestMatrix[1] = new int[3];
                        theBestMatrix[2] = new int[3];

                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                theBestMatrix[i][j] = matrix[row + i][col + j];
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Sum = {theBestSum}");

            foreach (var row in theBestMatrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
