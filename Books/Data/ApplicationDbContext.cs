using Books.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Books.Data
{


    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public DbSet<Rental> Rentals { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author) // A book has one author
                .WithMany(a => a.Books) // An author has many books
                .HasForeignKey(b => b.AuthorId) // Foreign Key is AuthorId
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete if an author is deleted




            modelBuilder.Entity<Rental>(entity =>
            {
                entity.HasKey(r => r.Id);

                // Configure the foreign key relationship with Book
                entity.HasOne(r => r.Book)
                      .WithMany(b => b.Rentals)
                      .HasForeignKey(r => r.BookId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


        }


    }
}
