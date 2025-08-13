
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

    // Dynamic Programming (space optimized)

    public int MaxProfit2(int[] prices)
    {
        int n = prices.Length;
        int dp1_buy = 0, dp1_sell = 0;
        int dp2_buy = 0;


        for (int i = n - 1; i >= 0; i--)
        {
            int dp_buy = Math.Max(dp1_sell - prices[i], dp1_buy);
            int dp_sell = Math.Max(dp2_buy + prices[i], dp1_sell);

            dp2_buy = dp1_buy;
            dp1_buy = dp_buy;
            dp1_sell = dp_sell;
        }

        return dp1_buy;
    }
}