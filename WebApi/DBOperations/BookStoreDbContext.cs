using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

namespace WebApi.DBOperations
{
    public class BookStoreDBContext : DbContext //BookStoreDBContext is DbContext now.
    {
        //default ctor  
        public BookStoreDBContext(DbContextOptions<BookStoreDBContext>options):base(options) 
        { }

        public DbSet<Book> Books {get; set;} //we can reach every aspect of Book entity by using Books.
            
    }
}