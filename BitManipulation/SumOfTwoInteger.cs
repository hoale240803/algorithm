
namespace Algorithm.BitManipulation;

public class SumOfTwoInteger
{
    public static int GetSum(int a, int b)
    {
        while (b != 0)
        {
            int carry = a & b;
            a = a ^ b; // Sum without carry
            b = carry << 1; // Carry shifted left;
        }

        return a;
    }
}