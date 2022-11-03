using System.Collections.Generic;

namespace BookLab.Models.Database
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CoverUrl { get; set; }
        public string Description { get; set; }
        public List<Author> Authors { get; set; }
        public List<Genre> Genres { get; set; }

    }
}