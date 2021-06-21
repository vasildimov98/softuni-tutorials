namespace P00.DefiningClassesDemo
{
    using static System.Console;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            // Instance №1
            var dog = new Dog();

            WriteLine(dog.Bark());

            dog.Name = "Sharo";

            dog.Name = "Petkan";

            var name = dog.Name;

           WriteLine(name);

           WriteLine(dog.IsSpleeping());

            // Instance №2
            var dog2 = new Dog();

            dog2.SetName("Djaro");

            var dog2Name = dog2.GetName();

            // Instance №3
            var dog3 = new Dog();

            // Instance №4
            var dog4 = new Dog();

            // Instance №5
            var dog5 = new Dog();

            //Dice
            var dice = new Dice(6);

            var rollResult = dice.Roll();

            WriteLine(rollResult);

            var dice1 = new Dice(20);

            var rollResult1 = dice1.Roll();

            WriteLine(rollResult1);

            var dice3 = new Dice(20, "Cool", 7);

            // Enumerations
            int small = (int)CoffeeSize.Small;
            WriteLine(small);

            //Static Class
            var legs = int.Parse(MyStaticClass.ReadLine());
            var staticDog = new Dog(legs);
            var staticDog1 = new Dog(7);
            var staticDog2 = new Dog(8);
            var staticDog3 = new Dog(4);
            MyStaticClass.WriteLine(Dog.NumberOfLegs.ToString()); // output is 4;

            MyStaticClass.WriteLine(GetDailySchedule((Day)1));
            MyStaticClass.WriteLine(GetDailySchedule((Day)1, 5));
        }

        private static string GetDailySchedule(Day day)
        {
            if (day == 0)
            {
                return "Monday schedule";
            }
            else if (day == (Day)1)
            {
                return "Tuesday schedule";
            }
            else if (day == (Day)2)
            {
                return "Wednesday schedule";
            }
            else if (day == (Day)3)
            {
                return "Thursday schedule";
            }
            else if (day == (Day)4)
            {
                return "Friday schedule";
            }
            else if (day == (Day)5)
            {
                return "Saturday schedule";
            }
            else if (day == (Day)6)
            {
                return "Sunday schedule";
            }
            else
            {
                return "Invalid day!";
            }
        }
        private static string GetDailySchedule(Day day, int num)
        {
            if (day == 0)
            {
                return $"Monday schedule {num}";
            }
            else if (day == (Day)1)
            {
                return $"Tuesday schedule {num}";
            }
            else if (day == (Day)2)
            {
                return $"Wednesday schedule {num}";
            }
            else if (day == (Day)3)
            {
                return $"Thursday schedule {num}";
            }
            else if (day == (Day)4)
            {
                return $"Friday schedule {num}";
            }
            else if (day == (Day)5)
            {
                return $"Saturday schedule {num}";
            }
            else if (day == (Day)6)
            {
                return $"Sunday schedule {num}";
            }
            else
            {
                return "Invalid day!";
            }
        }
    }
}
