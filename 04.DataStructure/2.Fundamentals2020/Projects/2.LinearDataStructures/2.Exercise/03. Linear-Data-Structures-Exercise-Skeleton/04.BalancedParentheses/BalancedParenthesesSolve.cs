namespace Problem04.BalancedParentheses
{
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            if (string.IsNullOrWhiteSpace(parentheses)
                || parentheses.Length % 2 != 0)
            {
                return false;
            }

            var openBrackets = new Stack<char>();

            foreach (var currBracket in parentheses)
            {
                var expectedBracket = (char)default;

                switch (currBracket)
                {
                    case ')':
                        expectedBracket = '(';
                        break;
                    case '}':
                        expectedBracket = '{';
                        break;
                    case ']':
                        expectedBracket = '[';
                        break;
                    default:
                        openBrackets.Push(currBracket);
                        break;
                }

                if (expectedBracket != default 
                    && openBrackets.Pop() != expectedBracket)
                {
                    return false;
                }
            }

            return openBrackets.Count == 0;
        }
    }
}
