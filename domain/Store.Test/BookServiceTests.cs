using Moq;
using  Xunit;
namespace Store.Test
{
    public class BookServiceTests
    {
        [Fact]
        public void GetAllByQuery_WithIsbn_CallGetAllByIsbn()
        {
            var bookRepositoryStub = new Mock<IBookRepository>();
            bookRepositoryStub.Setup(x => x.GetAllByIsdn(It.IsAny<string>()))
                .Returns(new[] {new Book(1, "", "", "", "",0m),});
            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                .Returns(new[] {new Book(2, "", "", "","", 0m)});
            
            var bookService = new BookService(bookRepositoryStub.Object);

            var validIsbn = "ISBN 1234-567890";
            var actual = bookService.GetAllByQuery(validIsbn);
            
            Assert.Collection(actual, book => Assert.Equal(1, book.Id));
        }
        
        [Fact]
        public void GetAllByQuery_WithIsbn_CallGetAllByTitleOrAuthor()
        {
            var bookRepositoryStub = new Mock<IBookRepository>();
            bookRepositoryStub.Setup(x => x.GetAllByIsdn(It.IsAny<string>()))
                .Returns(new[] {new Book(1, "", "", "", "",0m),});
            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                .Returns(new[] {new Book(2, "", "", "", "",0m)});
            
            
            var bookService = new BookService(bookRepositoryStub.Object);

            var invalidIsbn = "D. Kohut";
            var actual = bookService.GetAllByQuery(invalidIsbn);
            
            Assert.Collection(actual, book => Assert.Equal(2, book.Id));
        }
    }
}