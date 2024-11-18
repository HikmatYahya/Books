using Books.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Books.Data
{


    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

			// Configure relationships
			modelBuilder.Entity<Book>()
				.HasOne(b => b.Author) // A book has one author
				.WithMany(a => a.Books) // An author has many books
				.HasForeignKey(b => b.AuthorId) // Foreign Key is AuthorId
				.OnDelete(DeleteBehavior.Cascade); // Cascade delete if an author is deleted

		}


		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


        }


    }
}
