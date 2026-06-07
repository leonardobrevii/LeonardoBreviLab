using System.ComponentModel.DataAnnotations;

namespace BookManager.Models
{
    public class Books
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Author { get; set; }

        public int Year { get; set; }
        public int? CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}