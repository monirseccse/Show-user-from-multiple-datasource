using Assignment.Model.Domain;
using Assignment.Model.RequestDto;
using Assignment.Model.ResponseDto;

namespace Assignment.Services
{
    public interface IUserService
    {
        Task<PaginatedResponseModel<UserListOutDto>> GetAllAsync(UserListDto model);
        Task<ResponseModel> GetByIdAsync(int id);
        Task<ResponseModel> AddAsync(UserInDto model);
        Task<ResponseModel> UpdateAsync(int id, UserInDto model);
        Task<ResponseModel> DeleteAsync(int id);
    }
}
