namespace Algorithm.Stack;

public class GenerateParenthesesStack
{
    public List<string> GenerateParenthesis(int n)
    {
        //You are given an integer n. Return all well-formed parentheses strings that you can generate with n pairs of parentheses.
        // Input: n = 3
        // Output: ["((()))","(()())","(())()","()(())","()()()"]

        // we apply backtracking to generate the parentheses
        // we have to generate all the possible combinations of parentheses
        // we have to use a stack to generate the parentheses
        // we have to use a list to store the results
        // we have to use a for loop to generate the parentheses
        // we have to use a while loop to generate the parentheses


        int open = 0;
        int close = 0;

        Stack<char> stack = new Stack<char>();

        List<string> result = new List<string>();

        void Backtrack(int open, int close, string current)
        {
            if (open == close && open == n)
            {
                result.Add(current);
                return;
            }

            if (open < n)
            {
                stack.Push('(');
                Backtrack(open + 1, close, current + "(");
                stack.Pop();
            }

            if (close < open)
            {
                stack.Push(')');
                Backtrack(open, close + 1, current + ")");
                stack.Pop();
            }
        }

        Backtrack(open, close, "");

        return result;
    }
}