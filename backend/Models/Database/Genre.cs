using System.Collections.Generic;

namespace BookLab.Models.Database
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}