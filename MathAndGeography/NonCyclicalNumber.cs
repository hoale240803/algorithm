namespace algorithm.MathAndGeography;

public class NonCyclicalNumber
{
    // 1. Hash set
    public bool IsHappy(int n)
    {
        HashSet<int> visit = new HashSet<int>();

        while (!visit.Contains(n))
        {

            visit.Add(n);
            n = SumOfSquares(n);
            if (n == 1)
            {
                return true;
            }
        }

        return false;
    }

    private int SumOfSquares(int n)
    {
        int output = 0;

        while (n > 0)
        {
            int digit = n % 10;
            digit = digit * digit;
            output += digit;
            n /= 10;
        }

        return output;
    }

    // 2. Fast and slow pointer
    public bool IsHappy1(int n)
    {
        int slow = n, fast = SumOfSquares1(n);
        int power = 1, lam = 1;

        while (slow != fast)
        {
            if (power == lam)
            {
                slow = fast;
                power *= 2;
                lam = 0;
            }
            lam++;
            fast = SumOfSquares1(fast);
        }

        return fast == 1;
    }

    private int SumOfSquares1(int n)
    {
        int output = 0;
        while (n != 0)
        {
            output += (n % 10) * (n % 10);
            n /= 10;
        }
        return output;
    }
}