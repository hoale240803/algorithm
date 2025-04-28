using LinkedList;

namespace Algorithm.LinkedList;

public class MergeTwoSortedLinkedLists
{
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        // You are given the heads of two sorted linked lists list1 and list2.
        // Merge the two lists into one sorted linked list and return the head of the new sorted linked list.
        // The new list should be made up of nodes from list1 and list2.

        // Example 1:
        // Input: list1 = [1,2,4], list2 = [1,3,5]
        // Output: [1,1,2,3,4,5]

        // Example 2:
        // Input: list1 = [], list2 = [1,2]
        // Output: [1,2]

        // Example 3:
        // Input: list1 = [], list2 = []
        // Output: []

        // create a new list node called head
        // while list1.next and list2.next are not null
        // compare the values of the head of the two lists
        // if list1.val is less than list2.val, then list1 is the head of the new list
        // if list1.val is greater than list2.val, then list2 is the head of the new list
        // if list1.val is equal to list2.val, then list1 is the head of the new list
        // if list1.val is equal to list2.val, then list2 is the head of the new list
        // continue this process until one of the lists is null then return newListNode
        ListNode head = new ListNode(0);
        ListNode current = head;
        while (list1 != null && list2 != null)
        {
            if (list1.val < list2.val)
            {
                current.next = list1;
                list1 = list1.next;
            }
            else
            {
                current.next = list2;
                list2 = list2.next;
            }

            current = current.next;
        }

        current.next = list1 != null ? list1 : list2;

        return head.next;
    }

    public void PrintList(ListNode list)
    {
        while (list != null)
        {
            Console.Write(list.val + " ");
            list = list.next;
        }
    }
}