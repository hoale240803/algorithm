
using algorithm.Backtracking;
using algorithm.MathAndGeography;

RotateImage rotateImage = new RotateImage();
int[][] matrix = new int[][]
{
    new int[] { 1, 2, 3 },
    new int[] { 4, 5, 6 },
    new int[] { 7, 8, 9 }
};

rotateImage.Rotate1(matrix);
foreach (var row in matrix)
{
    Console.WriteLine(string.Join(", ", row));
}
