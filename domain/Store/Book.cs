using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Store
{
    public class Book
    {
        public int Id { get; }
        public string Title { get; }

        public string Author { get; }

        public string Isbn { get; }

        public decimal Price { get; }
        
        public string Description { get; }
        public Book(int id, string isbn, string author, string title, string description,decimal price )
        {
            Id = id;
            Title = title;
            Isbn = isbn;
            Author = author;
            Price = price;
            Description = description;
        }

        internal static bool IsIsbn(string s)
        {
            if (s == null)
                return false;

            s = s.Replace("-", "")
                .Replace(" ", "")
                .ToUpper();

            return Regex.IsMatch(s, @"^ISBN\d{10}(\d{3})?$");
        }
    }
}