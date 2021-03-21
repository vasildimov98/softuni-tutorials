using System;

namespace _02._Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());
            PrintInWords(grade);
        }

        static void PrintInWords(double n)
        {
            string gradeInWords = string.Empty;
            if (n >= 2 && n <= 2.99)
            {
                gradeInWords = "Fail";
                Console.WriteLine(gradeInWords);
            }

            else if (n >= 3 && n <= 3.49)
            {
                gradeInWords = "Poor";
                Console.WriteLine(gradeInWords);
            }

            else if (n >= 3.50 && n <= 4.49)
            {
                gradeInWords = "Good";
                Console.WriteLine(gradeInWords);
            }

            else if (n >= 4.50 && n <= 5.49)
            {
                gradeInWords = "Very good";
                Console.WriteLine(gradeInWords);
            }

            else if (n >= 5.50 && n <= 6.00)
            {
                gradeInWords = "Excellent";
                Console.WriteLine(gradeInWords);
            }
        }
    }
}
