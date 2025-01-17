using Assignment.Models.RequestDto;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Model.RequestDto
{
    public class UserListDto : PaginationBase
    {
        [FromQuery(Name = "phoneNo")]
        public string? PhoneNo { get; set; }
    }
}
