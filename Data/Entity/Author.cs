namespace Test2.Web.Data.Entity
{
    public class Author : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual List<Book>? Books { get; set; }
        public string GetFullName() { return FirstName + " " + LastName; }
    }
}
