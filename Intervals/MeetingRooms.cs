namespace algorithm.Intervals;

public class MeetingRooms
{
    public bool CanAttendMeetings(List<Interval> intervals)
    {
        intervals.Sort((a, b) => a.start.CompareTo(b.start));

        for (int i = 1; i < intervals.Count; i++)
        {
            Interval a = intervals[i - 1];
            Interval b = intervals[i];

            if (a.end > b.start)
            {
                return false;
            }
        }

        return true;
    }
}