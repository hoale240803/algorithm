using Algorithm.BinarySearch;
using Algorithm.SlideWindow;
using Algorithm.LinkedList;
using LinkedList;

// output: 1 2 3 5
RemoveNodeFromEndOfLinkedList removeNodeFromEndOfLinkedList = new RemoveNodeFromEndOfLinkedList();
ListNode list1 = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
removeNodeFromEndOfLinkedList.RemoveNthFromEnd(list1, 2);
list1.PrintList();
































