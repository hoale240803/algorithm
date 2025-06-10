namespace algorithm.Graph;

public class NetworkDelay
{
    // Depth first search
    public int NetworkDelayTime(int[][] times, int n, int k)
    {
        var adj = new Dictionary<int, List<int[]>>();
        foreach (var time in times)
        {
            if (!adj.ContainsKey(time[0]))
            {
                adj[time[0]] = new List<int[]>();
            }
            adj[time[0]].Add(new int[] { time[1], time[2] });
        }

        var dist = new Dictionary<int, int>();
        for (int i = 1; i <= n; i++) dist[i] = int.MaxValue;
        Dfs(k, 0, adj, dist);
        int res = dist.Values.Max();
        return res == int.MaxValue ? -1 : res;
    }

    private void Dfs(int node, int time, Dictionary<int, List<int[]>> adj, Dictionary<int, int> dist)
    {
        if (time >= dist[node]) return;
        dist[node] = time;
        if (!adj.ContainsKey(node)) return;
        foreach (var edge in adj[node])
        {
            Dfs(edge[0], time + edge[1], adj, dist);
        }
    }

    // Bellman Ford algorithm
    public int NetworkDelayTime1(int[][] times, int n, int k)
    {
        int[] dist = Enumerable.Repeat(int.MaxValue, n).ToArray();
        dist[k - 1] = 0;

        for (int i = 0; i < n - 1; i++)
        {
            foreach (var time in times)
            {
                int u = time[0] - 1, v = time[1] - 1, w = time[2];
                if (dist[u] != int.MaxValue && dist[u] + w < dist[v])
                {
                    dist[v] = dist[u] + w;
                }
            }
        }

        int maxDist = dist.Max();
        return maxDist == int.MaxValue ? -1 : maxDist;
    }

    // Dijkstra's algorithm

    public int NetworkDelayTime2(int[][] times, int n, int k)
    {
        var edges = new Dictionary<int, List<int[]>>();
        foreach (var time in times)
        {
            if (!edges.ContainsKey(time[0]))
            {
                edges[time[0]] = new List<int[]>();
            }
            edges[time[0]].Add(new int[] { time[1], time[2] });
        }

        var pq = new PriorityQueue<int, int>();
        pq.Enqueue(k, 0);

        var dist = new Dictionary<int, int>();

        for (int i = 1; i <= n; i++)
        {
            dist[i] = int.MaxValue;
        }

        dist[k] = 0;

        while (pq.Count > 0)
        {
            if (pq.TryDequeue(out int node, out int minDist))
            {
                if (minDist > dist[node])
                {
                    continue;
                }
                if (edges.ContainsKey(node))
                {
                    foreach (var edge in edges[node])
                    {
                        var next = edge[0];
                        var weight = edge[1];
                        var newDist = minDist + weight;

                        if (newDist < dist[next])
                        {
                            dist[next] = newDist;
                            pq.Enqueue(next, newDist);
                        }
                    }
                }
            }
        }

        int result = 0;

        for (int i = 1; i <= n; i++)
        {
            if (dist[i] == int.MaxValue) return -1;
            result = Math.Max(result, dist[i]);
        }

        return result;
    }
}