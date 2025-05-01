namespace LinkedList;

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }

    public void PrintBFS()
    {
        ListNode current = this;
        while (current != null)
        {
            Console.Write(current.val + " ");
            current = current.next;
        }
        Console.WriteLine();
    }

    public void PrintDFS()
    {
        if (this == null)
        {
            Console.WriteLine();
            return;
        }   
        Console.Write(this.val + " ");
        this.next.PrintDFS();
    }
}
