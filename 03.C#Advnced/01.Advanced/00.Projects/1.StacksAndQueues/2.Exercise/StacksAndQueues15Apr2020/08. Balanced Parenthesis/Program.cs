using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var stack = new Stack<string>();
            var flag = true;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(' || input[i] == '{' || input[i] == '[')
                {
                    stack.Push(input[i].ToString());
                }

                if (stack.Any())
                {
                    if (input[i] == ')')
                    {
                        var currParenthesis = stack.Pop();

                        if (!(currParenthesis == "("))
                        {
                            flag = false;
                            break;
                        }
                    }

                    if (input[i] == '}')
                    {
                        var currParenthesis = stack.Pop();

                        if (!(currParenthesis == "{"))
                        {
                            flag = false;
                            break;
                        }
                    }

                    if (input[i] == ']')
                    {
                        var currParenthesis = stack.Pop();

                        if (!(currParenthesis == "["))
                        {
                            flag = false;
                            break;
                        }
                    }
                }
                else
                {
                    flag = false;
                }
               
            }

            if (flag && stack.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
