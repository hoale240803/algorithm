
using algorithm.Backtracking;

NQueen nQueen = new NQueen();
List<List<string>> result = nQueen.SolveNQueens(4);
foreach (var solution in result)
{
    foreach (var row in solution)
    {
        Console.WriteLine(row);
    }
    Console.WriteLine();
}
