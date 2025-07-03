using algorithm.MathAndGeography;

SetMatrixZeroes setMatrixZeroes = new SetMatrixZeroes();
setMatrixZeroes.SetZeroes2(new int[][]
{
    new int[] { 1, 1, 1 },
    new int[] { 1, 0, 1 },
    new int[] { 1, 1, 1 }
});

// print the modified matrix
Console.WriteLine("Modified Matrix:");
setMatrixZeroes.PrintModifiedMatrix();
