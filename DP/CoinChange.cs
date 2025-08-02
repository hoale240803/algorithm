namespace algorithm.DP;

public class CodeChangeClass
{
    // recursion
    public int Dfs(int[] coins, int amount)
    {
        if (amount == 0) return 0;


        int res = (int)1e9;

        foreach (var coin in coins)
        {
            if (amount - coin >= 0)
            {
                res = Math.Min(res, 1 + Dfs(coins, amount - coin));
            }
        }

        return res;
    }

    public int CoinChange(int[] coins, int amount)
    {

        int minCoins = Dfs(coins, amount);
        return (minCoins >= 1e9 ? -1 : minCoins);
    }

    // Breadth first search

    public int CoinChange2(int[] coins, int amount)
    {
        if (amount == 0) return 0;

        Queue<int> q = new Queue<int>();
        q.Enqueue(0);

        bool[] seen = new bool[amount + 1];
        seen[0] = true;
        int res = 0;

        while (q.Count > 0)
        {
            res++;

            int size = q.Count;
            for (int i = 0; i < size; i++)
            {
                int cur = q.Dequeue();
                foreach (int coin in coins)
                {
                    int nxt = cur + coin;
                    if (nxt == amount) return res;
                    if (nxt > amount || seen[nxt]) continue;
                    seen[nxt] = true;
                    q.Enqueue(nxt);
                }
            }
        }

        return -1;
    }
}