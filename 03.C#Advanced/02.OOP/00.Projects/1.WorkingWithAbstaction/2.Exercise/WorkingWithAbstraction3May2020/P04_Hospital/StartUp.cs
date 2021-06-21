namespace P04_Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static List<Department> departments = new List<Department>();
        private static List<Doctor> doctors = new List<Doctor>();
        public static void Main()
        {

            string command;
            while ((command = Console.ReadLine()) != "Output")
            {
                var tokens = command
                    .Split();
                var departmentName = tokens[0];
                var fistName = tokens[1];
                var secondName = tokens[2];
                var patientName = tokens[3];
                var fullName = fistName + secondName;

                var patient = new Patient(patientName);

                if (!ContainDepartment(departmentName))
                {
                    departments.Add(new Department(departmentName));
                }

                var department = departments.First(d => d.Name == departmentName);

                if (!LookForDoctorCollection(fullName))
                {
                    doctors.Add(new Doctor(fullName));
                }

                var doctor = doctors.FirstOrDefault(d => d.FullName == fullName);

                var freeRoom = department.LookForFreeSpace();

                if (freeRoom != null)
                {
                    freeRoom.AddPatient(patient);
                    doctor.AddPatientToDoctor(patient);
                }

            }

            command = Console.ReadLine();

            while (command != "End")
            {
                var args = command
                    .Split()
                    .ToArray();

                if (args.Length == 1)
                {
                    var department = departments
                         .FirstOrDefault(d => d.Name == args[0]);

                    if (department != null)
                    {
                        department.ReportAll();
                    }
                }
                else if (args.Length == 2 && int.TryParse(args[1], out int roomNumber))
                {
                    var department = departments
                        .FirstOrDefault(d => d.Name == args[0]);

                    if (department != null)
                    {
                        department.ReportOneRoom(int.Parse(args[1]));
                    }
                }
                else
                {
                    var fullName = args[0] + args[1];

                    var doctor = doctors.FirstOrDefault(d => d.FullName == fullName);

                    if (doctor != null)
                    {
                        doctor.ShowPatients();
                    }
                }
                command = Console.ReadLine();
            }
        }

        public static bool ContainDepartment(string departmentName)
        {
            return departments.Any(d => d.Name == departmentName);
        }

        public  static bool LookForDoctorCollection(string name)
        {
            return doctors.Any(d => d.FullName == name);
        }
    }
}
