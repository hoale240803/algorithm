
public class WordDictionary
{
    private TrieNode _root;
    public WordDictionary()
    {
        _root = new TrieNode();
    }

    public void AddWord(string word)
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
        return Dfs(word, 0, _root);
    }

    private bool Dfs(string word, int j, TrieNode root)
    {
        TrieNode currentNode = root;

        for (int i = j; i < word.Length; i++)
        {
            char c = word[i];

            if (c == '.')
            {
                foreach (TrieNode child in currentNode.Children)
                {
                    if (child != null && Dfs(word, i + 1, child))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                int index = c - 'a';
                if (currentNode.Children[index] == null)
                {
                    return false;
                }
                currentNode = currentNode.Children[index];
            }
        }

        return currentNode.IsEndOfWord; // Check if we reached the end of a valid word
    }
}

public class TrieNode
{
    public TrieNode[] Children = new TrieNode[26];
    public bool IsEndOfWord = false;
}
