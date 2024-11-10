namespace Books.Models

{

    

    public class Book
    {
        public int Id { get; set; }              // Primary Key
        public string Title { get; set; }         // Book title
        public string ISBN { get; set; }          // ISBN number
        public DateTime PublishDate { get; set; } // Publication date
        public double Price { get; set; }        // Price

        // Foreign Key to Author
        public int? AuthorId { get; set; } // Nullable Foreign Key to Author
        public Author Author { get; set; }        // Navigation property

        // Optional additional properties
        public string Genre { get; set; }         // Book genre
        public string Summary { get; set; }       // Short summary or description
    }

}
