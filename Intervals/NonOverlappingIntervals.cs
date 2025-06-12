namespace algorithm.Intervals;

public class NonOverlappingIntervals
{
    // Recursion
    public int EraseOverlapIntervals(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
        return intervals.Length - Dfs(intervals, 0, -1);
    }

    private int Dfs(int[][] intervals, int i, int prev)
    {
        if (i == intervals.Length) return 0;
        int res = Dfs(intervals, i + 1, prev);
        if (prev == -1 || intervals[prev][1] <= intervals[i][0])
        {
            res = Math.Max(res, 1 + Dfs(intervals, i + 1, i));
        }

        return res;
    }

    // Dynamic programming binarysearch
    public int EraseOverlapIntervals2(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) => a[1].CompareTo(b[1]));
        int n = intervals.Length;
        int[] dp = new int[n];
        dp[0] = 1;

        for (int i = 1; i < n; i++)
        {
            int index = BinarySearch(i, intervals[i][0], intervals);
            if (index == 0)
            {
                dp[i] = dp[i - 1];
            }
            else
            {
                dp[i] = Math.Max(dp[i - 1], 1 + dp[index - 1]);
            }
        }

        return n - dp[n - 1];
    }

    private int BinarySearch(int r, int target, int[][] intervals)
    {
        int l = 0;
        while (l < r)
        {
            int m = (l + r) >> 1;
            if (intervals[m][1] <= target)
            {
                l = m + 1;
            }
            else
            {
                r = m;
            }
        }

        return l;
    }

    //greedy

    public int EraseOverlapIntervals3(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
        int res = 0;
        int prevEnd = intervals[0][1];

        for (int i = 1; i < intervals.Length; i++)
        {
            int start = intervals[i][0];
            int end = intervals[i][1];
            if (start >= prevEnd)
            {
                prevEnd = end;
            }
            else
            {
                res++;
                prevEnd = Math.Min(end, prevEnd);
            }
        }

        return res;
    }

}
