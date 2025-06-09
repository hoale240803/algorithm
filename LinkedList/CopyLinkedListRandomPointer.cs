namespace Algorithm.LinkedList;

public class Node
{
    public int val;
    public Node next;
    public Node random;

    public Node(int _val)
    {
        val = _val;
        next = null;
        random = null;
    }
}

public class CopyLinkedListRandomPointer
{

    // Copy Linked List with Random Pointer
    // You are given the head of a linked list of length n. Unlike a singly linked list, each node contains an additional pointer random, which may point to any node in the list, or null.
    // Create a deep copy of the list.

    // The deep copy should consist of exactly n new nodes, each including:
    // The original value val of the copied node
    // A next pointer to the new node corresponding to the next pointer of the original node
    // A random pointer to the new node corresponding to the random pointer of the original node
    // Note: None of the pointers in the new list should point to nodes in the original list.

    // Return the head of the copied linked list.
    // In the examples, the linked list is represented as a list of n nodes. Each node is represented as a pair of [val, random_index] where random_index is the index of the node (0-indexed) that the random pointer points to, or null if it does not point to any node.

    // Example 1: 
    // Input: head = [[3,null],[7,3],[4,0],[5,1]]
    // Output: [[3,null],[7,3],[4,0],[5,1]]

    // Example 2:
    // Input: head = [[1,null],[2,2],[3,2]]
    // Output: [[1,null],[2,2],[3,2]]



    // Recursion + hashmap

    private Dictionary<Node, Node> map = new Dictionary<Node, Node>();

    public Node copyRandomList(Node head)
    {
        if (head == null) return null;
        if (map.ContainsKey(head)) return map[head];

        Node copy = new Node(head.val);
        map[head] = copy;
        copy.next = copyRandomList(head.next);

        if (head.random != null)
        {
            copy.random = copyRandomList(head.random);
        }
        else
        {
            copy.random = null;
        }

        return copy;
    }

    // Hashmap (Two passes)

    public Node copyRandomList2(Node head)
    {
        Dictionary<Node, Node> oldToCopy = new Dictionary<Node, Node>();

        Node cur = head;

        while (cur != null)
        {
            Node copy = new Node(cur.val);
            oldToCopy[cur] = copy;
            cur = cur.next;
        }

        cur = head;

        while (cur != null)
        {
            Node copy = oldToCopy[cur];
            copy.next = cur.next != null ? oldToCopy[cur.next] : null;
            copy.random = cur.random != null ? oldToCopy[cur.random] : null;
            cur = cur.next;
        }

        return head != null ? oldToCopy[head] : null;
    }

    // Hash map (one pass)
    public Node copyRandomList3(Node head)
    {
        if (head == null) return null;

        Dictionary<Node, Node> oldToCopy = new Dictionary<Node, Node>();

        Node cur = head;

        while (cur != null)
        {
            if (!oldToCopy.ContainsKey(cur))
            {
                oldToCopy[cur] = new Node(cur.val);
            }
            else
            {
                oldToCopy[cur].val = cur.val;
            }

            if (cur.next != null)
            {
                if (!oldToCopy.ContainsKey(cur.next))
                {
                    oldToCopy[cur.next] = new Node(0);
                }
                oldToCopy[cur].next = oldToCopy[cur.next];
            }
            else
            {
                oldToCopy[cur].next = null;
            }

            if (cur.random != null)
            {
                if (!oldToCopy.ContainsKey(cur.random))
                {
                    oldToCopy[cur.random] = new Node(0);
                }

                oldToCopy[cur].random = oldToCopy[cur.random];
            }
            else
            {
                oldToCopy[cur].random = null;
            }

            cur = cur.next;
        }

        return oldToCopy[head];
    }

    // Space Optimized -I

    public Node copyRandomList4(Node head)
    {
        if (head == null)
        {
            return null;
        }

        Node l1 = head;
        while (l1 != null)
        {
            Node l2 = new Node(l1.val);
            l2.next = l1.next;
            l1.next = l2;
            l1 = l2.next;
        }

        Node newHead = head.next;
        l1 = head;
        while (l1 != null)
        {
            if (l1.random != null)
            {
                l1.next.random = l1.random.next;
            }

            l1 = l1.next.next;
        }

        l1 = head;
        while (l1 != null)
        {
            Node l2 = l1.next;
            l1.next = l2.next;
            if (l2.next != null)
            {
                l2.next = l2.next.next;
            }
            l1 = l1.next;
        }

        return newHead;
    }
}


