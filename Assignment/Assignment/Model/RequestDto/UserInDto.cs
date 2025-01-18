namespace Assignment.Model.RequestDto
{
    public class UserInDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public bool Active { get; set; }
        public string? Company { get; set; }
        public string Sex { get; set; } = null!;
        public RoleInDto Role { get; set; }
        public ContactInDto Contact { get; set; }
    }
}
