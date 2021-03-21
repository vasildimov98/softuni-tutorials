using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Followers
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;
            Dictionary<string, int> comments = new Dictionary<string, int>();
            Dictionary<string, int> likes = new Dictionary<string, int>();
            while ((command = Console.ReadLine()) != "Log out")
            {
                string[] data = command
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries);

                string action = data[0];

                if (action == "New follower")
                {
                    string username = data[1];

                    if (!comments.ContainsKey(username))
                    {
                        comments[username] = 0;
                        likes[username] = 0;
                    }
                }
                else if (action == "Like")
                {
                    string username = data[1];
                    int count = int.Parse(data[2]);

                    if (!likes.ContainsKey(username))
                    {
                        likes[username] = 0;
                        comments[username] = 0;
                    }

                    likes[username] += count;
                }
                else if (action == "Comment")
                {
                    string username = data[1];
                    if (!comments.ContainsKey(username))
                    {
                        likes[username] = 0;
                        comments[username] = 0;
                    }
                    comments[username]++;
                }
                else if (action == "Blocked")
                {
                    string username = data[1];
                    if (comments.ContainsKey(username))
                    {
                        comments.Remove(username);
                        likes.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"{username} doesn't exist.");
                    }
                }
            }

            Console.WriteLine($"{comments.Keys.Count()} followers");
            foreach (var username in likes.OrderByDescending(a => a.Value))
            {
                Console.WriteLine($"{username.Key}: {username.Value + comments[username.Key]}");
            }
        }
    }
}
