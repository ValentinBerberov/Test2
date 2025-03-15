using System.ComponentModel.DataAnnotations.Schema;

namespace Test2.Web.Data.Entity
{
    public class BookGenre
    {
        [ForeignKey(nameof(Book))]
        public int BookID { get; set; }
        public virtual Book? Book { get; set; }
        [ForeignKey(nameof(Genre))]
        public int GenreID { get; set; }
        public virtual Genre? Genre { get; set; }
    }
}
