using Assignment.Models.RequestDto;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Model.RequestDto
{
    public class UserListDto : PaginationBase
    {
        [FromQuery(Name = "lastName")]
        public string? LastName { get; set; }
    }
}
