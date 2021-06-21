namespace P00.ComperatorDemo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {

            Book bookOne = new Book("Harry Potter and The Goblet of Fire", 2000, "J.K. Rowling");
            Book bookTwo = new Book("Origin", 2010, "Dan Brown");
            Book bookThree = new Book("The 7 Habits of Highly Effective People", 2013, "Stephen Covey");
            Book bookFour = new Book("Harry Potter and The Prisoner of Azkaban", 2007, "J.K. Rowling");

            var listOfBooks = new List<Book>() { bookTwo, bookThree, bookOne, bookFour };

            listOfBooks.Sort();

            foreach (var book in listOfBooks)
            {
                Console.WriteLine(book.Title + $" {book.Year}");
            }
        }
    }
}
