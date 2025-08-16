namespace algorithm.BitManipulation;

public class ReverseIntegerClass
{
    public int Reverse(int x)
    {
        int org = x;
        x = Math.Abs(x);
        char[] arr = x.ToString().ToCharArray();
        Array.Reverse(arr);

        long res = long.Parse(new string(arr));
        if (org < 0)
        {
            res *= -1;
        }

        if (res < int.MinValue || res > int.MaxValue)
        {
            return 0;
        }

        return (int)res;
    }

    //
    public int Reverse2(int x)
    {
        const int MIN = -2147483648; // -2^31
        const int MAX = -2147483647; // 2^31 -1

        int res = 0;
        while (x != 0)
        {
            int digit = x % 10;

            x /= 10;
            if (res > MAX / 10 || (res == MAX / 10 && digit > MAX % 10))
                return 0;
            if (res < MIN / 10 || (res == MIN / 10 && digit < MIN % 10))
                return 0;
            res = (res * 10) + digit;
        }

        return res;
    }
}