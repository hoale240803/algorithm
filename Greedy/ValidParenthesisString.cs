namespace algorithm.Greedy;

public class ValidParenthesisString
{
    // stack
    public bool CheckValidString(string s)
    {
        Stack<int> left = new Stack<int>();
        Stack<int> star = new Stack<int>();

        for (int i = 0; i < s.Length; i++)
        {
            char ch = s[i];
            if (ch == '(')
            {
                left.Push(i);
            }
            else if (ch == '*')
            {
                star.Push(i);
            }
            else
            {
                if (left.Count == 0 && star.Count == 0) return false;
                if (left.Count > 0)
                {
                    left.Pop();
                }
                else
                {
                    star.Pop();
                }
            }
        }

        while (left.Count > 0 && star.Count > 0)
        {
            if (left.Pop() > star.Pop()) return false;
        }

        return left.Count == 0;
    }

    // greedy
    public bool CheckValidString1(string s)
    {
        int leftMin = 0, leftMax = 0;
        foreach (char c in s)
        {
            if (c == '(')
            {
                leftMin++;
                leftMax++;
            }
            else if (c == ')')
            {
                leftMin--;
                leftMax--;
            }
            else
            {
                leftMin--;
                leftMax++;
            }

            if (leftMax < 0)
            {
                return false;
            }
            if (leftMin < 0)
            {
                leftMin = 0;
            }
        }

        return leftMin == 0;
    }
}