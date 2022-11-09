using System.ComponentModel.DataAnnotations;

namespace BookLab.Models.Request
{
    public class CreateGenreRequest
    {
        [Required]
        public string Name { get; set; }
    }
}