
namespace algorithm.Candles
{
    public class Candle
    {
        public static int CalculateTotalBurnableCandleV1(int initialCandles, int leftoversPerCandle)
        {
            int totalCandles = 0;
            int candlesToBurn = initialCandles;
            int leftoverCarry = 0;

            while (candlesToBurn > 0)
            {
                int leftovers = BurnCandles(candlesToBurn);
                totalCandles += candlesToBurn;

                (candlesToBurn, leftoverCarry) = GenerateCandles(leftovers, leftoversPerCandle, leftoverCarry);
            }

            return totalCandles;
        }

        private static int BurnCandles(int candlesToBurn)
        {
            return candlesToBurn;
        }

        private static (int candles, int leftoverCarry) GenerateCandles(int leftovers, int leftoversPerCandle, int leftoverCarry)
        {
            int totalLeftovers = leftovers + leftoverCarry;
            int newCandles = totalLeftovers / leftoversPerCandle;
            int remainingLeftovers = totalLeftovers % leftoversPerCandle;

            return (newCandles, remainingLeftovers);
        }

        public static int CalculateTotalBurnableCandleV2(int initialCandles, int leftoversPerCandle)
        {
            int totalCandlesBurned = 0;
            int candles = initialCandles;
            int leftovers = 0;

            while (candles > 0)
            {
                // Burn all available candles
                totalCandlesBurned += candles;
                leftovers += candles; // Each burned candle produces 1 leftover

                // Create new candles from leftovers
                candles = leftovers / leftoversPerCandle; // Number of new candles
                leftovers = leftovers % leftoversPerCandle; // Remaining leftovers
            }

            return totalCandlesBurned;
        }
    }
}