namespace algorithm.HeapPriorityQueue;

public class LeastIntervalHeap
{
    // Greedy
    public int LeastInterval(char[] tasks, int n)
    {
        int[] count = new int[26];

        foreach (char task in tasks)
        {
            count[task - 'A']++;
        }

        Array.Sort(count);
        int maxf = count[25];
        int idle = (maxf - 1) * n;

        for (int i = 24; i >= 0; i--)
        {
            idle -= Math.Min(maxf - 1, count[i]);
        }

        return Math.Max(0, idle) + tasks.Length;
    }

    // math

    public int LeastInterval1(char[] tasks, int n)
    {
        int[] count = new int[26];
        foreach (char task in tasks)
        {
            count[task - 'A']++;
        }

        int maxf = count.Max();
        int maxCount = 0;
        foreach (int i in count)
        {
            if (i == maxf)
            {
                maxCount++;
            }
        }

        int time = (maxf - 1) * (n + 1) + maxCount;
        return Math.Max(tasks.Length, time);
    }

    // max-heap
    public int LeastInterval2(char[] tasks, int n)
    {
        int[] count = new int[26];
        foreach (var task in tasks)
        {
            count[task - 'A']++;
        }

        var maxHeap = new PriorityQueue<int, int>();
        for (int i = 0; i < 26; i++)
        {
            if (count[i] > 0)
            {
                maxHeap.Enqueue(count[i], -count[i]);
            }
        }


        int time = 0;
        Queue<int[]> queue = new Queue<int[]>();
        while (maxHeap.Count > 0 || queue.Count > 0)
        {
            if (queue.Count > 0 && time >= queue.Peek()[1])
            {
                int[] temp = queue.Dequeue();
                maxHeap.Enqueue(temp[0], -temp[0]);
            }
            if (maxHeap.Count > 0)
            {
                int cnt = maxHeap.Dequeue() - 1;
                if (cnt > 0)
                {
                    queue.Enqueue(new int[] { cnt, time + n + 1 });
                }
            }
            time++;
        }
        return time;
    }
}