namespace algorithm.MathAndGeography;

public class RotateImage
{
    // 1. Brute Force
    // Time: O(n^2), Space: O(1)
    public void Rotate(int[][] matrix)
    {
        int n = matrix.Length;
        int[][] rotated = new int[n][];
        for (int i = 0; i < n; i++)
        {
            rotated[i] = new int[n];
            for (int j = 0; j < n; j++)
            {
                rotated[i][j] = matrix[n - 1 - j][i];
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i][j] = rotated[i][j];
            }
        }
    }

    // 2. Reverse and Transpose
    public void Rotate1(int[][] matrix)
    {
        // Reverse the matrix vertically
        Array.Reverse(matrix);

        // Transpose the matrix
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = i; j < matrix[i].Length; j++)
            {
                (matrix[i][j], matrix[j][i]) = (matrix[j][i], matrix[i][j]);
            }
        }

    }
}