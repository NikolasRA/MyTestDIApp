using System.Data.Entity;

namespace MvvmLightTest
{
    public class DB : DbContext
    {
        public DB()
            : base("name=DB")
        {
        }

        public virtual DbSet<Books> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>()
                .Property(e => e.Author)
                .IsUnicode(false);

            modelBuilder.Entity<Books>()
                .Property(e => e.Book)
                .IsUnicode(false);
        }
    }
}