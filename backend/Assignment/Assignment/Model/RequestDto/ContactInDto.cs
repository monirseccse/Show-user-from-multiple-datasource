namespace Assignment.Model.RequestDto
{
    public class ContactInDto
    {
        public string Phone { get; set; } = null!;
        public string? Address { get; set; }
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
    }
}
