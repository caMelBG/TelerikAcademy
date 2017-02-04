using System;


class ClearingCommands
{
    private static char[][] input = new char[][]
    {
        new char[] {'*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},
        new char[] {'*', '*', '>', '*', '*', '*', '*', 'v', '*', '*'},
        new char[] {'*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},
        new char[] {'*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},
        new char[] {'*', '*', '^', '*', '*', '*', '*', '<', '*', '*'},
        new char[] {'v', '*', '*', '*', '*', '*', '*', '*', '*', '*'}
    };

    static void Main()
    {
        for (int row = 0; row < input.Length; row++)
        {
            for (int col = 0; col < input[row].Length; col++)
            {
                if (input[row][col] == '>')
                {
                    ToRight(row, col);
                }

                else if (input[row][col] == '<')
                {
                    ToLeft(row, col);
                }

                else if (input[row][col] == '^')
                {
                    ToUp(row, col);
                }

                else if (input[row][col] == 'v')
                {
                    ToDOwn(row, col);
                }
            }
        }

        for (int i = 0; i < input.Length; i++)
        {
            for (int j = 0; j < input[i].Length; j++)
            {
                Console.Write(input[i][j]);
            }
            Console.WriteLine();
        }
    }

    private static void ToRight(int row, int j)
    {
        for (int col = j + 1; col < input[row].Length; col++)
        {
            if (input[row][col] != '>' && input[row][col] != '<' &&
                input[row][col] != '^' && input[row][col] != 'v')
            {
                input[row][col] = ' ';
            }

            else
            {
                break;
            }
        }
    }

    private static void ToLeft(int row, int j)
    {
        for (int col = j - 1; col >= 0; col--)
        {
            if (input[row][col] != '>' && input[row][col] != '<' &&
                input[row][col] != '^' && input[row][col] != 'v')
            {
                input[row][col] = ' ';
            }

            else
            {
                break;
            }
        }
    }

    private static void ToUp(int i, int col)
    {
        for (int row = i - 1; row >= 0; row--)
        {
            if (input[row][col] != '>' && input[row][col] != '<' &&
                input[row][col] != '^' && input[row][col] != 'v')
            {
                input[row][col] = ' ';
            }

            else
            {
                break;
            }
        }
    }

    private static void ToDOwn(int i, int col)
    {
        for (int row = i + 1; row < input.Length; row++)
        {
            if (input[row][col] != '>' && input[row][col] != '<' &&
                input[row][col] != '^' && input[row][col] != 'v')
            {
                input[row][col] = ' ';
            }

            else
            {
                break;
            }
        }
    }
}

