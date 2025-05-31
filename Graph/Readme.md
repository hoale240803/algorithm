# Problem Context

You are given a list of words (e.g., ["wrt", "wrf", "er", "ett", "rftt"]), which are sorted lexicographically according to an alien language's alphabet.
The goal is to derive the order of characters in the alien alphabet (e.g., "wertf").
If the words contain contradictions (e.g., a cycle in the character order or invalid word lengths), return an empty string ("").

# Algorithm Overview

The code constructs a directed graph where:

- Nodes are characters from the words.

- Edges represent the order between characters (e.g., if a must come before b in the alphabet, there is an edge from a to b).

- It then performs a topological sort to find a valid order of characters. If the sort is impossible (due to a cycle or incomplete graph), it returns an empty string.

# Code Breakdown

## 1. Initialize Data Structures

csharp

```
var adj = new Dictionary<char, HashSet<char>>();
var indegree = new Dictionary<char, int>();
foreach (var word in words) {
    foreach (var c in word) {
        if (!adj.ContainsKey(c)) {
            adj[c] = new HashSet<char>();
        }
        if (!indegree.ContainsKey(c)) {
            indegree[c] = 0;
        }
    }
}
```

Purpose: Build the graph's structure by initializing nodes (characters).

- adj: A dictionary where the key is a character, and the value is a HashSet<char> representing the characters that must come after the key in the alphabet (outgoing edges).
- indegree: A dictionary tracking the number of incoming edges for each character (i.e., how many characters must come before it).
- Loop: For each word in the input array, iterate through its characters and ensure they are added to both adj and indegree if not already present.
  Example:
  For words = ["wrt", "wrf", "er"]:

Characters: w, r, t, f, e.
adj: {w: {}, r: {}, t: {}, f: {}, e: {}}.

indegree: {w: 0, r: 0, t: 0, f: 0, e: 0}.

## 2. Build the Graph

```
for (int i = 0; i < words.Length - 1; i++) {
    var w1 = words[i];
    var w2 = words[i + 1];
    int minLen = Math.Min(w1.Length, w2.Length);
    if (w1.Length > w2.Length &&
        w1.Substring(0, minLen) == w2.Substring(0, minLen)) {
        return "";
    }
    for (int j = 0; j < minLen; j++) {
        if (w1[j] != w2[j]) {
            if (!adj[w1[j]].Contains(w2[j])) {
                adj[w1[j]].Add(w2[j]);
                indegree[w2[j]]++;
            }
            break;
        }
    }
}
```

Purpose: Compare adjacent words to infer character order and build edges in the graph.

Outer Loop: Iterates through pairs of consecutive words (w1, w2) because the words are sorted, so w1 comes before w2 in the alien dictionary.

Invalid Case Check:
If w1 is longer than w2 and they share the same prefix up to w2's length (e.g., w1 = "wrt", w2 = "wr"), this is invalid because a longer word cannot come before a shorter word with the same prefix in a valid lexicographical order. Return "".

Inner Loop: Compare characters of w1 and w2 at the same position (j).
When a mismatch is found (w1[j] != w2[j]), it means w1[j] must come before w2[j] in the alphabet.
Add an edge from w1[j] to w2[j] in adj (if not already present) and increment indegree[w2[j]].
Break after the first mismatch, as subsequent characters don’t provide additional order information.

Example:
For words = ["wrt", "wrf"]:

Compare wrt and wrf:
w == w, r == r, t != f.
Infer: t comes before f.
Update: adj[t].Add(f), indegree[f]++.
Result: adj = {w: {}, r: {}, t: {f}, f: {}, e: {}}, indegree = {w: 0, r: 0, t: 0, f: 1, e: 0}.

## 3. Topological Sort

```
var q = new Queue<char>();
foreach (var c in indegree.Keys) {
    if (indegree[c] == 0) {
        q.Enqueue(c);
    }
}
var res = new StringBuilder();
while (q.Count > 0) {
    var char_ = q.Dequeue();
    res.Append(char_);
    foreach (var neighbor in adj[char_]) {
        indegree[neighbor]--;
        if (indegree[neighbor] == 0) {
            q.Enqueue(neighbor);
        }
    }
}
```

Purpose: Perform a topological sort to construct the character order.

Queue Initialization: Add all characters with indegree[c] == 0 (no dependencies) to a queue. These characters can start the alphabet.

Processing:
Dequeue a character (char*) and append it to the result (res).
For each neighbor (character that comes after char*), decrement its indegree.
If a neighbor’s indegree becomes 0, it has no remaining dependencies, so enqueue it.

Loop: Continue until the queue is empty.
Example:

Initial queue: w, r, t, e (all have indegree = 0).
Dequeue w, append to res = "w", no neighbors.
Dequeue r, append to res = "wr", no neighbors.
Dequeue t, append to res = "wrt", reduce indegree[f] to 0, enqueue f.
Dequeue e, append to res = "wrte", no neighbors.
Dequeue f, append to res = "wrtef", no neighbors. 4.

## 4. Validate and Return

```
if (res.Length != indegree.Count) {
    return "";
}
return res.ToString();
```

Purpose: Check for validity and return the result.
If res.Length != indegree.Count, not all characters were included in the topological sort, indicating a cycle in the graph (invalid order). Return "".
Otherwise, return the constructed alphabet as a string.

Example:

If res = "wrtef" and indegree.Count = 5, the order is valid.
Return "wrtef".

# How It Handles Edge Cases

Invalid Prefix:

If w1 = "wrt", w2 = "wr", the condition w1.Length > w2.Length && w1.Substring(0, minLen) == w2.Substring(0, minLen) triggers, returning "".

Cycle in Graph:

If there’s a cycle (e.g., a -> b -> c -> a), not all characters will be included in res, so res.Length != indegree.Count, returning "".

Empty or Single Word:

If words is empty or has one word, the graph may have no edges, and the result includes all characters in any order (or "" if empty).

# Example Walkthrough

Input: words = ["wrt", "wrf", "er", "ett", "rftt"]

## Graph Construction:

Compare wrt vs. wrf: t -> f.
Compare wrf vs. er: w -> e.
Compare er vs. ett: r -> t.
Compare ett vs. rftt: e -> r.

Resulting graph: adj = {w: {e}, r: {t}, t: {f}, f: {}, e: {r}}, indegree = {w: 0, r: 1, t: 1, f: 1, e: 1}.

## Topological Sort:

Start with w (indegree 0): res = "w", reduce indegree[e] to 0.
Add e: res = "we", reduce indegree[r] to 0.
Add r: res = "wer", reduce indegree[t] to 0.
Add t: res = "wert", reduce indegree[f] to 0.
Add f: res = "wertf".

Validation: res.Length == 5, indegree.Count == 5. Valid.

Output: "wertf".

# Time and Space Complexity

## Time Complexity: O(C + N), where:

C is the total number of characters across all words (for initializing the graph).

N is the number of words (for comparing adjacent words).

Topological sort is O(V + E), where V is the number of unique characters (≤ 26 for lowercase letters), and E is the number of edges (≤ number of comparisons).

## Space Complexity: O(V + E) for the adjacency list (adj) and indegree, plus O(V) for the queue and result string.

# Summary

The code:

- Builds a directed graph by comparing adjacent words to infer character order.
- Uses topological sort to construct a valid alphabet order.
- Returns an empty string if the order is invalid (due to cycles or prefix issues).
- Returns the alphabet as a string if valid.

This is a robust solution for the Alien Dictionary problem, handling all edge cases efficiently.
