﻿using Core.BookStore.Enums;
using Core.BookStore.Helpers;
using System.ComponentModel.DataAnnotations;
namespace Core.BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        //[MyCustomValidation("MVC")]
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter the title of the book")]
        public string Title { get; set; }

        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter the author name")]
        public string Author { get; set; }

        [StringLength(500, MinimumLength = 30)]
        public string? Description { get; set; }

        public string? Category { get; set; }

        [Required(ErrorMessage = "Please choose the book laguage")]
        public int LanguageId { get; set; }

        public string? Language { get; set; }

        [Display(Name = "Total Pages of book")]
        [Required(ErrorMessage = "Please enter the total pages")]
        public int? TotalPages { get; set; }

        [Display(Name = "Choose the cover photo of book")]
        [Required]
        public IFormFile CoverPhoto { get; set; }

        public string? CoverImageUrl { get; set; }

        [Display(Name = "Choose the gallery images of your book")]
        [Required]
        public IFormFileCollection GalleryFiles { get; set; }

        public List<GalleryModel>? Gallery { get; set; }

        [Display(Name = "Upload your book in pdf format")]
        [Required]
        public IFormFile BookPdf { get; set; }

        public string? BookPdfUrl { get; set; }
    }
}
