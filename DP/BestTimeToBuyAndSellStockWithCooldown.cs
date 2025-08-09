
namespace algorithm.DP;

public class BestTimeToBuyAndSellStockWithCooldown
{
    public int MaxProfit(int[] prices)
    {
        return Dfs(0, true, prices);
    }

    private int Dfs(int i, bool buying, int[] prices)
    {
        if (i >= prices.Length)
        {
            return 0;
        }

        int coolDown = Dfs(i + 1, buying, prices);

        if (buying)
        {
            int buy = Dfs(i + 1, false, prices) - prices[i];
            return Math.Max(buy, coolDown);
        }
        else
        {
            int sell = Dfs(i + 2, true, prices) + prices[i];
            return Math.Max(sell, coolDown);
        }
    }
}