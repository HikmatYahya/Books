using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Collections.Generic;
using Books.Models;

namespace Books.Data
{
    public static class ApplicationDbInitializer
    {
        public static void Seed(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

            // Ensure database is created
            context.Database.EnsureCreated();

            // Seed Authors
            if (!context.Authors.Any())
            {
                var authors = new List<Author>
                {
                    new Author { FirstName = "George", LastName = "Orwell", DateOfBirth = new DateTime(1903, 6, 25), Biography = "Author of 1984 and Animal Farm" },
                    new Author { FirstName = "J.K.", LastName = "Rowling", DateOfBirth = new DateTime(1965, 7, 31), Biography = "Author of the Harry Potter series" },
                    new Author { FirstName = "Jane", LastName = "Austen", DateOfBirth = new DateTime(1775, 12, 16), Biography = "Author of Pride and Prejudice" }
                };

                context.Authors.AddRange(authors);
                context.SaveChanges();
            }

            // Retrieve Author IDs
            var georgeOrwellId = context.Authors.FirstOrDefault(a => a.FirstName == "George" && a.LastName == "Orwell")?.Id;
            var jkRowlingId = context.Authors.FirstOrDefault(a => a.FirstName == "J.K." && a.LastName == "Rowling")?.Id;
            var janeAustenId = context.Authors.FirstOrDefault(a => a.FirstName == "Jane" && a.LastName == "Austen")?.Id;

            // Seed Books
            if (!context.Books.Any())
            {
                var books = new List<Book>
                {
                    new Book
                    {
                        Title = "1984",
                        ISBN = "9780451524935",
                        PublishDate = new DateTime(1949, 6, 8),
                        Price = 15.99m,
                        Genre = "Dystopian",
                        Summary = "A dystopian social science fiction novel.",
                        AuthorId = georgeOrwellId ?? 0 // Use retrieved AuthorId
                    },
                    new Book
                    {
                        Title = "Animal Farm",
                        ISBN = "9780451526342",
                        PublishDate = new DateTime(1945, 8, 17),
                        Price = 12.99m,
                        Genre = "Political Satire",
                        Summary = "A satirical allegory of Soviet totalitarianism.",
                        AuthorId = georgeOrwellId ?? 0
                    },
                    new Book
                    {
                        Title = "Harry Potter and the Sorcerer's Stone",
                        ISBN = "9780439708180",
                        PublishDate = new DateTime(1997, 6, 26),
                        Price = 25.99m,
                        Genre = "Fantasy",
                        Summary = "The first book in the Harry Potter series.",
                        AuthorId = jkRowlingId ?? 0
                    },
                    new Book
                    {
                        Title = "Pride and Prejudice",
                        ISBN = "9780679783268",
                        PublishDate = new DateTime(1813, 1, 28),
                        Price = 18.99m,
                        Genre = "Romance",
                        Summary = "A classic novel of manners.",
                        AuthorId = janeAustenId ?? 0
                    }
                };

                context.Books.AddRange(books);
                context.SaveChanges();
            }
        }
    }
}
