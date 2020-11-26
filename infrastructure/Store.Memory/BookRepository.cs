using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "ISDN 123-123456711", "D. Kohut", "Art pf Programming", "Description for a great book!",17.5m),
            new Book(2, "ISDN 123-123456712", "S. Something", "Refactoring", "Description for a perfect book!",15m),
            new Book(3, "ISDN 123-123456713", "L. Stek","C Programming Language","Description for a super book!",10m)
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
        
        public Book GetById(in int id)
        {
            var i = id;
            return books.Single(book => book.Id == i);
        }

      

        public Book[] GetAllByIds(IEnumerable<int> bookIds)
        {
            var foundBooks = from book in books
                join bookId in bookIds on book.Id equals bookId
                select book;
            // foundBooks.Select(book => bookIds.Where(i => book.Id == i));
            return foundBooks.ToArray();
        }
    }
}