using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Deciphering
{
    class Program
    {
        static void Main(string[] args)
        {
            string encryptedBook = Console.ReadLine();
            string[] substring = Console
                .ReadLine()
                .Split(" ");

            string regex = @"^[d-z{}|#]+$";

            StringBuilder newText = new StringBuilder();  
            if (Regex.IsMatch(encryptedBook, regex))
            {
                foreach (char symbol in encryptedBook)
                {
                    char newSymbol = (char)(symbol - 3);
                    newText.Append(newSymbol);
                }

                string finalText = newText.ToString();

                finalText = finalText.Replace($"{substring[0]}", $"{substring[1]}");

                Console.WriteLine(finalText);
            }
            else
            {
                Console.WriteLine("This is not the book you are looking for.");
            }
        }
    }
}
