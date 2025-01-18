using Assignment.Model.Domain;

namespace Assignment.Model.ResponseDto
{
    public class UserOutDto : BaseOutDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public bool Active { get; set; }
        public string? Company { get; set; }
        public string Sex { get; set; } = null!;
        public Contact? Contact { get; set; }
        public Role? Role { get; set; }
    }
}
