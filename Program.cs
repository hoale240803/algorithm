using Algorithm.BinarySearch;
using Algorithm.SlideWindow;
using Algorithm.LinkedList;
using LinkedList;


MergeTwoSortedLinkedLists mergeTwoSortedLinkedLists = new MergeTwoSortedLinkedLists();
ListNode list1 = new ListNode(1, new ListNode(2, new ListNode(4)));
ListNode list2 = new ListNode(1, new ListNode(3, new ListNode(5)));

ListNode result = mergeTwoSortedLinkedLists.MergeTwoLists(list1, list2);
mergeTwoSortedLinkedLists.PrintList(result);


MergeTwoSortedLinkedLists mergeTwoSortedLinkedLists2 = new MergeTwoSortedLinkedLists();
ListNode list3 = new ListNode(0, null);
ListNode list4 = new ListNode(0, null);

ListNode result2 = mergeTwoSortedLinkedLists2.MergeTwoLists(list3, list4);
mergeTwoSortedLinkedLists2.PrintList(result2);


MergeTwoSortedLinkedLists mergeTwoSortedLinkedLists3 = new MergeTwoSortedLinkedLists();
ListNode list5 = new ListNode(1, new ListNode(2, new ListNode(4)));
ListNode list6 = new ListNode();

ListNode result3 = mergeTwoSortedLinkedLists3.MergeTwoLists(list5, list6);
mergeTwoSortedLinkedLists3.PrintList(result3);




















