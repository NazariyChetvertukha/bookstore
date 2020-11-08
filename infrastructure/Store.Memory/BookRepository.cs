using System;
using System.Linq;
using System.Linq.Expressions;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "ISDN 123-123456711", "D. Kohut", "Art pf Programming"),
            new Book(2, "ISDN 123-123456712", "S. Something", "Refactoring"),
            new Book(3, "ISDN 123-123456713", "L. Stek","C Programming Language")
        };

        public Book[] GetAllByTitle(string titlePart)
        {
            return books.Where(book => book.Title.Contains(titlePart))
                .ToArray();
        }

        public Book[] GetAllByIsdn(string isbn)
        {
            return books.Where(book => book.Isbn == isbn)
                .ToArray();
        }
        
        public Book[] GetAllByTitleOrAuthor(string query)
        {
            return books.Where(book => book.Author.Contains(query)
                                    || book.Title.Contains(query))
                .ToArray();
        }
    }
}