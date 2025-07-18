using algorithm.Graph;

RottingFruit rottingFruit = new RottingFruit();

int[][] grid = new int[][]
{
    new int[] { 2, 1, 1 },
    new int[] { 1, 1, 0 },
    new int[] { 0, 1, 1 }
};

int result = rottingFruit.OrangesRotting(grid);
Console.WriteLine(result); // Output: 4





