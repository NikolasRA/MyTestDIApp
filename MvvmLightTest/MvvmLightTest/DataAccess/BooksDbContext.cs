using System.Data.Entity;
using MvvmLightTest.Data;

namespace MvvmLightTest.DataAccess
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext()
            : base("name=BooksDatabase") { }

        public virtual DbSet<Book> Books { get; set; }
    }
}
