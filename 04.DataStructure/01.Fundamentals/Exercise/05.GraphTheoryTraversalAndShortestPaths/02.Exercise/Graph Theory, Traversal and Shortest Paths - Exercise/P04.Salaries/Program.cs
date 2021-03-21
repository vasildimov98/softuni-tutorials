namespace P04.Salaries
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var numberOfNodes = int.Parse(Console.ReadLine());
            var graph = new List<int>[numberOfNodes];
            ReadGraph(graph);

            var totalSalary = 0;
            var employeesBySalary = new Dictionary<int, int>();
            for (int employee = 0; employee < graph.Length; employee++)
            {
                if (employeesBySalary.ContainsKey(employee))
                    totalSalary += employeesBySalary[employee];
                else totalSalary += GetSalary(graph, employee, employeesBySalary);
            }


            Console.WriteLine(totalSalary);
        }

        private static int GetSalary(List<int>[] graph, int employee, Dictionary<int, int> employeesBySalary)
        {
            var subordinates = graph[employee];

            if (subordinates.Count == 0)
            {
                if (!employeesBySalary.ContainsKey(employee))
                    employeesBySalary[employee] = 1;

                return employeesBySalary[employee];
            }

            var salary = 0;
            foreach (var subordinate in subordinates)
            {
                if (employeesBySalary.ContainsKey(subordinate))
                    salary += employeesBySalary[subordinate];
                else salary += GetSalary(graph, subordinate, employeesBySalary);
            }

            if (!employeesBySalary.ContainsKey(employee))
                employeesBySalary[employee] = salary;

            return salary;
        }

        private static void ReadGraph(List<int>[] graph)
        {
            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = new List<int>();
                var symbols = Console.ReadLine();
                for (int neighbor = 0; neighbor < symbols.Length; neighbor++)
                    if (symbols[neighbor] == 'Y')
                        graph[node].Add(neighbor);
            }
        }
    }
}
