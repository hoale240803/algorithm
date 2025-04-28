using LinkedList;

namespace Algorithm.LinkedList;
public class RemoveNodeFromEndOfLinkedList
{
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        // You are given the beginning of a linked list head, and an integer n.
        // Remove the nth node from the end of the list and return the beginning of the list.

        // Example 1:
        //Input: head = [1,2,3,4], n = 2
        // Output: [1,2,4]

        // Example 2:
        // Input: head = [5], n = 1
        // Output: []

        // find the nth node from the end of the list by using two pointers 
        // using while loop to move the first pointer n steps ahead
        // then move both pointers until the first pointer reaches the end of the list
        // second pointer will be the node before the nth node from the end

        ListNode dummy = new ListNode(0, head);
        ListNode first = dummy;
        ListNode second = dummy;

        while (n >= 0)
        {
            first = first.next;
            n--;
        }

        while (first != null)
        {
            first = first.next;
            second = second.next;
        }

        second.next = second.next.next;
        return dummy.next;
    }
}