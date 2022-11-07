using System.ComponentModel.DataAnnotations;

namespace BookLab.Models.Request
{
    public class CreateAuthorRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}