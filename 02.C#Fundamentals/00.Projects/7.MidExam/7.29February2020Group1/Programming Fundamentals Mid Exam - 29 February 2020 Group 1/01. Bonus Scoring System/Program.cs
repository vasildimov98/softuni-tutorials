using System;

namespace _01._Bonus_Scoring_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfStudents = int.Parse(Console.ReadLine());
            int countOfLecture = int.Parse(Console.ReadLine());
            int initialBonus = int.Parse(Console.ReadLine());

            decimal maxBonuses = 0;
            int ownAttendance = 0;
            for (int i = 1; i <= countOfStudents; i++)
            {
                decimal attendances = decimal.Parse(Console.ReadLine());

                
                decimal totalBonuses = (attendances / countOfLecture) * (5 + initialBonus);

                if (totalBonuses > maxBonuses)
                {
                    maxBonuses = Math.Round(totalBonuses, 0, MidpointRounding.AwayFromZero);
                    ownAttendance = (int)attendances;
                }
            }

            Console.WriteLine($"Max Bonus: {maxBonuses}.");
            Console.WriteLine($"The student has attended {ownAttendance} lectures.");
        }
    }
}
