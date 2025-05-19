
namespace algorithm.Candles
{
    public class Candle
    {
        public static int CalculateTotalBurnableCandleV1(int n, int k)
        {
            int totalCandles = 0;
            int candlesToBurn = n;
            int leftoverCarry = 0;

            while (candlesToBurn > 0)
            {
                int leftovers = BurnCandles(candlesToBurn);
                totalCandles += candlesToBurn;

                (candlesToBurn, leftoverCarry) = GenerateCandles(leftovers, k, leftoverCarry);
            }

            return totalCandles;
        }

        private static int BurnCandles(int candlesToBurn)
        {
            return candlesToBurn;
        }

        private static (int candles, int leftoverCarry) GenerateCandles(int leftovers, int k, int leftoverCarry)
        {
            int totalLeftovers = leftovers + leftoverCarry;
            int newCandles = totalLeftovers / k;
            int remainingLeftovers = totalLeftovers % k;

            return (newCandles, remainingLeftovers);
        }

        public static int CalculateTotalBurnableCandleV2(int n, int k)
        {
            int totalCandlesBurned = 0;
            int candles = n;
            int leftovers = 0;

            while (candles > 0)
            {
                // Burn all available candles
                totalCandlesBurned += candles;
                leftovers += candles; // Each burned candle produces 1 leftover

                // Create new candles from leftovers
                candles = leftovers / k; // Number of new candles
                leftovers = leftovers % k; // Remaining leftovers
            }

            return totalCandlesBurned;
        }
    }
}