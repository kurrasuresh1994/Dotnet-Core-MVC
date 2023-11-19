using System.ComponentModel.DataAnnotations;
namespace Core.BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter the title of the book")]
        public string Title { get; set; }

        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter the author name")]
        public string Author { get; set; }

        [StringLength(500, MinimumLength = 30)]
        public string? Description { get; set; }

        public string? Category { get; set; }

        [Required(ErrorMessage ="Please choose book laguage")]
        public string? Language { get; set; }

        [Display(Name = "Total Pages of book")]
        [Required(ErrorMessage = "Please enter the total pages")]
        public int? TotalPages { get; set; }
    }
}
