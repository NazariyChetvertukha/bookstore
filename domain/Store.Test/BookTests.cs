using System;
using Xunit;

namespace Store.Test
{
    public class BookTests
    {
        [Fact]
        public void IsIsbn_WithNull_ReturnFalse()
        {
            bool actual = Book.IsIsbn(null);
            
            Assert.False(actual);
        }
        
        [Fact]
        public void IsIsbn_WithBlankString_ReturnFalse()
        {
            bool actual = Book.IsIsbn("   ");
            
            Assert.False(actual);
        }
        
        [Fact]
        public void IsIsbn_WithIsbn10_ReturnTrue()
        {
            bool actual = Book.IsIsbn("ISBN 123-456-789 0");
            
            Assert.True(actual);
        }
        
        [Fact]
        public void IsIsbn_WithInvalidIsbn_ReturnFalse()
        {
            bool actual = Book.IsIsbn("1234567890");
            
            Assert.False(actual);
        }
        
        [Fact]
        public void IsIsbn_WithIsbn13_ReturnTrue()
        {
            bool actual = Book.IsIsbn("ISBN 123-456-789 0123");
            
            Assert.True(actual);
        }
        
        [Fact]
        public void IsIsbn_WithTrashStartSymbols_ReturnFalse()
        {
            bool actual = Book.IsIsbn(" xxxx ISBN 123-456-789 0123 yyyy");

            Assert.False(actual);
        }

    }
}