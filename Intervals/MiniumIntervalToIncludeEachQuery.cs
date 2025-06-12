namespace algorithm.Intervals;

public class MiniumInternalToIncludeEachQuery
{
    public int[] MinInterval(int[][] intervals, int[] queries)
    {
        int[] res = new int[queries.Length];
        int index = 0;
        foreach (var q in queries)
        {
            int cur = -1;
            foreach (var interval in intervals)
            {
                int l = interval[0], r = interval[1];
                if (l <= q && q <= r)
                {
                    if (cur == -1 || (r - l + 1) < cur)
                    {
                        cur = r - l + 1;
                    }
                }
            }

            res[index++] = cur;
        }

        return res;
    }


}