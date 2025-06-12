namespace algorithm.Intervals;

public class InsertInterval
{
    // Linear search
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        var result = new List<int[]>();

        for (var i = 0; i < intervals.Length - 1; i++)
        {
            if (newInterval[1] < intervals[i][0])
            {
                result.Add(newInterval);
                result.AddRange(intervals.AsEnumerable().Skip(i).ToArray());

                return result.ToArray();
            }
            else if (newInterval[0] > intervals[i][1])
            {
                result.Add(intervals[i]);
            }
            else
            {
                newInterval[0] = Math.Min(intervals[i][0], newInterval[0]);
                newInterval[1] = Math.Max(intervals[i][1], newInterval[1]);
            }
        }

        result.Add(newInterval);

        return result.ToArray();
    }

    // Binary search
    public int[][] Insert2(int[][] intervals, int[] newInterval)
    {
        if (intervals.Length == 0)
        {
            return new int[][] { newInterval };
        }

        int n = intervals.Length;
        int target = newInterval[0];
        int left = 0, right = n - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (intervals[mid][0] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        List<int[]> result = new List<int[]>();
        for (int i = 0; i < left; i++)
        {
            result.Add(intervals[i]);
        }

        result.Add(newInterval);
        for (int i = left; i < n; i++)
        {
            result.Add(intervals[i]);
        }

        List<int[]> merged = new List<int[]>();
        foreach (var interval in result)
        {
            if (merged.Count == 0
            || merged[merged.Count - 1][1] < interval[0])
            {
                merged.Add(interval);
            }
            else
            {
                merged[merged.Count - 1][1] =
                Math.Max(merged[merged.Count - 1][1], interval[1]);
            }
        }

        return merged.ToArray();
    }

}