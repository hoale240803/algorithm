namespace algorithm.SlideWindow;

public class SlideWindowMaximum
{
    // brute force
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        int n = nums.Length;
        int[] output = new int[n - k + 1];

        for (int i = 0; i <= n - k; i++)
        {
            int maxi = nums[i];
            for (int j = i; j < i + k; j++)
            {
                maxi = Math.Max(maxi, nums[j]);
            }

            output[i] = maxi;
        }

        return output;
    }

    // heap
    public int[] MaxSlidingWindow2(int[] nums, int k)
    {
        PriorityQueue<(int val, int idx), int> pq =
        new PriorityQueue<(int val, int idx), int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

        int[] output = new int[nums.Length - k + 1];
        int idx = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            pq.Enqueue((nums[i], i), nums[i]);
            if (i >= k - 1)
            {
                while (pq.Peek().idx <= i - k)
                {
                    pq.Dequeue();
                }
                output[idx++] = pq.Peek().val;
            }
        }

        return output;
    }

    // dynamic

    public int[] MaxSlidingWindow3(int[] nums, int k)
    {
        int n = nums.Length;
        int[] leftMax = new int[n];
        int[] rightMax = new int[n];

        leftMax[0] = nums[0];
        rightMax[n - 1] = nums[n - 1];

        for (int i = 1; i < n; i++)
        {
            if (i % k == 0)
            {
                leftMax[i] = nums[i];
            }
            else
            {
                leftMax[i] = Math.Max(leftMax[i - 1], nums[i]);
            }

            if ((n - 1 - i) % k == 0)
            {
                rightMax[n - 1 - i] = nums[n - 1 - i];
            }
            else
            {
                rightMax[n - 1 - i] = Math.Max(rightMax[n - i], nums[n - 1 - i]);
            }
        }
        int[] output = new int[n - k + 1];
        for (int i = 0; i < n - k + 1; i++)
        {
            output[i] = Math.Max(leftMax[i + k - 1], rightMax[i]);
        }

        return output;
    }

    // dequeue

    public int[] MaxSlidingWindow4(int[] nums, int k)
    {
        int n = nums.Length;
        int[] output = new int[n - k + 1];

        var q = new LinkedList<int>();
        int l = 0, r = 0;

        while (r < n)
        {

            while (q.Count > 0 && nums[q.Last.Value] < nums[r])
            {
                q.RemoveLast();
            }

            q.AddLast(r);

            if (l > q.First.Value)
            {
                q.RemoveFirst();
            }

            if ((r + 1) >= k)
            {
                output[l] = nums[q.First.Value];
                l++;
            }

            r++;
        }

        return output;
    }
}