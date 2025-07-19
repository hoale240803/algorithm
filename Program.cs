using algorithm.Graph;


PacificAtlanticWater pacificAtlanticWater = new PacificAtlanticWater();

int[][] heights = new int[][]
{
    new int[] { 4,2,7,3,4 },
    new int[] { 7,4,6,4,7 },
    new int[] { 6,3,5,3,6 },
};
List<List<int>> result = pacificAtlanticWater.PacificAtlantic(heights);


foreach (var res in result)
{
    Console.WriteLine($"[{res[0]}, {res[1]}]");
}





