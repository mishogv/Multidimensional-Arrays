using System;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsAndCols = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            char[][] matrix = new char[rows][];

            int playerRow = -1;
            int playerCol = -1;

            // MAIN matrix info
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().Replace(" ", "").ToCharArray();
                if (matrix[row].Contains('P'))
                {
                    playerRow = row;
                    playerCol = Array.IndexOf(matrix[row], 'P');
                    matrix[row][playerCol] = '.';
                }
            }

            // help matrix info
            char[][] helpMatrix = new char[rows][];
            for (int row = 0; row < rows; row++)
            {
                helpMatrix[row] = new char[cols];
                for (int col = 0; col < cols; col++)
                {
                    helpMatrix[row][col] = matrix[row][col];
                }
            }

            string commands = Console.ReadLine().ToLower();
            bool isDead = false;
            for (int i = 0; i < commands.Length; i++)
            {
                char currentCommand = commands[i];
                switch (currentCommand)
                {
                    case 'u':
                        if (playerRow - 1 >= 0)
                        {
                            playerRow = playerRow - 1;
                        }
                        break;
                    case 'd':
                        if (playerRow + 1 < rows)
                        {
                            playerRow = playerRow + 1;
                        }
                        break;
                    case 'l':
                        if (playerCol - 1 >= 0)
                        {
                            playerCol = playerCol - 1;
                        }
                        break;
                    case 'r':
                        if (playerCol + 1 < cols)
                        {
                            playerCol = playerCol + 1;
                        }
                        break;
                    default:
                        break;
                }


                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (matrix[row][col] == 'B')
                        {
                            if (row - 1 >= 0 && row - 1 < rows && col >= 0 && col < cols)
                            {
                                helpMatrix[row - 1][col] = 'B';
                            }
                            if (row >= 0 && row < rows && col - 1 >= 0 && col - 1 < cols)
                            {
                                helpMatrix[row][col - 1] = 'B';
                            }
                            if (row + 1 >= 0 && row + 1 < rows && col >= 0 && col < cols)
                            {
                                helpMatrix[row + 1][col] = 'B';
                            }
                            if (row >= 0 && row < rows && col + 1 >= 0 && col + 1 < cols)
                            {
                                helpMatrix[row][col + 1] = 'B';
                            }
                        }
                    }
                }

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row][col] = helpMatrix[row][col];
                    }
                }


                if (helpMatrix[playerRow][playerCol] == 'B')
                {
                    isDead = true;
                    Console.WriteLine(string.Join(Environment.NewLine, helpMatrix.Select(r => string.Join("", r))));
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    break;
                }

            }
            if (isDead == false)
            {
                Console.WriteLine(string.Join(Environment.NewLine, helpMatrix.Select(r => string.Join("", r))));
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
        }
    }
}