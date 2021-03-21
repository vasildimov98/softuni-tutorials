using System;

namespace PersonsInfo
{
    public class Person
    {
        private const int THIRTY_YEARS_OLD_AGE = 30;
        private const int MIN_NAME_LENGTH = 3;
        private const decimal MIN_SALARY = 460;

        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName 
        {
            get => this.firstName;
            private set
            {
                if (value.Length < MIN_NAME_LENGTH)
                {
                    var msg = "First name cannot contain fewer than 3 symbols!";
                    this.ThrowArgumentException(msg);
                }

                this.firstName = value;
            }
        }
        public string LastName
        {
            get => this.lastName;
            private set
            {
                if (value.Length < MIN_NAME_LENGTH)
                {
                    var msg = "Last name cannot contain fewer than 3 symbols!";
                    this.ThrowArgumentException(msg);
                }

                this.lastName = value;
            }
        }
        public int Age
        {
            get => this.age;
            private set
            {
                if (value <= 0)
                {
                    var msg = "Age cannot be zero or a negative integer!";
                    this.ThrowArgumentException(msg);
                }

                this.age = value;
            }
        }
        public decimal Salary
        {
            get => this.salary;
            private set
            {
                if (value < MIN_SALARY)
                {
                    var msg = "Salary cannot be less than 460 leva!";
                    this.ThrowArgumentException(msg);
                }

                this.salary = value;
            }
        }

        public void IncreaseSalary(decimal percentage)
        {
            var devider = 100;

            if (this.Age < THIRTY_YEARS_OLD_AGE)
            {
                devider *= 2;
            }

            this.Salary += Salary * percentage / devider;
        }
        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.";
        }

        private void ThrowArgumentException(string message)
        {
            throw new ArgumentException(message);
        }
    }
}
