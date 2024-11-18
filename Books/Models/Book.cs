﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Models
{
	public class Book
	{
		public int Id { get; set; } // Primary Key

		[Required]
		public string Title { get; set; }

		public string ISBN { get; set; }

		public DateTime PublishDate { get; set; }

		public decimal Price { get; set; }

		[Required]
		public int AuthorId { get; set; } // Foreign Key for Author

		public string Genre { get; set; }

		public string Summary { get; set; }

		// Navigation property
		[ForeignKey("AuthorId")]
		public Author Author { get; set; } // Author object
	}
}
