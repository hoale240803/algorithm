
namespace algorithm.Candles
{
    public class Candle
    {
        public static int CalculateTotalBurnableCandle(int initialCandles, int leftoversPerCandle)
        {
            int totalCandlesBurned = 0;
            int candles = initialCandles;
            int leftovers = 0;

            while (candles > 0)
            {
                // Burn all available candles. Each burned candle produces 1 leftover.
                totalCandlesBurned += candles;
                leftovers += candles;

                // Create new candles from leftovers.
                candles = leftovers / leftoversPerCandle;
                leftovers = leftovers % leftoversPerCandle;
            }

            return totalCandlesBurned;
        }
    }
}