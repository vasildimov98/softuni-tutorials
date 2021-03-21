namespace P04_Hospital
{
    using System.Collections.Generic;
    using System.Linq;

    public class Room
    {
        private const int CAPACITY = 3;
        private List<Patient> patients;

        private Room()
        {
            this.patients = new List<Patient>();
        }

        public Room(byte number)
            : this()
        {
            this.Number = number;
        }
        public byte Number { get; }
        public int Count => this.patients.Count;
        public void AddPatient(Patient patient)
        {
            if (this.Count < CAPACITY)
            {
                this.patients.Add(patient);
            }
        }

        public void ShowPatient()
        {
            foreach (var patient in this.patients)
            {
                System.Console.WriteLine(patient.ToString());
            }
        }

        public void ShowOrderedPatient()
        {
            foreach (var patient in this.patients.OrderBy(p => p.Name))
            {
                System.Console.WriteLine(patient.ToString());
            }
        }
    }
}
