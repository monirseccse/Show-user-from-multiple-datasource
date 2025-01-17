using Assignment.Model.Domain;
using Assignment.Model.RequestDto;
using Assignment.Model.ResponseDto;

namespace Assignment.Services
{
    public interface IUserService
    {
        Task<PaginatedResponseModel<UserOutDto>> GetAllAsync(UserListDto model);
        Task<ResponseModel> GetByIdAsync(int id);
        Task<ResponseModel> AddAsync(User model);
        Task<ResponseModel> UpdateAsync(int id, User model);
        Task<ResponseModel> DeleteAsync(int id);
    }
}
