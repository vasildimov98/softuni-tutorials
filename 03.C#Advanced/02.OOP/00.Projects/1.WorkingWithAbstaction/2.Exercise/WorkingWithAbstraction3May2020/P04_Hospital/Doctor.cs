using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Doctor
    {
        private List<Patient> patients;

        private Doctor()
        {
            this.patients = new List<Patient>();
        }
        public Doctor(string fullName)
            : this()
        {
            this.FullName = fullName;
        }

        public string FullName { get; }

        public void AddPatientToDoctor(Patient patient)
        {
            this.patients.Add(patient);
        }

        public void ShowPatients()
        {
            foreach (var patient in this.patients.OrderBy(a => a.Name))
            {
                System.Console.WriteLine(patient.ToString());
            }
        }
    }
}
