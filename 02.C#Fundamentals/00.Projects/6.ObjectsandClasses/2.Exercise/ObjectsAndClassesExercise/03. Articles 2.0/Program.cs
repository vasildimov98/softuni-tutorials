using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Articles
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            List<Article> articles = GetArticles(n);

            articles = OrderByCommand(articles);

            foreach (var article in articles)
            {
                Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
            }
        }

        private static List<Article> GetArticles(int n)
        {
            List<Article> articles = new List<Article>();
            for (int i = 0; i < n; i++)
            {
                string[] arr = Console
                    .ReadLine()
                    .Split(", ");

                string title = arr[0];
                string content = arr[1];
                string author = arr[2];

                Article article = new Article(title, content, author);

                articles.Add(article);

                ArticleList articleList = new ArticleList(articles);
            }

            return articles;
        }

        private static List<Article> OrderByCommand(List<Article> articles)
        {
            string lastCommand = Console.ReadLine();

            if (lastCommand == "title")
            {
                articles = articles.OrderBy(t => t.Title).ToList();
            }
            else if (lastCommand == "content")
            {
                articles = articles.OrderBy(t => t.Content).ToList();
            }
            else if (lastCommand == "author")
            {
                articles = articles.OrderBy(t => t.Author).ToList();
            }

            return articles;
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
    }

    class ArticleList
    {
        public ArticleList(List<Article> articles)
        {
            Articles = articles;
        }
        public List<Article> Articles { get; set; }
    }
}
