using Microsoft.EntityFrameworkCore;

namespace EF_CORE_EMPTY_CONTROLLER.Models
{
    public class BookAuthorContext: DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public BookAuthorContext(DbContextOptions<BookAuthorContext> options): base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Connection String
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=Nipun;initial catalog=EFBookAuthor;integrated security=true;trustservercertificate=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Model Setu
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Author>().HasData(
            
                new Author() { AuthId = 11, AuthName = "Robert Baratheon" },
                new Author() { AuthId = 12, AuthName = "Jon Stark"}
               );
            modelBuilder.Entity<Book>()
                .HasData(
                new Book() { BookId = 1, AuthId=11, Title = "Winterfell", Price = 4500, PublicationYear = new DateOnly(2002, 01, 15) },
                new Book() { BookId = 2, AuthId=12, Title = "Vale", Price = 5000, PublicationYear = new DateOnly(2005, 11, 23) }
                );

        }
    }
}
