using algorithm.Graph;


SurroundedRegions sr = new SurroundedRegions();

char[][] board = new char[][]
{
['X','X','X','X'],['X','O','O','X'],['X','O','O','X'],['X','X','X','O']
};
sr.Solve(board);
foreach (var row in board)
{
    Console.WriteLine(string.Join(" ", row));
}


