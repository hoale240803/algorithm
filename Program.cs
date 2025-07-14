using algorithm.Graph;

MaxAreaOfIslandClass maxAreaOfIsland = new MaxAreaOfIslandClass();

var grid = new int[][]
{
    [1, 1, 0, 0, 0],
    [1, 1, 0, 1, 1],
    [0, 0, 0, 0, 0],
    [0, 1, 1, 0, 1],
    [0, 0, 0, 1, 1]
};
int result = maxAreaOfIsland.MaxAreaOfIsland(grid);
// Output the result should be 4
Console.WriteLine($"The maximum area of an island is: {result}");


