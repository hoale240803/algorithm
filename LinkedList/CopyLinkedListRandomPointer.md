# Summary problem

bạn có một node ở ví trí đầu tiên của một LinkedList n. Không giống như SingleLinkedList, mỗi nốt có chưa thêm `random` pointer, nó có thể trỏ tới bất kì nốt nào trong List hoặc `null`.

Tạo ra một deep copy của danh sách này. Deep copy nên có chứa chính xác `n` nốt mới, bao gồm:

- `val` giá trị gốc được sao chép
- `next` pointer trỏ tới nốt tương ứng với nốt gốc
- `random` pointer tới một node tương ứng với `random` con trỏ của nốt gốc

Chú ý: Không có con trỏ nào của list mới trỏ về list gốc.
ví dụ, LinkedList được trình bày như là một list `n` nốt. Mỗi nốt được thể hiện như là `[val, random_index]` ở đó `random_index` là chỉ mục của node (0-indexed) mà `random` con trỏ đó trỏ tới, hoặc `null` nếu nó không trỏ tới bất kì node nào.

```
Input: head = [[3,null],[7,3],[4,0],[5,1]]

Output: [[3,null],[7,3],[4,0],[5,1]]

```
