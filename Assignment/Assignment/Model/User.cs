using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public bool Active { get; set; }
        public string? Company { get; set; }
        public string Sex { get; set; } = null!;
        public int? ContactId { get; set; }
        public int? RoleId { get; set; }
        [ForeignKey(nameof(ContactId))]
        public Contact? Contact { get; set; }
        [ForeignKey(nameof(RoleId))]
        public Role? Role { get; set; }
    }
}
