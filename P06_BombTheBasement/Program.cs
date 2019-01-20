namespace P06_BombTheBasement
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            if (input == null || input == string.Empty)
            {
                Environment.Exit(0);
            }

            var dimensions = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var rows = dimensions[0];
            var cols = dimensions[1];
            var matrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new int[cols];
            }

            var parameters = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var targetRow = parameters[0];
            var targetColumn = parameters[1];
            var radius = parameters[2];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    var distance = Math.Sqrt(Math.Pow(row - targetRow, 2) + Math.Pow(col - targetColumn, 2));

                    if (distance <= radius)
                    {
                        matrix[row][col] = 1;
                    }
                }
            }

            var secondMatrix = new int[cols][];

            for (int row = 0; row < cols; row++)
            {
                secondMatrix[row] = new int[rows];

                for (int col = 0; col < rows; col++)
                {
                    secondMatrix[row][col] = matrix[col][row];
                }

                secondMatrix[row] = secondMatrix[row].OrderByDescending(x => x).ToArray();
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row][col] = secondMatrix[col][row];
                }
                
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("",row));
            }
        }
    }
}
