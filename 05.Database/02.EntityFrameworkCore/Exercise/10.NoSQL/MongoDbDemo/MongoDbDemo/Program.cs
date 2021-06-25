using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace MongoDbDemo
{
    internal class Article
    {
        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rating")]
        public string Rate { get; set; }
    }

    class Program
    {
        static void Main()
        {
            MongoClient client = new MongoClient("mongodb://127.0.0.1:27017");

            var database = client.GetDatabase("Articles");
            var collection = database.GetCollection<BsonDocument>("articles");
            //InsertInitialsData(collection);
            //ShowAllNames(collection);
            //InsertAuthor(collection);

            var filter = Builders<BsonDocument>.Filter.Lte("rating", "50");

            collection.DeleteMany(filter);

            ShowAllNames(collection);
        }

        private static void InsertAuthor(IMongoCollection<BsonDocument> collection)
        {
            collection.InsertOne(new BsonDocument
                {
                    {"author", "Steve Jobs"},
                    { "date", "05-05-2005"},
                    {"name", "The story of Apple"},
                    {"rating", "60"}
                });

            var filter = Builders<BsonDocument>.Filter.Eq("author", "Steve Jobs");

            var bson = collection.Find(filter).FirstOrDefault();

            var authorObj = BsonTypeMapper.MapToDotNetValue(bson);
            var authorJson = JsonConvert.SerializeObject(authorObj);

            var author = JsonConvert.DeserializeObject<Article>(authorJson);

            Console.WriteLine($"Author: {author.Author}");
            Console.WriteLine($"Date: {author.Date}");
            Console.WriteLine($"Name: {author.Name}");
            Console.WriteLine($"Rating: {author.Rate}");
        }

        private static void ShowAllNames(IMongoCollection<BsonDocument> collection)
        {
            var articles = collection.Find(new BsonDocument())
                            .ToList();

            foreach (var bson in articles)
            {
                var articleObj = BsonTypeMapper.MapToDotNetValue(bson);
                var json = JsonConvert.SerializeObject(articleObj);

                var article = JsonConvert.DeserializeObject<Article>(json);
                Console.WriteLine(article.Name);
                Console.WriteLine(article.Rate);
            }
        }

        private static void InsertInitialsData(IMongoCollection<BsonDocument> collection)
        {
            var articles = new BsonDocument[]
                        {
                new BsonDocument
                {
                    {"author", "Bill Gates"},
                    { "date", "27-01-2020"},
                    {"name", "Top 5 programming languages in 2020"},
                    {"rating", "5"}
                },
                new BsonDocument
                {
                    {"author", "Svetlin Nakov"},
                    { "date", "02-05-2020"},
                    {"name", "How to write bug-free code"},
                    {"rating", "10"}
                },
                new BsonDocument
                {
                    {"author", "Nikolay Kostov"},
                    { "date", "08-07-2020"},
                    {"name", "Set up your very own web server!"},
                    {"rating", "20"}
                },
                new BsonDocument
                {
                    {"author", "Elon Musk"},
                    {"date", "17-04-2020"},
                    {"name", "The future of space travel"},
                    {"rating", "50"}
                },
                new BsonDocument
                {
                    {"author", "Alen Paunov"},
                    {"date", "10-07-2020"},
                    {"name", "How to manage effectively"},
                    {"rating", "50"}
                },
                        };

            collection.InsertMany(articles);
        }
    }
}
