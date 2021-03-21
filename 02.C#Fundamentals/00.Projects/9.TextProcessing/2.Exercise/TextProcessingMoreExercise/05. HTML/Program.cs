using System;
using System.Text;

namespace _05._HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder article = new StringBuilder();

            string title = Console.ReadLine();
            article.AppendLine("<h1>");
            article.AppendLine($"   {title}");
            article.AppendLine("</h1>");

            string content = Console.ReadLine();
            article.AppendLine("<article>");
            article.AppendLine($"    {content}");
            article.AppendLine("</article>");

            string comment = "";
            while ((comment = Console.ReadLine()) != "end of comments")
            {
                article.AppendLine("<div>");
                article.AppendLine($"    {comment}");
                article.AppendLine("</div>");
            }

            Console.WriteLine(article);
        }
    }
}
