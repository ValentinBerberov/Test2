using Humanizer.Localisation;

namespace Test2.Web.Data.Entity
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public int AuthorID { get; set; }
        public virtual Author? Author { get; set; }
        public virtual ICollection<BookGenre>? BookGenres { get; set; } = new List<BookGenre>();
    }
}
