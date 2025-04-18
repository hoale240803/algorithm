namespace Algorithm.Stack;

public class EvaluateReversePolishNotation
{
    public int EvalRPN(string[] tokens)
    {
        // You are given an array of strings tokens that represents a valid arithmetic expression in Reverse Polish Notation.
        // Return the integer that represents the evaluation of the expression.
        // The operands may be integers or the results of other operations.
        // The operators include '+', '-', '*', and '/'.
        // Assume that division between integers always truncates toward zero.

        // Use a stack to store the operands
        // When we encounter an operator, pop the last two operands from the stack, perform the operation, and push the result back onto the stack
        // At the end, the stack will contain one element, which is the result of the expression
        // Return the result

        Stack<int> stack = new Stack<int>();
        foreach (string token in tokens)
        {
            if (token == "+")
            {
                int operand2 = stack.Pop();
                int operand1 = stack.Pop();
                stack.Push(operand1 + operand2);
            }
            else if (token == "-")
            {
                int operand2 = stack.Pop();
                int operand1 = stack.Pop();
                stack.Push(operand1 - operand2);
            }
            else if (token == "*")
            {
                int operand2 = stack.Pop();
                int operand1 = stack.Pop();
                stack.Push(operand1 * operand2);
            }
            else if (token == "/")
            {
                int operand2 = stack.Pop();
                int operand1 = stack.Pop();
                stack.Push(operand1 / operand2);
            }
            else
            {
                stack.Push(int.Parse(token));
            }
        }

        return 0;

    }
}