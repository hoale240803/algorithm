using Algorithm.ArrayAndHashing;
using Algorithm.Stack;
using Algorithm.TwoPointers;


// MinStack minimumStack = new MinStack();
// minimumStack.Push(1);
// minimumStack.Push(2);
// minimumStack.Push(3);
// Console.WriteLine(minimumStack.GetMin());   
// ["MinStack", "push", -1, "push", 1, "push", -1, "pop", "top", "getMin"]
// output: [null,null,null,null,null,1,-1]


MinStack minStack = new MinStack();
minStack.Push(0);
minStack.Push(1);
minStack.Push(2);
minStack.Push(3);
minStack.print();

minStack.Pop();
Console.WriteLine(minStack.Top());
Console.WriteLine(minStack.GetMin());

// ["MinStack", "push", 1, "push", 2, "push", 0, "getMin", "pop", "top", "getMin"]
// output: [null,null,null,null,0,null,2,1]
// MinStack minStack = new MinStack();
// minStack.Push(1);
// minStack.Push(2);
// minStack.Push(0);

// 0 2 1


Console.WriteLine(minStack.GetMin());
// 0
minStack.Pop();
// => 1
Console.WriteLine(minStack.Top());
Console.WriteLine(minStack.GetMin());








