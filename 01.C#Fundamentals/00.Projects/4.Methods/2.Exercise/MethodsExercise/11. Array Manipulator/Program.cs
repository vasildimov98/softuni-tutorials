using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string command = "";
            int[] result = arr;
            while (true)
            {
                command = Console.ReadLine();
                if (command == "end")
                {
                    Console.WriteLine($"[{string.Join(", ", result)}]");
                    return;
                }

                string[] commandArr = command.Split();
                if (commandArr[0] == "exchange")
                {
                    if (int.Parse(commandArr[1]) >= arr.Length || int.Parse(commandArr[1]) < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        result = GetExchangeArr(commandArr, result);
                        //Console.WriteLine(string.Join(" ", result));
                    }
                }
                else if (commandArr[0] == "max")
                {
                    int maxIndex = GetMaxIndex(commandArr, result);
                    if (maxIndex == -1)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(maxIndex);
                    }
                }
                else if (commandArr[0] == "min")
                {
                    int minIndex = GetMinIndex(commandArr, result);
                    if (minIndex == -1)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(minIndex);
                    }
                }
                else if (commandArr[0] == "first")
                {
                    GetNewFirstArr(commandArr, result);

                }
                else if (commandArr[0] == "last")
                {
                    GetNewLastArr(commandArr, result);
                }
            }
        }

        static int[] GetExchangeArr(string[] commandArr, int[] arr)
        {
            int index = int.Parse(commandArr[1]);
            int[] newArr = new int[arr.Length];
            int counter = 0;
            for (int i = index; i < arr.Length - 1; i++)
            {
                newArr[counter] = arr[index + 1 + counter];
                counter++;
            }

            for (int i = 0; i < arr.Length - counter; i++)
            {
                newArr[counter + i] = arr[i];
            }

            return newArr;
        }

        static int GetMaxIndex(string[] commandArr, int[] arr)
        {
            int currMax = int.MinValue;
            int currMaxIndex = -1;
            if (commandArr[1].ToString() == "even")
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] >= currMax && arr[i] % 2 == 0)
                    {
                        currMax = arr[i];
                        currMaxIndex = i;
                    }
                }
            }
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] >= currMax && arr[i] % 2 != 0)
                    {
                        currMax = arr[i];
                        currMaxIndex = i;
                    }
                }
            }

            return currMaxIndex;
        }

        static int GetMinIndex(string[] commandArr, int[] arr)
        {
            int currMin = int.MaxValue;
            int currMinIndex = -1;
            if (commandArr[1].ToString() == "even")
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] <= currMin && arr[i] % 2 == 0)
                    {
                        currMin = arr[i];
                        currMinIndex = i;
                    }
                }
            }
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] <= currMin && arr[i] % 2 != 0)
                    {
                        currMin = arr[i];
                        currMinIndex = i;
                    }
                }
            }

            return currMinIndex;
        }

        static void GetNewFirstArr(string[] commandArr, int[] arr)
        {
            if (int.Parse(commandArr[1]) > arr.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            int count = int.Parse(commandArr[1]);
            int[] tempNewArr = new int[count];
            int counterOfEvenDigits = 0;
            int zeroDigitCounter = 0;

            if (commandArr[2] == "even")
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 0)
                    {
                        if (arr[i] == 0)
                        {
                            zeroDigitCounter++;
                        }

                        tempNewArr[counterOfEvenDigits] = arr[i];
                        counterOfEvenDigits++;

                        if (counterOfEvenDigits >= count)
                        {
                            break;
                        }
                    }
                }

                if (counterOfEvenDigits == 0)
                {
                    Console.WriteLine("[]");
                }
                else
                {
                    int fakeZeroCounter = 0 - zeroDigitCounter;

                    for (int i = 0; i < tempNewArr.Length; i++)
                    {
                        if (tempNewArr[i] == 0)
                        {
                            fakeZeroCounter++;
                        }
                    }

                    int[] finalNewArr = new int[count - fakeZeroCounter];

                    for (int i = 0; i < finalNewArr.Length; i++)
                    {
                        finalNewArr[i] = tempNewArr[i];
                    }

                    Console.WriteLine($"[{string.Join(", ", finalNewArr)}]");
                }
            }
            else
            {
                int index = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 != 0)
                    {
                        tempNewArr[index] = arr[i];
                        index++;
                        count--;
                        if (count == 0)
                        {
                            break;
                        }
                    }
                }
                if (count == int.Parse(commandArr[1]))
                {
                    Console.WriteLine("[]");
                }
                else
                {
                    PrintArrWithoutZeros(tempNewArr);
                }
            }
        }


        static void GetNewLastArr(string[] commandArr, int[] arr)
        {

            if (int.Parse(commandArr[1]) > arr.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            else
            {
                if (commandArr[2] == "odd")
                {
                    int counter = 0;

                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (arr[j] % 2 != 0)
                        {
                            counter++;
                        }
                    }

                    int[] oddArr = new int[counter];
                    counter = 0;

                    for (int k = 0; k < arr.Length; k++)
                    {
                        if (arr[k] % 2 != 0)
                        {
                            oddArr[counter] = arr[k];
                            counter++;
                        }
                    }

                    if (int.Parse(commandArr[1]) >= oddArr.Length)
                    {
                        Console.WriteLine($"[{string.Join(", ", oddArr)}]");
                    }
                    else
                    {
                        int[] finalArr = new int[int.Parse(commandArr[1])];


                        for (int i = 0; i < int.Parse(commandArr[1]); i++)
                        {
                            finalArr[i] = oddArr[oddArr.Length - int.Parse(commandArr[1]) + i];
                        }

                        PrintArrWithoutZeros(finalArr);
                    }
                }
                else
                {
                    int counter = 0;
                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (arr[j] % 2 == 0)
                        {
                            counter++;
                        }
                    }

                    int[] evenArr = new int[counter];

                    counter = 0;

                    for (int k = 0; k < arr.Length; k++)
                    {
                        if (arr[k] % 2 == 0)
                        {
                            evenArr[counter] = arr[k];
                            counter++;
                        }
                    }

                    if (int.Parse(commandArr[1]) >= evenArr.Length)
                    {
                        Console.WriteLine($"[{string.Join(", ", evenArr)}]");
                    }
                    else
                    {
                        int[] temp = new int[int.Parse(commandArr[1])];

                        for (int i = 0; i < temp.Length; i++)
                        {
                            temp[i] = evenArr[evenArr.Length - int.Parse(commandArr[1]) + i];
                        }

                        PrintArrWithoutZeros(temp);
                    }
                }
            }
        }

        static void PrintArrWithoutZeros(int[] temp)
        {
            int counter1 = 0;

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] != 0)
                {
                    counter1++;
                }
            }

            int[] finalTemp = new int[counter1];
            int counter2 = 0;

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] != 0)
                {
                    finalTemp[counter2] = temp[i];
                    counter2++;
                }
            }

            Console.WriteLine($"[{string.Join(", ", finalTemp)}]");
        }
    }
}