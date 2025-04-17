namespace Algorithm.Stack;

public class ValidParenthesesStack{

    public bool IsValid(string s) {

        // input: a string s consisting of the following characters: '(', ')', '{', '}', '[' and ']'.
        // is valid if and only if:
        // Every open bracket is closed by the same type of close bracket.
        // Open brackets are closed in the correct order.
        // Every close bracket has a corresponding open bracket of the same type.

        // solution: apply stack 
        // convert to char array
        // push to stack for each element, if exist pop 
        // if stack is empty return true
        // else return false

        // example 

        var stack = new Stack<char>();

        foreach (var c in s)
        {
            if (c == '(' || c == '{' || c == '[')
            {   
                stack.Push(c);
            }
            else{
                if (stack.Count == 0) return false;
                var top = stack.Pop();
                if (c == ')' && top != '(' || c == '}' && top != '{' || c == ']' && top != '[') return false;
            }
        }

        return stack.Count == 0;
    }
}