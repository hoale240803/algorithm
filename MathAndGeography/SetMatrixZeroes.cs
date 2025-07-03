namespace algorithm.MathAndGeography;

public class SetMatrixZeroes
{
    // 1. Brute Force
    private int[][] modifiedMatrix;
    public void SetZeroes(int[][] matrix)
    {
        int rows = matrix.Length, cols = matrix[0].Length;
        int[][] mark = new int[rows][];

        for (int r = 0; r < rows; r++)
        {
            mark[r] = (int[])matrix[r].Clone();
        }

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (matrix[r][c] == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        mark[r][col] = 0;
                    }

                    for (int row = 0; row < rows; row++)
                    {
                        mark[row][c] = 0;
                    }
                }
            }
        }

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                matrix[r][c] = mark[r][c];
            }
        }

        modifiedMatrix = matrix;
    }

    // 2. Iteration
    public void SetZeroes1(int[][] matrix)
    {
        int rows = matrix.Length, cols = matrix[0].Length;
        bool[] rowZero = new bool[rows];
        bool[] colZero = new bool[cols];
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (matrix[r][c] == 0)
                {
                    rowZero[r] = true;
                    colZero[c] = true;
                }
            }
        }

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (rowZero[r] || colZero[c])
                {
                    matrix[r][c] = 0;
                }
            }
        }

        modifiedMatrix = matrix;
    }

    // 3. Iteration (space optimized)
    public void SetZeroes2(int[][] matrix)
    {
        int rows = matrix.Length, cols = matrix[0].Length;
        bool rowZero = false;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (matrix[r][c] == 0)
                {
                    matrix[0][c] = 0;
                    if (r > 0)
                    {
                        matrix[r][0] = 0;
                    }
                    else
                    {
                        rowZero = true;
                    }
                }
            }
        }

        for (int r = 1; r < rows; r++)
        {
            for (int c = 1; c < cols; c++)
            {
                if (matrix[0][c] == 0 || matrix[r][0] == 0)
                {
                    matrix[r][c] = 0;
                }
            }
        }

        if (matrix[0][0] == 0)
        {
            for (int r = 0; r < rows; r++)
            {
                matrix[r][0] = 0;
            }
        }

        if (rowZero)
        {
            for (int c = 0; c < cols; c++)
            {
                matrix[0][c] = 0;
            }
        }

        modifiedMatrix = matrix;
    }

    public void PrintModifiedMatrix()
    {
        if (modifiedMatrix == null)
        {
            Console.WriteLine("No modified matrix available.");
            return;
        }

        foreach (var row in modifiedMatrix)
        {
            Console.WriteLine(string.Join(", ", row));
        }
    }
}