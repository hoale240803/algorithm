using LinkedList;

namespace Algorithm.LinkedList;
public class LinkedListCycleDetection
{
    public bool HasCycle(ListNode head)
    {

        // Given the beginning of a linked list head, return true if there is a cycle in the linked list. Otherwise, return false.
        // There is a cycle in a linked list if at least one node in the list can be visited again by following the next pointer.
        // Internally, index determines the index of the beginning of the cycle, if it exists. The tail node of the list will set it's next pointer to the index-th node. If index = -1, then the tail node points to null and no cycle exists.
        // Note: index is not given to you as a parameter.

        // Example 1:
        // Input: head = [1,2,3,4], index = 1
        // Output: true

        // Example 2:
        //Input: head = [1,2], index = -1
        // Output: false


        // using hashset to store the nodes
        // if the node is already in the hashset, then there is a cycle
        // if the node is not in the hashset, then add the node to the hashset
        // if the node is null, then there is no cycle
        // return false 

        var hashSet = new HashSet<ListNode>();
        while (head != null)
        {
            if (hashSet.Contains(head))
            {
                return true;
            }
            hashSet.Add(head);
            head = head.next;
        }
        return false;
    }

    public bool HasCycleV2(ListNode head)
    {
        ListNode slow = head, fast = head;

        while (fast != null && fast.next != null)
        {
            fast = fast.next.next;
            slow = slow.next;
            if (slow.Equals(fast)) return true;
        }

        return false;
    }
}