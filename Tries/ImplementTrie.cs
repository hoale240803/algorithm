
namespace algorithm.Tries;

public class PrefixTree
{
    private TrieNode _root;
    public PrefixTree()
    {
        _root = new TrieNode();
    }

    public void Insert(string word)
    {
        TrieNode currentNode = _root;

        foreach (var c in word)
        {
            int i = c - 'a';
            if (currentNode.Children[i] == null)
            {
                currentNode.Children[i] = new TrieNode();
            }
            currentNode = currentNode.Children[i];
        }

        currentNode.IsEndOfWord = true; // Mark the end of the word
    }

    public bool Search(string word)
    {
        TrieNode currentNode = _root;

        foreach (char c in word)
        {
            int i = c - 'a';
            if (currentNode.Children[i] == null)
            {
                return false;
            }
            currentNode = currentNode.Children[i];
        }

        return currentNode.IsEndOfWord; // Check if we reached the end of a valid word
    }

    public bool StartsWith(string prefix)
    {
        TrieNode currentNode = _root;

        foreach (char c in prefix)
        {
            int i = c - 'a';
            if (currentNode.Children[i] == null)
            {
                return false; // If any character in the prefix is not found, return false
            }
            currentNode = currentNode.Children[i];
        }

        return true;
    }

    public void Print()
    {
        Console.WriteLine("Trie contents:");
        PrintHelper(_root, "");
    }

    private void PrintHelper(TrieNode root, string v)
    {
        if (root.IsEndOfWord)
        {
            Console.WriteLine(v);
        }

        for (int i = 0; i < root.Children.Length; i++)
        {
            if (root.Children[i] != null)
            {
                char c = (char)(i + 'a');
                PrintHelper(root.Children[i], v + c);
            }
        }
    }
}

public class TrieNode
{
    public TrieNode[] Children = new TrieNode[26];
    public bool IsEndOfWord { get; set; }
}