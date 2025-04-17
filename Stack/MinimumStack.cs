namespace Algorithm.Stack;

public class MinStack
{
    // Input: ["MinStack", "push", 1, "push", 2, "push", 0, "getMin", "pop", "top", "getMin"]
    // requirement: Design a stack class that supports the push, pop, top, and getMin operations. 
    // NOTE: Handle duplicate minimum values and handle negative values
    // MinStack() initializes the stack object.
    // void push(int val) pushes the element val onto the stack.
    // void pop() removes the element on the top of the stack.
    // int top() gets the top element of the stack.
    // int getMin() retrieves the minimum element in the stack.
    //     Constraints:
    // -2^31 <= val <= 2^31 - 1.
    // pop, top and getMin will always be called on non-empty stacks.


    // Each function should run in O(1) time.

    // Output: [null,null,null,null,0,null,2,1]

    // ["MinStack", "push", 1, "push", 2, "push", 0, "getMin", "pop", "top", "getMin"]
    // output: [null,null,null,null,0,null,2,1]


    private Stack<int> _stack;
    private Stack<int> _minStack;

    public MinStack()
    {
        _stack = new Stack<int>();
        _minStack = new Stack<int>();
    }

    public void Push(int val)
    {
        _stack.Push(val);

        // If minStack is empty or new value is less than or equal to current min
        // push it to minStack
        if (_minStack.Count == 0 || val <= _minStack.Peek())
        {
            _minStack.Push(val);
        }
    }

    public void Pop()
    {
        if (_stack.Count == 0) return;

        // If the popped value is the current minimum,
        // we need to remove it from minStack as well
        if (_stack.Peek() == _minStack.Peek())
        {
            _minStack.Pop();
        }
        _stack.Pop();
    }

    public int Top()
    {
        if (_stack.Count == 0) throw new InvalidOperationException("Stack is empty");
        return _stack.Peek();
    }

    public int GetMin()
    {
        if (_minStack.Count == 0) throw new InvalidOperationException("Stack is empty");
        return _minStack.Peek();
    }

    public void print()
    {
        foreach (var item in _stack)
        {
            Console.WriteLine(item); // Outputs: 3, 2, 1
        }
    }
}