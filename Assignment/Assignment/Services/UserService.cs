using Assignment.Model.Domain;
using Assignment.Model.RequestDto;
using Assignment.Model.ResponseDto;
using Assignment.Repositories;
using Assignment.Repositories.RelationalRepository;
using Assignment.Utility;

namespace Assignment.Services
{
    public class UserService : IUserService
    {
        private readonly RepositoryFactory<User> _repositoryFactory;

        public UserService(RepositoryFactory<User> repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public async Task<ResponseModel> AddAsync(User model)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedResponseModel<User>> GetAllAsync(UserListDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> GetByIdAsync(int id)
        {
            try
            {
                return Utilities.GetSuccessMsg("");
            }
            catch (Exception ex)
            {
                return Utilities.GetErrorMsg(ex.Message);
            }
        }

        public Task<ResponseModel> UpdateAsync(int id, User model)
        {
            throw new NotImplementedException();
        }
    }
}
