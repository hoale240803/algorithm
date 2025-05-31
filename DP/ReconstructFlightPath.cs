using System.Text;

namespace algorithm.DP;


public class ReconstructionFlightPath
{
    // Depth first search
    public List<string> FindItinerary(List<List<string>> tickets)
    {
        var adj = new Dictionary<string, List<string>>();
        foreach (var ticket in tickets)
        {
            if (!adj.ContainsKey(ticket[0]))
            {
                adj[ticket[0]] = new List<string>();
            }
        }

        tickets.Sort((a, b) => string.Compare(a[1], b[1]));

        foreach (var ticket in tickets)
        {
            adj[ticket[0]].Add(ticket[1]);
        }

        var res = new List<string> { "JFK" };

        Dfs("JFK", res, adj, tickets.Count + 1);

        return res;
    }

    private bool Dfs(string src, List<string> res, Dictionary<string, List<string>> adj, int targetLen)
    {
        if (res.Count == targetLen) return true;

        if (!adj.ContainsKey(src)) return false;

        var temp = new List<string>(adj[src]);
        for (int i = 0; i < temp.Count; i++)
        {
            var v = temp[i];
            adj[src].RemoveAt(i);
            res.Add(v);
            if (Dfs(v, res, adj, targetLen)) return true;
            res.RemoveAt(res.Count - 1);
            adj[src].Insert(i, v);
        }
        return false;
    }

    // Hierholzer's algorithm recursion

    // Hierholzer's algorithm iteration

    private Dictionary<string, List<string>> adj;
    private List<string> res = new List<string>();


    public List<string> FindItinerary2(List<List<string>> tickets)
    {
        adj = new Dictionary<string, List<string>>();

        var sortedtickets = tickets.OrderByDescending(t => t[1]).ToList();

        foreach (var ticket in tickets)
        {
            if (!adj.ContainsKey(ticket[0]))
            {
                adj[ticket[0]] = new List<string>();
            }
            adj[ticket[0]].Add(ticket[1]);
        }


        Dfs2("JFK");
        res.Reverse();

        return res;
    }

    private void Dfs2(string src)
    {
        while (adj.ContainsKey(src) && adj[src].Count > 0)
        {
            var destination = adj[src][adj[src].Count - 1];
            adj[src].RemoveAt(adj[src].Count - 1);
            Dfs2(destination);
        }
        res.Add(src);
    }

    public List<string> FindItinerary3(List<List<string>> tickets)
    {
        var adj = new Dictionary<string, List<string>>();
        foreach (var ticket in tickets.OrderByDescending(t => t[1]))
        {
            if (!adj.ContainsKey(ticket[0]))
            {
                adj[ticket[0]] = new List<string>();
            }
            adj[ticket[0]].Add(ticket[1]);
        }

        var res = new List<string>();
        var stack = new Stack<string>();
        stack.Push("JFK");

        while (stack.Count > 0)
        {
            var curr = stack.Peek();
            if (!adj.ContainsKey(curr) || adj[curr].Count == 0)
            {
                res.Insert(0, stack.Pop());
            }
            else
            {
                var next = adj[curr][adj[curr].Count - 1];
                adj[curr].RemoveAt(adj[curr].Count - 1);
                stack.Push(next);
            }
        }

        return res;
    }

    public string ToString(List<string> path)
    {
        var res = new StringBuilder();
        foreach (var node in path)
        {
            res.Append($"{node} ");
        }

        return res.ToString();
    }
}