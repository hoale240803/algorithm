namespace algorithm.ArrayAndHashing;

public class PlusOneClass
{
    public int[] PlusOne(int[] digits)
    {
        var res = new LinkedList<int>();
        var carry = 0;
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            var sum = 0;
            if (i == digits.Length - 1)
            {
                sum = digits[i] + 1;
            }
            else
            {

                sum = digits[i] + carry;
                if (carry > 0) carry--;
            }

            if (sum == 10)
            {
                carry++;
            }

            res.AddFirst(sum == 10 ? 0 : sum);
        }

        if (carry > 0)
        {
            res.AddFirst(1);
        }

        return res.ToArray();
    }
}