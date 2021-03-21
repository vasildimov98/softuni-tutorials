namespace CollectionHierarchy
{
    using System;
    using System.Linq;
    using System.Text;
    using CollectionHierarchy.Contracts;
    using CollectionHierarchy.Models;
    public class StartUp
    {
        static void Main()
        {
            var addCollection = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();

            var sb = new StringBuilder();

            var elementsToAdd = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            AddElements(elementsToAdd, addCollection, sb);
            AddElements(elementsToAdd, addRemoveCollection, sb);
            AddElements(elementsToAdd, myList, sb);

            var elementsToRemove = int.Parse(Console.ReadLine());

            RemoveElement(elementsToRemove, addRemoveCollection, sb);
            RemoveElement(elementsToRemove, myList, sb);

            Console.WriteLine(sb.ToString().TrimEnd());
        }

        private static void RemoveElement(int count, IRemovable removable, StringBuilder sb)
        {
            for (int i = 0; i < count; i++)
            {
                if (i < count - 1)
                {
                    sb.Append(removable.Remove() + " ");
                }
                else
                {
                    sb.Append(removable.Remove());
                }
            }

            sb.AppendLine();
        }

        private static void AddElements(string[] elements, IAddable addable, StringBuilder sb)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                if (i < elements.Length - 1)
                {
                    sb.Append(addable.Add(elements[i]) + " ");
                }
                else
                {
                    sb.Append(addable.Add(elements[i]));
                }
            }

            sb.AppendLine();
        }
    }
}
