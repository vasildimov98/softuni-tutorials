using System;
using System.Text;

namespace _07._String_Explosion
{
    class Program
    {
        public static object StringBulder { get; private set; }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != '>')
                {
                    result.Append(input[i]);
                }
                else if (input[i] == '>')
                {
                    result.Append(input[i]);
                    
                    int power = input[i + 1] - '0';
                    int stop = (i + 1) + power;

                    if (stop > input.Length)
                    {
                        stop = input.Length;
                    }

                    for (int index = i + 1; index < stop; index++)
                    {
                        if (input[index] != '>')
                        {
                            i++;
                        }
                        else if (input[index] == '>')
                        {
                            result.Append(input[index]);
                            i++;
                            stop += input[index + 1] - '0' + 1;

                            if (stop > input.Length)
                            {
                                stop = input.Length;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(result);
        }

    }
}
