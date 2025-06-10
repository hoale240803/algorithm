namespace algorithm.Graph;


public class DSU
{
    // kruskal's algorithm

    public int[] Parent, Size;

    public DSU(int n)
    {
        Parent = new int[n + 1];
        Size = new int[n + 1];
        for (int i = 0; i <= n; i++) Parent[i] = i;
        Array.Fill(Size, 1);
    }

    public int Find(int node)
    {
        if (Parent[node] != node)
        {
            Parent[node] = Find(Parent[node]);
        }
        return Parent[node];
    }

    public bool Union(int u, int v)
    {
        int pu = Find(u), pv = Find(v);
        if (pu == pv) return false;
        if (Size[pu] < Size[pv])
        {
            int temp = pu;
            pu = pv;
            pv = temp;
        }
        Size[pu] += Size[pv];
        Parent[pv] = pu;
        return true;
    }
}
public class MinCostToConnectPoints
{



    public int MinCostConnectPoints(int[][] points)
    {
        int n = points.Length;
        DSU dsu = new DSU(n);

        List<(int, int, int)> edges = new List<(int, int, int)>();

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                int dist = Math.Abs(points[i][0] - points[j][0]) + Math.Abs(points[i][1] - points[j][1]);
                edges.Add((dist, i, j));
            }
        }

        edges.Sort((a, b) => a.Item1.CompareTo(b.Item1));
        int res = 0;
        foreach (var edge in edges)
        {
            if (dsu.Union(edge.Item2, edge.Item3))
            {
                res += edge.Item1;
            }
        }

        return res;
    }


    // Prim's algorithm

    public int MinCostConnectPoints2(int[][] points)
    {
        int n = points.Length, node = 0;
        int[] dist = new int[n];
        bool[] visit = new bool[n];
        Array.Fill(dist, 100000000);

        int edges = 0, res = 0;

        while (edges < n - 1)
        {
            visit[node] = true;
            int nextNode = -1;

            for (int i = 0; i < n; i++)
            {
                if (visit[i]) continue;
                int curDist = Math.Abs(points[i][0] - points[node][0])
                + Math.Abs(points[i][1] - points[node][1]);

                dist[i] = Math.Min(dist[i], curDist);

                if (nextNode == -1 || dist[i] < dist[nextNode])
                {
                    nextNode = i;
                }
            }

            res += dist[nextNode];
            node = nextNode;
            edges++;
        }

        return res;
    }
}