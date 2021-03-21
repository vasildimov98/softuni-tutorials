using System;
using System.Collections.Generic;
using System.Linq;

namespace Contact_List
{
    class Program
    {
        static void Main()
        {
            List<string> contacts = Console
                .ReadLine()
                .Split()
                .ToList();

            while (true)
            {
                string[] allCommand = Console
                    .ReadLine()
                    .Split();

                string action = allCommand[0];

                if (action == "Add")
                {
                    AddContact(contacts, allCommand);
                    //Console.WriteLine($"Contacts: {string.Join(" ", contacts)}");
                }
                else if (action == "Remove")
                {
                    RemoveContact(contacts, allCommand);
                    //Console.WriteLine($"Contacts: {string.Join(" ", contacts)}");
                }
                else if (action == "Export")
                {
                    ExportContact(contacts, allCommand);
                }
                else if (action == "Print")
                {
                    PrintInformation(contacts, allCommand);
                    return;
                }
            }
        }

        private static void PrintInformation(List<string> contacts, string[] allCommand)
        {
            if (allCommand[1] == "Reversed")
            {
                for (int i = 0; i < contacts.Count / 2; i++)
                {
                    string temp = contacts[i];
                    contacts[i] = contacts[contacts.Count - 1 - i];
                    contacts[contacts.Count - 1 - i] = temp;
                }
            }
            if (contacts.Count > 0)
            {
                Console.WriteLine($"Contacts: {string.Join(" ", contacts)}");
            }
            return;
        }

        private static void ExportContact(List<string> contacts, string[] allCommand)
        {
            int startIndex = int.Parse(allCommand[1]);
            int count = int.Parse(allCommand[2]);
            int endIndex = startIndex + count;
            if (count == 0)
            {
                return;
            }
            string result = "";
            if (endIndex > contacts.Count)
            {
                endIndex = contacts.Count;
            }
            if (startIndex < 0)
            {
                startIndex = 0;
            }

            for (int i = startIndex; i < endIndex; i++)
            {
                result += $"{contacts[i]} ";
            }

            Console.WriteLine(result);
        }

        private static void RemoveContact(List<string> contacts, string[] allCommand)
        {
            int index = int.Parse(allCommand[1]);

            if (index >= 0 && index < contacts.Count)
            {
                contacts.RemoveAt(index);
            }
        }

        private static void AddContact(List<string> contacts, string[] allCommand)
        {
            string contact = allCommand[1];
            int index = int.Parse(allCommand[2]);

            if (contacts.Contains(contact))
            {
                if (index >= 0 && index <= contacts.Count)
                {
                    contacts.Insert(index, contact);
                }
            }
            else
            {
                contacts.Add(contact);
            }
        }
    }
}
