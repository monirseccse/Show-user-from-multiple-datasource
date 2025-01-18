using System.ComponentModel.DataAnnotations;

namespace Assignment.Model.Domain
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
