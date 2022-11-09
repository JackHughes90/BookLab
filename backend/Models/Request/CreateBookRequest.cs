using System.ComponentModel.DataAnnotations;

namespace BookLab.Models.Request
{
    public class CreateBookRequest
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string CoverUrl { get; set; }

        [Required]
        public string Description { get; set; }
    }
}