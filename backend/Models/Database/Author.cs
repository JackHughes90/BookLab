using System.Collections.Generic;

namespace BookLab.Models.Database
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
        public string Description { get; set; }
    }
}