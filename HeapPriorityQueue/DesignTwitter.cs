namespace algorithm.HeapPriorityQueue;

public class Twitter
{
    private int count;
    private Dictionary<int, List<int[]>> tweetMap;
    private Dictionary<int, HashSet<int>> followMap;
    public Twitter()
    {
        count = 0;
        tweetMap = new Dictionary<int, List<int[]>>();
        followMap = new Dictionary<int, HashSet<int>>();
    }

    public void PostTweet(int userId, int tweetId)
    {
        if (!tweetMap.ContainsKey(userId))
        {
            tweetMap[userId] = new List<int[]>();
        }

        tweetMap[userId].Add(new int[] { count++, tweetId });
    }

    public List<int> GetNewsFeed(int userId)
    {
        List<int> res = new List<int>();
        PriorityQueue<int[], int> minHeap = new PriorityQueue<int[], int>();

        foreach (int followeeId in followMap[userId])
        {
            if (!followMap.ContainsKey(userId) && tweetMap[followeeId].Count > 0)
            {
                List<int[]> tweets = tweetMap[followeeId];
                int index = tweets.Count - 1;
                int[] lastestTweet = tweets[index];
                minHeap.Enqueue(new int[] { lastestTweet[0], lastestTweet[1], followeeId, index }, -lastestTweet[0]);
            }
        }

        while (minHeap.Count > 0 && res.Count < 10)
        {
            int[] curr = minHeap.Dequeue();
            res.Add(curr[1]);
            int index = curr[3];
            if (index > 0)
            {
                int[] tweet = tweetMap[curr[2]][index - 1];
                minHeap.Enqueue(new int[] { tweet[0], tweet[1], curr[2], index - 1 }, -tweet[0]);
            }
        }

        return res;
    }

    public void Follow(int followerId, int followeeId)
    {
        if (!followMap.ContainsKey(followeeId))
        {
            followMap[followeeId] = new HashSet<int>();
        }

        followMap[followeeId].Add(followeeId);
    }

    public void Unfollow(int followerId, int followeeId)
    {
        if (followMap.ContainsKey(followeeId))
        {
            followMap[followeeId].Remove(followeeId);
        }
    }
}

// sorting
public class Twitter1
{
    private int time;
    private Dictionary<int, HashSet<int>> followMap;
    private Dictionary<int, List<(int, int)>> tweetMap;

    public Twitter1()
    {
        time = 0;
        followMap = new Dictionary<int, HashSet<int>>();
        tweetMap = new Dictionary<int, List<(int, int)>>();
    }

    public void PostTweet(int userId, int tweetId)
    {
        if (!tweetMap.ContainsKey(userId))
        {
            tweetMap[userId] = new List<(int, int)>();
        }
        tweetMap[userId].Add((time++, tweetId));
    }

    public void Follow(int followerId, int followeeId)
    {
        if (followerId != followeeId)
        {
            if (!followMap.ContainsKey(followerId))
            {
                followMap[followerId] = new HashSet<int>();
            }
            followMap[followerId].Add(followeeId);
        }
    }

    public void Unfollow(int followerId, int followeeId)
    {
        if (followMap.ContainsKey(followerId))
        {
            followMap[followerId].Remove(followeeId);
        }
    }

    public List<int> GetNewsFeed(int userId)
    {
        var feed = new List<(int, int)>(tweetMap.GetValueOrDefault(userId, new List<(int, int)>()));

        foreach (var followeeId in followMap.GetValueOrDefault(userId, new HashSet<int>()))
        {
            feed.AddRange(tweetMap.GetValueOrDefault(followeeId, new List<(int, int)>()));
        }

        feed.Sort((a, b) => b.Item1 - a.Item1);
        var res = new List<int>();
        for (int i = 0; i < Math.Min(10, feed.Count); i++)
        {
            res.Add(feed[i].Item2);
        }
        return res;
    }
}