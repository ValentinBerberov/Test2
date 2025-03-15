using System.ComponentModel.DataAnnotations;

namespace Test2.Web.Data.Entity
{
    public class BaseEntity
    {
        [Key]
        public int ID { get; set; }
    }
}
