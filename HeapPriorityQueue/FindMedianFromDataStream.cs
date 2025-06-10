namespace algorithm.HeapPriorityQueue;

public class MedianFinder
{
    // sorting
    private List<int> data;

    public MedianFinder()
    {
        data = new List<int>();
    }

    public void AddNum(int num)
    {
        data.Add(num);
    }

    public double FindMedian()
    {
        data.Sort();
        int n = data.Count;
        if ((n & 1) == 1)
        {
            return data[n / 2];
        }
        else
        {
            return (data[n / 2] + data[n / 2 - 1]) / 2.0;
        }
    }
}

public class MedianFinder1
{
    private PriorityQueue<int, int> small;
    private PriorityQueue<int, int> large;

    public MedianFinder1()
    {
        small = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        large = new PriorityQueue<int, int>();
    }

    public void AddNum(int num)
    {
        if (large.Count != 0 && num > large.Peek())
        {
            large.Enqueue(num, num);
        }
        else
        {
            small.Enqueue(num, num);
        }

        if (small.Count > large.Count + 1)
        {
            int val = small.Dequeue();
            large.Enqueue(val, val);
        }
        else if (large.Count > small.Count + 1)
        {
            int val = large.Dequeue();
            small.Enqueue(val, val);
        }
    }

    public double FindMedian()
    {
        if (small.Count > large.Count)
        {
            return small.Peek();
        }
        else if (large.Count > small.Count)
        {
            return large.Peek();
        }

        int smallTop = small.Peek();
        return (smallTop + large.Peek()) / 2.0;
    }
}

