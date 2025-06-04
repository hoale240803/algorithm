
namespace algorithm.Tries;

public class WordSearch
{
    private HashSet<string> res = new HashSet<string>();
    private bool[,] visited;
    public List<string> FindWords(char[][] board, string[] words)
    {
        TrieNode1 root = new TrieNode1();

        foreach (string word in words)
        {
            root.AddWord(word);
        }

        int rows = board.Length;
        int cols = board[0].Length;
        visited = new bool[rows, cols];

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                Dfs(board, r, c, root, "");
            }
        }

        return new List<string>(res);
    }

    private void Dfs(char[][] board, int r, int c, TrieNode1 node, string word)
    {
        int rows = board.Length;
        int cols = board[0].Length;
        if (r < 0 || r >= rows
        || c < 0 || c >= cols
        || visited[r, c]
        || !node.Children.ContainsKey(board[r][c]))
        {
            return;
        }

        visited[r, c] = true;
        node = node.Children[board[r][c]];
        word += board[r][c];
        if (node.IsEndOfWord)
        {
            res.Add(word);
        }

        Dfs(board, r + 1, c, node, word);
        Dfs(board, r - 1, c, node, word);
        Dfs(board, r, c + 1, node, word);
        Dfs(board, r, c - 1, node, word);

        visited[r, c] = false;
    }

    public void PrintResult(List<string> res)
    {
        Console.WriteLine("Found words:");
        foreach (string word in res)
        {
            Console.WriteLine(word);
        }
    }
}

public class TrieNode1
{
    public Dictionary<char, TrieNode1> Children = new Dictionary<char, TrieNode1>();
    public bool IsEndOfWord = false;

    public void AddWord(string word)
    {
        TrieNode1 currentNode = this;
        foreach (char c in word)
        {
            if (!currentNode.Children.ContainsKey(c))
            {
                currentNode.Children[c] = new TrieNode1();
            }
            currentNode = currentNode.Children[c];
        }
        currentNode.IsEndOfWord = true;
    }
}