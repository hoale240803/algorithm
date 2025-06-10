using LinkedList;

namespace algorithm.LinkedList;

public class MergeKSortedLinkedLists
{
    public ListNode MergeKLists(ListNode[] lists)
    {
        List<int> nodes = new List<int>();

        foreach (ListNode node in lists)
        {
            ListNode curr = node;
            while (curr != null)
            {
                nodes.Add(curr.val);
                curr = curr.next;
            }
        }
        nodes.Sort();

        ListNode res = new ListNode(0);
        ListNode cur = res;
        foreach (int node in nodes)
        {
            cur.next = new ListNode(node);
            cur = cur.next;
        }

        return res.next;
    }

    // Heap
    public ListNode MergeKLists2(ListNode[] lists)
    {
        if (lists.Length == 0) return null;

        var minHeap = new PriorityQueue<ListNode, int>();

        foreach (var list in lists)
        {
            if (list != null)
            {
                minHeap.Enqueue(list, list.val);
            }
        }

        var res = new ListNode(0);
        var cur = res;

        while (minHeap.Count > 0)
        {
            var node = minHeap.Dequeue();
            cur.next = node;
            cur = cur.next;

            node = node.next;
            if (node != null)
            {
                minHeap.Enqueue(node, node.val);
            }
        }

        return res.next;
    }
}