namespace Algorithm.BinarySearch;

public class KokoEatingBanana
{
    public int MinEatingSpeed(int[] piles, int h)
    {

        // You are given an integer array piles where piles[i] is the number of bananas in the ith pile. You are also given an integer h, which represents the number of hours you have to eat all the bananas.

        // You may decide your bananas-per-hour eating rate of k. Each hour, you may choose a pile of bananas and eats k bananas from that pile. If the pile has less than k bananas, you may finish eating the pile but you can not eat from another pile in the same hour.

        // Return the minimum integer k such that you can eat all the bananas within h hours.

        // Example 1:

        // Input: piles = [1,4,3,2], h = 9

        // apply binary search to find the minimum k

        // left is 1, right is max(piles)

        // mid is (left + right) / 2

        // if mid is the answer, return mid

        // if mid is not the answer, move left or right

        // return left as the answer

        int left = 1;
        int right = piles.Max();

        while (left < right)
        {
            int mid = (left + right) / 2;
            if (CanEatAllBananas(piles, mid, h))
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }

        return left;
    }

    private bool CanEatAllBananas(int[] piles, int k, int h)
    {
        int hours = 0;
        foreach (var pile in piles)
        {
            hours += (int)Math.Ceiling((double)pile / k);
        }
        return hours <= h;
    }
}

