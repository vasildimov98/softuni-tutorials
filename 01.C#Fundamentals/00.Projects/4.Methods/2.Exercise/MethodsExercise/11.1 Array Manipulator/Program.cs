using System;
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
            
            while (true)
            {
                command = Console.ReadLine();
                if (command == "end")
                {
                    Console.WriteLine($"[{string.Join(", ", arr)}]");
                    return;
                }

                string[] commandArr = command.Split();
                if (commandArr[0] == "exchange")
                {
                    if (int.Parse(commandArr[1]) >= arr.Length)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        GetExchangeArr(commandArr, arr);
                    }
                }
                else if (commandArr[0] == "max")
                {
                    string evenOrOdd = commandArr[1];

                    Console.WriteLine(FindMaxEvenOrOdd(evenOrOdd, arr));
                }
                else if (commandArr[0] == "min")
                {
                    string evenOrOdd = commandArr[1];
                    Console.WriteLine(FindMinEvenOrOdd(evenOrOdd, arr));
                }
                else if (commandArr[0] == "first")
                {
                    int countOfNumbers = int.Parse(commandArr[1]);
                    string evenOrOdd = commandArr[2];
                    PrintFirstEvenOrOdd(arr, countOfNumbers, evenOrOdd);
                }
                else if (commandArr[0] == "last")
                {
                    int countOfNumbers = int.Parse(commandArr[1]);
                    string evenOrOdd = commandArr[2];
                    PrintLastEvenOrodd(arr, countOfNumbers, evenOrOdd);
                }
            }
        }

        static int[] GetExchangeArr(string[] commandArr, int[] arr)
        {
            int index = int.Parse(commandArr[1]);
            int[] temp = new int[index + 1];

            for (int i = 0; i <= index; i++)
            {
                temp[i] = arr[i];
            }

            for (int i = 0; i <= index; i++)
            {
                for (int k = 0; k < arr.Length - 1; k++)
                {
                    arr[k] = arr[k + 1];
                }
            }

            int counter3 = 0;

            for (int i = arr.Length - 1 - index; i < arr.Length; i++)
            {
                arr[i] = int.Parse(temp[counter3].ToString());
                counter3++;
            }

            return arr;
        }

        static string FindMaxEvenOrOdd(string evenOrOdd, int[] numbers)
        {
            if (evenOrOdd == "even")
            {
                int max = int.MinValue;
                int indexPosition = -222;
                bool check = false;

                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] % 2 == 0)
                    {
                        if (numbers[i] >= max)
                        {
                            max = numbers[i];
                            indexPosition = i;
                            check = true;
                        }
                    }
                }
                if (check)
                {
                    return indexPosition.ToString();
                }
                return "No matches";
            }
            else
            {
                int max = int.MinValue;
                int indexPosition = -222;
                bool check = false;

                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] % 2 != 0)
                    {
                        if (numbers[i] >= max)
                        {
                            max = numbers[i];
                            indexPosition = i;
                            check = true;
                        }
                    }
                }
                if (check)
                {
                    return indexPosition.ToString();
                }

                return "No matches";
            }
        }

        static string FindMinEvenOrOdd(string evenOrOdd, int[] numbers)
        {
            if (evenOrOdd == "even")
            {
                int min = int.MaxValue;
                int indexPosition = -222;
                bool check = false;

                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] % 2 == 0)
                    {
                        if (numbers[i] <= min)
                        {
                            min = numbers[i];
                            indexPosition = i;
                            check = true;
                        }
                    }
                }
                if (check)
                {
                    return indexPosition.ToString();
                }
                return "No matches";
            }
            else
            {
                int min = int.MaxValue;
                int indexPosition = -222;
                bool check = false;

                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] % 2 != 0)
                    {
                        if (numbers[i] <= min)
                        {
                            min = numbers[i];
                            indexPosition = i;
                            check = true;
                        }
                    }
                }
                if (check)
                {
                    return indexPosition.ToString();
                }
                return "No matches";
            }
        }

        static void PrintFirstEvenOrOdd(int[] numbers, int count, string evenOrOdd)
        {
            int[] temp = new int[count];
            int counter = 0;
            int counterOfEvenDigits = 0;
            int zeroDigitCounter = 0;

            if (count > numbers.Length)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {
                if (evenOrOdd == "odd")
                {

                    for (int i = 0; i < numbers.Length; i++)
                    {
                        if (numbers[i] % 2 != 0)
                        {
                            temp[counter] = numbers[i];
                            counter++;
                            if (counter >= count)
                            {
                                break;
                            }
                        }
                    }
                    PrintArrayWithoutZero(temp);

                }
                else
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        if (numbers[i] % 2 == 0)
                        {
                            if (numbers[i] == 0)
                            {
                                zeroDigitCounter++;
                            }

                            temp[counterOfEvenDigits] = numbers[i];
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

                        for (int i = 0; i < temp.Length; i++)
                        {
                            if (temp[i] == 0)
                            {
                                fakeZeroCounter++;
                            }
                        }

                        int[] finalArr = new int[temp.Length - fakeZeroCounter];

                        for (int i = 0; i < finalArr.Length; i++)
                        {
                            finalArr[i] = temp[i];
                        }
                        Console.WriteLine($"[{string.Join(", ", finalArr)}]");
                    }

                }
            }
        }

        static void PrintArrayWithoutZero(int[] temp)
        {
            int counter1 = 0;

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] != 0)
                {
                    counter1++;
                }
            }

            int[] newTemp = new int[counter1];
            int counter2 = 0;

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] != 0)
                {
                    newTemp[counter2] = temp[i];
                    counter2++;
                }
            }

            Console.WriteLine($"[{string.Join(", ", newTemp)}]");
        }
        static void PrintLastEvenOrodd(int[] numbers, int count, string evenOrOdd)
        {
            if (count > numbers.Length)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {
                if (evenOrOdd == "odd")
                {
                    int counter8 = 0;
                    //тук намираме колко броя нечетни числа има в масива
                    for (int j = 0; j < numbers.Length; j++)
                    {
                        if (numbers[j] % 2 != 0)
                        {
                            counter8++;
                        }
                    }

                    int[] OddArr = new int[counter8];

                    counter8 = 0;

                    for (int k = 0; k < numbers.Length; k++)
                    {
                        if (numbers[k] % 2 != 0)
                        {
                            OddArr[counter8] = numbers[k];
                            counter8++;
                        }
                    }

                    if (count >= OddArr.Length)
                    {
                        Console.WriteLine($"[{string.Join(", ", OddArr)}]");
                    }
                    else
                    {
                        
                        int[] temp = new int[count];

                        for (int i = 0; i < count; i++)
                        {
                            temp[i] = OddArr[OddArr.Length - count + i];
                        }

                        PrintArrayWithoutZero(temp);
                    }

                }
                else
                {
                    int counter8 = 0;

                    for (int j = 0; j < numbers.Length; j++)
                    {
                        if (numbers[j] % 2 == 0)
                        {
                            counter8++;
                        }
                    }

                    int[] evenArr = new int[counter8];

                    counter8 = 0;

                    for (int k = 0; k < numbers.Length; k++)
                    {
                        if (numbers[k] % 2 == 0)
                        {
                            evenArr[counter8] = numbers[k];
                            counter8++;
                        }
                    }

                    if (count >= evenArr.Length)
                    {
                        Console.WriteLine($"[{string.Join(", ", evenArr)}]");
                    }
                    else
                    {
                        int[] temp = new int[count];

                        for (int i = 0; i < temp.Length; i++)
                        {
                            temp[i] = evenArr[evenArr.Length - count + i];
                        }

                        PrintArrayWithoutZero(temp);
                    }
                }
            }
        }
    }
}
