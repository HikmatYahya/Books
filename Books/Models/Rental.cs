using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Rental
{
    public int Id { get; set; }

    [Required]
    public int BookId { get; set; }

    [Required]
    public string UserId { get; set; } // Foreign Key to IdentityUser

    [Required]
    public DateTime RentedOn { get; set; }

    public DateTime DueDate { get; set; }

    public DateTime? ReturnedOn { get; set; }

    [ForeignKey("BookId")]
    public Book Book { get; set; }

    [ForeignKey("UserId")]
    public IdentityUser User { get; set; } // Reference to the user
}
