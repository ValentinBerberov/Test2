namespace Test2.Web.Data.Entity
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<BookGenre>? BookGenres { get; set; } = new List<BookGenre>();
    }
}
