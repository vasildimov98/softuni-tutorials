﻿namespace BookShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Author
    {
        public Author()
        {
            this.Books = new HashSet<Book>();
        }

        public int AuthorId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [ConcurrencyCheck]
        public decimal? EarnedMoney { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}