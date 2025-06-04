# Summary problem

- Cho một grid 2-d các ký tự `board` và list các `words`. Trả về tất cả các từ mà hiện diện trong grid.

- Với mỗi từ hiện diện có thể là một dạng của đường hàng ngang, hàng dọc liền kề. Một ô không thê hiện diện quá hai trong một từ.

# Interview Preparation

## How to Explain in an Interview

**1. Start with the Problem (1-2 sentences)**

"I’m solving the Word Search II problem, where we’re given a 2D grid of letters and a list of words. The goal is to find all words that can be formed by connecting adjacent letters—up, down, left, or right—without reusing cells in a single word."

Tip: Keep it short and clear. Show you understand the problem without diving into unnecessary details.

**2. Explain the High-Level Idea (Big Picture)**

"To solve this, I’ll use two main tools: a Trie to store the words efficiently and a Depth-First Search (DFS) to explore the grid. The Trie helps us quickly check if a sequence of letters is a valid word or prefix, and DFS lets us try all possible paths on the grid to build those words."

Tip: Use an analogy if it helps, e.g., “Think of the Trie as a dictionary where we can look up letters step-by-step, and DFS as exploring a maze to find valid words.”

**3. Break Down the Steps**

Walk through the algorithm in simple steps, using a conversational tone. Here’s how you can structure it:

Step 1: Build a Trie for the Words

- "First, I store all the words in a Trie, which is like a tree where each node represents a letter. If I follow a path from the root to a node, it forms a prefix or a full word."
- "For example, if we have words like `cat` and `car`, the Trie has a branch for `c-a-t` and `c-a-r`, with a flag at the end to mark complete words."
- "This makes it fast to check if a sequence of letters is valid as we search the grid."

Step 2: Explore the Grid with DFS

- "Next, I start at every cell on the grid and use DFS to explore paths. From each cell, I try moving up, down, left, or right to build a word."
- "As I pick letters, I check the Trie to see if they form a valid prefix. If not, I stop early to save time."
- "If I reach a node in the Trie that marks a complete word, I add that word to the result."

Step 3: Track Visited Cells

- "To avoid reusing a cell in the same word, I use a boolean grid to mark cells as visited."
- "After exploring a path, I unmark the cell—this is called backtracking—so it can be used in other words."

Step 4: Collect Unique Words

- "I store found words in a set to avoid duplicates, then return them as a list."

Tip: Use simple language and avoid jargon unless prompted. For example, say “tree” instead of “prefix tree” if the interviewer seems unfamiliar with Tries.

**4. Use a Quick Example**

Illustrate with a small example to make it concrete:
"Let’s say the board is:

```
[o, a]
[e, t]
```

And the words are `["oat", "eat"]`

- I build a Trie with `oat` and `eat`.

- Start at `o` (top-left). Check the Trie: `o` is valid. Move to `a` (right), then `t` (down). That forms `oat`, `a` valid word, so I add it.

- Start at `e` (bottom-left). Move to `t` (right). That forms `eat`, another valid word.

- The visited grid ensures I don’t reuse cells in one path, but I unmark them afterward to try other paths.

- Output: `["oat", "eat"]."`

Tip: Draw the board and a simple Trie on a whiteboard (or describe it clearly if virtual). Keep it small to avoid wasting time.

**5. Highlight Why This Approach**

- "The Trie is key because it lets us quickly check if a path is worth exploring. Without it, we’d have to compare every path to every word, which is slow."

- "DFS ensures we try all possible paths, and backtracking lets us reuse cells for different words."

- "Using a set avoids duplicate words in the output."

Tip: Emphasize efficiency to show you understand the problem’s challenges. For example, “The Trie saves time by cutting off invalid paths early.”

**6. Mention Complexity (Briefly)**

- "Time complexity is roughly O(rows _ cols _ 4^max_word_length) because we start DFS from each cell and explore up to four directions for each letter in a word."

- "Space complexity is O(total_word_length) for the Trie plus O(rows \* cols) for the visited grid and recursion stack."
  Tip: Only dive into complexity if asked, but have it ready. Keep it high-level unless the interviewer wants details.

**7. Sound Confident and Collaborative**

- Use phrases like “I think this approach works because…” or “Does that make sense so far?” to engage the interviewer.
- If you’re unsure about something, say, “I’d double-check this in a real implementation, but my thinking is…”
- If the interviewer asks for optimizations, mention pruning the Trie (removing used words) or limiting DFS depth, but only if prompted.

**Sample Interview Explanation (Putting It All Together)**

“Let me explain how I’d solve the Word Search II problem. We’re given a grid of letters and a list of words, and we need to find all words that can be formed by connecting adjacent letters—up, down, left, or right—without reusing cells in a single word.

My approach uses a Trie to store the words and DFS to search the grid.

Here’s how it works:

- **Build a Trie**: I put all the words into a tree-like structure called a Trie. Each node is a letter, and a path from the root can form a word or part of one. For example, for words cat and car, the Trie has a c node, then branches to a-t and a-r. This helps us check valid words quickly.
- **Search with DFS**: I start at every cell on the grid. From each cell, I use DFS to try moving in four directions to build a word. As I pick letters, I follow the Trie to ensure they form a valid prefix. If I hit a dead end, like a letter not in the Trie, I stop early. If I reach a full word, I add it to a result set.

- **Track Visited Cells**: I use a boolean grid to mark cells I’ve visited in the current path, so I don’t reuse them in one word. After exploring a path, I unmark the cell to allow it in other words—this is backtracking.

- **Collect Results**: I use a set to store unique words and convert it to a list at the end.

For example, if the board is:

```
[o, a]
[e, t]
```

And words are `["oat", "eat"]`, I’d start at `o`, move to `a`, then `t` to find `oat`, and start at `e`, move to `t` to find `eat`. The Trie ensures I only follow valid paths.

This approach is efficient because the Trie prunes invalid paths, and DFS explores all possibilities. The time complexity is roughly O(rows _ cols _ 4^max_word_length), and space is O(word_length) for the Trie plus O(rows \* cols) for the visited grid.

Does that make sense? I can walk through the example in more detail if needed!”

**Tips for Success**

- **Practice the Explanation**: Rehearse this a few times so it flows naturally. Aim for 2-3 minutes max.

- **Use Visuals**: If you have a whiteboard, sketch the board and a small Trie. For virtual interviews, describe the example clearly.

- **Stay Calm**: If you forget a detail, say, “Let me clarify that part,” and move on.

- **Engage the Interviewer**: Ask, “Would you like me to explain the Trie more?” or “Should I dive into the code?” to show you’re open to feedback.

- **Handle Follow-Ups**: If asked about optimizations, suggest removing found words from the Trie or limiting DFS depth for long words.
