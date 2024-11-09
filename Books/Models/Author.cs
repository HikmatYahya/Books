namespace Books.Models
{
    public class Author
    {
        public int Id { get; set; }                    // Primary Key
        public string FirstName { get; set; }          // Author's first name
        public string LastName { get; set; }           // Author's last name
        public DateTime DateOfBirth { get; set; }      // Author's date of birth
        public string Biography { get; set; }          // Short biography

        // Navigation property to support one-to-many relationship with books
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }

}
