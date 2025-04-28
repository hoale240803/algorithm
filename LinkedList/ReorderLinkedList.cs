using LinkedList;

namespace Algorithm.LinkedList
{
    public class ReorderLinkedList
    {
        public void ReorderList(ListNode head)
        {
            // You are given the head of a singly linked-list.
            // The positions of a linked list of length = 7 for example, can intially be represented as:

            // [0, 1, 2, 3, 4, 5, 6]
            // Reorder the nodes of the linked list to be in the following order:

            // [0, 6, 1, 5, 2, 4, 3]
            // Notice that in the general case for a list of length = n the nodes are reordered to be in the following order:

            // [0, n-1, 1, n-2, 2, n-3, ...]
            // You may not modify the values in the list's nodes, but instead you must reorder the nodes themselves.

            // using slow and fast pointer to find the middle of the list
            // then reverse the second half of the list
            // then merge the two halves

            ListNode slow = head, fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            ListNode second = slow.next;
            slow.next = null;

            second = ReverseList(second);

            ListNode first = head;
            while (second != null)
            {
                ListNode temp1 = first.next;
                ListNode temp2 = second.next;
                first.next = second;
                second.next = temp1;
                first = temp1;
                second = temp2;
            }
        }

        private ListNode ReverseList(ListNode head)
        {
            ListNode prev = null;
            ListNode current = head;
            while (current != null)
            {
                ListNode next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }
            return prev;
        }
    }
}