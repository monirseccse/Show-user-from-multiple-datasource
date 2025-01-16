namespace Assignment.Model
{
    public class Contact
    {
        public int Id { get; set; }
        public string Phone { get; set; } = null!;
        public string? Address { get; set; }
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
    }
}
