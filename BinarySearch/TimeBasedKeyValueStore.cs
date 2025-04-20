namespace Algorithm.BinarySearch
{
    public class TimeMap
    {

        // Time Based Key-Value Store
        // Implement a time-based key-value data structure that supports:

        // Storing multiple values for the same key at specified time stamps
        // Retrieving the key's value at a specified timestamp
        // Implement the TimeMap class:

        // TimeMap() Initializes the object.
        // void set(String key, String value, int timestamp) Stores the key key with the value value at the given time timestamp.
        // String get(String key, int timestamp) Returns the most recent value of key if set was previously called on it and the most recent timestamp for that key prev_timestamp is less than or equal to the given timestamp (prev_timestamp <= timestamp). If there are no values, it returns "".
        // Note: For all calls to set, the timestamps are in strictly increasing order.

        // Example 1:

        // Input:
        // ["TimeMap", "set", ["alice", "happy", 1], "get", ["alice", 1], "get", ["alice", 2], "set", ["alice", "sad", 3], "get", ["alice", 3]]

        // Output:
        // [null, null, "happy", "happy", null, "sad"]

        // Explanation:
        // TimeMap timeMap = new TimeMap();
        // timeMap.set("alice", "happy", 1);  // store the key "alice" and value "happy" along with timestamp = 1.
        // timeMap.get("alice", 1);           // return "happy"
        // timeMap.get("alice", 2);           // return "happy", there is no value stored for timestamp 2, thus we return the value at timestamp 1.
        // timeMap.set("alice", "sad", 3);    // store the key "alice" and value "sad" along with timestamp = 3.
        // timeMap.get("alice", 3);           // return "sad"


        public TimeMap()
        {
            TimeMapDictionary = new Dictionary<string, List<TimeMapModel>>();
        }

        // define a model with key, value, timestamp
        public class TimeMapModel
        {
            public string Key { get; set; }
            public string Value { get; set; }
            public int Timestamp { get; set; }
        }

        // set a dictionary with key as key and value as list of TimeMapModel
        public Dictionary<string, List<TimeMapModel>> TimeMapDictionary { get; set; }

        // implement set method
        public void Set(string key, string value, int timestamp)
        {
            if (!TimeMapDictionary.ContainsKey(key))
            {
                TimeMapDictionary[key] = new List<TimeMapModel>();
            }

            TimeMapDictionary[key].Add(new TimeMapModel { Key = key, Value = value, Timestamp = timestamp });
        }


        // implement get method
        public string Get(string key, int timestamp)
        {
            if (!TimeMapDictionary.ContainsKey(key))
            {
                return string.Empty;
            }

            var values = TimeMapDictionary[key];
            int left = 0;
            int right = values.Count - 1;
            string result = string.Empty;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (values[mid].Timestamp <= timestamp)
                {
                    result = values[mid].Value;
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return result;
        }
    }
}