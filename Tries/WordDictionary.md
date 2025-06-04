# Summary problem

- Thiết kế ra một cấu trúc dữ liệu để hổ trở thêm mới một những từ và tìm kiếm các từ đã tồn tại.

Thực thi một `WordDictionary` class:

- `void addWord(word)` thêm `word` vào cấu trúc dữ liệu
- `bool search(word)` trả về `true` nếu kiểu chuỗi của cấu trúc dữ liệu khớp `word` hoặc `false` nếu ngược lại. `word` có thể chứa `.` nó có thể khớp với bất kì ký tự nào.

```
Input:
["WordDictionary", "addWord", "day", "addWord", "bay", "addWord", "may", "search", "say", "search", "day", "search", ".ay", "search", "b.."]

Output:
[null, null, null, null, false, true, true, true]

Explanation:
WordDictionary wordDictionary = new WordDictionary();
wordDictionary.addWord("day");
wordDictionary.addWord("bay");
wordDictionary.addWord("may");
wordDictionary.search("say"); // return false
wordDictionary.search("day"); // return true
wordDictionary.search(".ay"); // return true
wordDictionary.search("b.."); // return true

```
