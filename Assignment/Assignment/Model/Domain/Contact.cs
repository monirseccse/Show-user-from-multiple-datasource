namespace Assignment.Model.Domain
{
    public class Contact : BaseEntity
    {
        public string Phone { get; set; } = null!;
        public string? Address { get; set; }
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
    }
}
