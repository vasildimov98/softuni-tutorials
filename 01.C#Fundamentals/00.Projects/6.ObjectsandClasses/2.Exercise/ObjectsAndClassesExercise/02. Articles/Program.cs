using System;

namespace _02._Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] article = Console
                .ReadLine()
                .Split(", ");

            Article article1 = new Article(article[0], article[1], article[2]);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console
                    .ReadLine()
                    .Split(": ");

                if (command[0] == "Edit")
                {
                    article1.EditContent(command[1]);
                }
                else if(command[0] == "ChangeAuthor")
                {
                    article1.ChangeAuthor(command[1]);
                }
                else
                {
                    article1.Rename(command[1]);
                }
            }

            Console.WriteLine(article1);
        }
    }

    class Article
    {
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public void EditContent(string content)
        {
            this.Content = content;
        }
        public void ChangeAuthor(string author)
        {
            this.Author = author;
        }
        public  void Rename(string title)
        {
            this.Title = title;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
