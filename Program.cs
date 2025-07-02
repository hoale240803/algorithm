
using algorithm.Backtracking;
using algorithm.MathAndGeography;

SpiralMatrix spiralMatrix = new SpiralMatrix();
int[][] matrix = new int[][]
{
    new int[] { 1, 2, 3 },
    new int[] { 4, 5, 6 },
    new int[] { 7, 8, 9 }
};
List<int> result = spiralMatrix.SpiralOrder(matrix);
Console.WriteLine(string.Join(", ", result));