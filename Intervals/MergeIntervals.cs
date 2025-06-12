namespace algorithm.Intervals;

public class MergeIntervals
{
    // Sorting
    public int[][] Merge(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        List<int[]> output = new List<int[]>();
        output.Add(intervals[0]);

        foreach (int[] interval in intervals)
        {
            int start = interval[0];
            int end = interval[1];

            int lastEnd = output[output.Count - 1][1];

            if (start <= lastEnd)
            {
                output[output.Count - 1][1] = Math.Max(lastEnd, end);
            }
            else
            {
                output.Add(new int[] { start, end });
            }
        }

        return output.ToArray();
    }

    // greedy

    public int[][] Merge2(int[][] intervals)
    {
        int max = 0;
        for (int i = 0; i < intervals.Length; i++)
        {
            max = Math.Max(intervals[i][0], max);
        }

        int[] mp = new int[max + 1];

        for (int i = 0; i < intervals.Length; i++)
        {
            int start = intervals[i][0];
            int end = intervals[i][1];
            mp[start] = Math.Max(end + 1, mp[start]);
        }

        var res = new List<int[]>();
        int have = -1;
        int intervalStart = -1;
        for (int i = 0; i < mp.Length; i++)
        {
            if (mp[i] != 0)
            {
                if (intervalStart == -1) intervalStart = i;
                have = Math.Max(mp[i] - 1, have);
            }

            if (have == i)
            {
                res.Add(new int[] { intervalStart, have });
                have = -1;
                intervalStart = -1;
            }
        }

        if (intervalStart != -1)
        {
            res.Add(new int[] { intervalStart, have });
        }

        return res.ToArray();
    }
}