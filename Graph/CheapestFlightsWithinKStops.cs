namespace algorithm.Graph;

public class CheapestFlightsWithinKStops
{
    // Bellman Ford algorithm
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
    {

        int[] prices = new int[n];
        Array.Fill(prices, int.MaxValue);
        prices[src] = 0;

        for (int i = 0; i <= k; i++)
        {
            int[] tmpPrices = (int[])prices.Clone();

            foreach (var flight in flights)
            {
                int s = flight[0];
                int d = flight[1];
                int p = flight[2];

                if (prices[s] == int.MaxValue)
                {
                    continue;
                }

                if (prices[s] + p < tmpPrices[d])
                {
                    tmpPrices[d] = prices[s] + p;
                }
            }

            prices = tmpPrices;
        }

        return prices[dst] == int.MaxValue ? -1 : prices[dst];
    }

    // shortest path faster algorithm

    public int FindCheapestPrice2(int n, int[][] flights, int src, int dst, int k)
    {
        int[] prices = new int[n];
        Array.Fill(prices, int.MaxValue);
        prices[src] = 0;
        List<int[]>[] adj = new List<int[]>[n];
        for (int i = 0; i < n; i++)
        {
            adj[i] = new List<int[]>();
        }

        foreach (var flight in flights)
        {
            adj[flight[0]].Add(new int[] { flight[1], flight[2] });
        }

        var q = new Queue<(int cst, int node, int stops)>();

        q.Enqueue((0, src, 0));

        while (q.Count > 0)
        {
            var (cst, node, stops) = q.Dequeue();

            if (stops > k) continue;
            foreach (var neighbor in adj[node])
            {
                int nei = neighbor[0], w = neighbor[1];
                int nextCost = cst + w;
                if (nextCost < prices[nei])
                {
                    prices[nei] = nextCost;
                    q.Enqueue((nextCost, nei, stops + 1));
                }
            }
        }

        return prices[dst] == int.MaxValue ? -1 : prices[dst];
    }

}