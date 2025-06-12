namespace algorithm.Intervals;

public class MeetingRoomII
{
    // Min heap
    public int MinMeetingRooms(List<Interval> intervals)
    {
        intervals.Sort((a, b) => a.start.CompareTo(b.start));
        var minHeap = new PriorityQueue<int, int>();

        foreach (var interval in intervals)
        {
            if (minHeap.Count > 0 && minHeap.Peek() <= interval.start)
            {
                minHeap.Dequeue();
            }
            minHeap.Enqueue(interval.end, interval.end);
        }

        return minHeap.Count;
    }

    public int MinMeetingRooms2(List<Interval> intervals)
    {
        List<int[]> time = new List<int[]>();
        foreach (var i in intervals)
        {
            time.Add(new int[] { i.start, 1 });
            time.Add(new int[] { i.end, -1 });
        }

        time.Sort((a, b) => a[0] == b[0]
        ? a[1].CompareTo(b[1]) : a[0].CompareTo(b[0]));

        int res = 0, count = 0;

        foreach (var t in time)
        {
            count += t[1];
            res = Math.Max(res, count);
        }

        return res;
    }
}