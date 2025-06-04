# Summary Problem

- Một cái prefix tree này là một kiểu dữ liệu cây, dùng cho việc lưu trữ và lấy ra các chìa khóa một tập các chuỗi. Một vài ứng dụng của kiểu dữ liệu này gồm auto-complete và hệ thống spell checker.

Thực hiện `PrefixTree` bao gồm:

- `PrefixTree()` để khởi tạo đối tượng prefix tree.
- `void insert(String word)` thêm string `word` vào trong prefix tree
- `boolean search(String word)` trả về `true` nếu string `word` là thành phần của prefix tree(ví dụ: đã được thêm vào cây trước đó). Và `false` nếu ngược lại.
- `boolean startWith(String prefix)` trả về `true` nếu `word` nào đã thêm vào trước đó tồn tại trong prefix tree. Vaf `false` nếu ngược lại.

```
Input:
["Trie", "insert", "dog", "search", "dog", "search", "do", "startsWith", "do", "insert", "do", "search", "do"]

Output:
[null, null, true, false, true, null, true]

Explanation:
PrefixTree prefixTree = new PrefixTree();
prefixTree.insert("dog");
prefixTree.search("dog");    // return true
prefixTree.search("do");     // return false
prefixTree.startsWith("do"); // return true
prefixTree.insert("do");
prefixTree.search("do");     // return true

```

# Solution
