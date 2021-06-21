using System.Diagnostics;
using System.Linq.Expressions;

namespace PersonsInfo
{
    public class Person
    {
        private const int MIN_NAME_LENGTH = 3;
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
            get
            {
                return this.firstName;
            }
            private set
            {
                var message = "First name cannot contain fewer than 3 symbols!";
                Validator.ValidateInput(value.Length, MIN_NAME_LENGTH, message);
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                var message = "Last name cannot contain fewer than 3 symbols!";
                Validator.ValidateInput(value.Length, MIN_NAME_LENGTH, message);
                this.lastName = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                var message = "Age cannot be zero or a negative integer!";
                Validator.ValidateInput(value, 0, message);
                this.age = value;
            }
        }

        public decimal Salary
        {
            get
            {
                return this.salary;
            }
            private set
            {
                var message = "Salary cannot be less than 460 leva!";
                Validator.ValidateInput(value, 460, message);
                this.salary = value;
            }
        }
        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.";
        }

        public void IncreaseSalary(decimal percentage)
        {
            var devisor = 100;

            if (this.Age < 30)
            {
                devisor = 200;
            }

            this.Salary += this.Salary * percentage / devisor;
        }
    }
}
