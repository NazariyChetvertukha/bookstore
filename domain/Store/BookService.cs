namespace Store
{
    public class BookService
    {
        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public Book[] GetAllByQuery(string query)
        {
            return Book.IsIsbn(query)
                ? bookRepository.GetAllByIsdn(query)
                : bookRepository.GetAllByTitleOrAuthor(query);
        }
    }
}