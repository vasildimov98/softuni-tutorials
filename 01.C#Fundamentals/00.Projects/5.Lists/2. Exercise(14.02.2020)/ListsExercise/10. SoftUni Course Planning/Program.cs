using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Course_Planning
{
    class Program
    {
        static void Main()
        {
            List<string> list = Console
                .ReadLine()
                .Split(", ")
                .ToList();

            GetList(list);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{list[i]}");
            }
        }

        static void GetList(List<string> list)
        {
            string command;
            while ((command = Console.ReadLine()) != "course start")
            {
                List<string> allCommands = command
                    .Split(":")
                    .ToList();

                string action = allCommands[0];
                string lessonTitle = allCommands[1];

                if (action == "Add")
                {
                    AddToList(list, lessonTitle);
                }
                else if (action == "Insert")
                {
                    InserToList(list, allCommands, lessonTitle);
                }
                else if (action == "Remove")
                {
                    RemoveFromList(list, lessonTitle);
                }
                else if (action == "Swap")
                {
                    string firstLesson = allCommands[1];
                    string secondLesson = allCommands[2];

                    if (list.Contains(firstLesson) && list.Contains(secondLesson))
                    {
                        SwapLesson(list, firstLesson, secondLesson);
                    }
                    if (list.Contains(firstLesson + "-" + "Exercise") || list.Contains(secondLesson + "-" + "Exercise"))
                    {
                        SwapExercise(list, firstLesson, secondLesson);
                    }
                }
                else if (action == "Exercise")
                {
                    AddExercise(list, lessonTitle);
                }
            }
        }

        private static void AddExercise(List<string> list, string lessonTitle)
        {
            string excercise = lessonTitle + '-' + "Exercise";

            if (!list.Contains(lessonTitle))
            {
                if (!list.Contains(excercise)) 
                {
                    list.Add(lessonTitle);
                    list.Add(excercise);
                }
            }
            else if (list.Contains(lessonTitle) && !list.Contains(excercise)) 
            {
                int indexx = list.IndexOf(lessonTitle);
                list.Insert(indexx + 1, excercise);
            }
        }

        private static void SwapExercise(List<string> list, string firstLesson, string secondLesson)
        {
            int firstLessonPosition = list.IndexOf(firstLesson);
            int secondLesonPosition = list.IndexOf(secondLesson);


            if (list.Contains(firstLesson + "-" + "Exercise"))
            {
                list.Remove(firstLesson + "-" + "Exercise");

                if (firstLessonPosition == list.Count - 1)
                {
                    list.Add(firstLesson + "-" + "Exercise");
                }
                else
                {
                    list.Insert(firstLessonPosition + 1, firstLesson + "-" + "Exercise");
                }
            }

            if (list.Contains(secondLesson + "-" + "Exercise"))
            {
                list.Remove(secondLesson + "-" + "Exercise");

                if (secondLesonPosition == list.Count - 1)
                {
                    list.Add(secondLesson + "-" + "Exercise");
                }
                else
                {
                    list.Insert(secondLesonPosition + 1, secondLesson + "-" + "Exercise");
                }
            }
        }

        private static void SwapLesson(List<string> list, string firstLesson, string secondLesson)
        {
            int firstLessonPosition = list.IndexOf(firstLesson);
            int secondLessonPosition = list.IndexOf(secondLesson);

            list[firstLessonPosition] = secondLesson;
            list[secondLessonPosition] = firstLesson;
        }

        private static void RemoveFromList(List<string> list, string lessonTitle)
        {
            if (list.Contains(lessonTitle))
            {
                list.Remove(lessonTitle);
            }
            if (list.Contains(lessonTitle + "-" + "Exercise"))
            {
                list.Remove(lessonTitle + "-" + "Exercise");
            }
        }

        private static void InserToList(List<string> list, List<string> allCommands, string lessonTitle)
        {
            int index = int.Parse(allCommands[2]);

            if (list.Contains(lessonTitle) == false)
            {
                list.Insert(index, lessonTitle);

            }
        }

        private static void AddToList(List<string> list, string lessonTitle)
        {
            if (list.Contains(lessonTitle) == false)
            {
                list.Add(lessonTitle);
            }
        }
    }
}
