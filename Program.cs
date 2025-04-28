using Algorithm.BinarySearch;
using Algorithm.SlideWindow;
using Algorithm.LinkedList;
using LinkedList;


ReorderLinkedList reorderLinkedList = new ReorderLinkedList();
ListNode list1 = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
reorderLinkedList.ReorderList(list1);
list1.PrintList();


// 2 4 6 8 10
ReorderLinkedList reorderLinkedListV2 = new ReorderLinkedList();
ListNode list2 = new ListNode(2, new ListNode(4, new ListNode(6, new ListNode(8, new ListNode(10)))));
reorderLinkedListV2.ReorderList(list2);
list2.PrintList();































