using System;
using System.Linq;

namespace P08_BOooooombs
{
    class Program
    {
        static int[][] matrix;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            if (n < 1)
            {
                return;
            }

            matrix = new int[n][];

            for (int row = 0; row < n; row++)
            {
                matrix[row] = new int[n];
                matrix[row] = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            var coords = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var coord in coords)
            {
                var coordArgs = coord
                    .Split(',')
                    .Select(int.Parse)
                    .ToArray();

                var row = coordArgs[0];
                var col = coordArgs[1];
                BoombCells(row, col);
            }
            
            var aliveCells = 0;
            var sum = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row][col] > 0)
                    {
                        aliveCells++;
                        sum += matrix[row][col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static void BoombCells(int row, int col)
        {
            var damage = matrix[row][col];
            if (damage > 0)
            {
                BombCell(row - 1, col - 1, damage);
                BombCell(row - 1, col, damage);
                BombCell(row - 1, col + 1, damage);
                BombCell(row, col - 1, damage);
                BombCell(row, col + 1, damage);
                BombCell(row + 1, col - 1, damage);
                BombCell(row + 1, col, damage);
                BombCell(row + 1, col + 1, damage);
                matrix[row][col] = 0;
            }
        }

        private static void BombCell(int row, int col, int damage)
        {
            if (row >= 0 && row < matrix.Length &&
                col >= 0 && col < matrix.Length &&
                matrix[row][col] > 0)
            {
                matrix[row][col] -= damage;
            }
        }
    }
}
