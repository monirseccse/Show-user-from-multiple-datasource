using Assignment.Model.Domain;
using Assignment.Model.RequestDto;
using Assignment.Model.ResponseDto;
using Assignment.Repositories;
using Assignment.Repositories.NoSqlRepository;
using Assignment.Repositories.RelationalRepository;
using Assignment.Utility;
using AutoMapper;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Assignment.Services
{
    public class UserService : IUserService
    {
        private readonly RepositoryFactory _repositoryFactory;
        private readonly MongoRepository _mongoRepository;
        private readonly IMapper _mapper;

        public UserService(RepositoryFactory repositoryFactory, IMapper mapper, MongoRepository mongoRepository)
        {
            _repositoryFactory = repositoryFactory;
            _mapper = mapper;
            _mongoRepository = mongoRepository;
        }

        public async Task<ResponseModel> AddAsync(User model)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PaginatedResponseModel<UserOutDto>> GetAllAsync(UserListDto model)
        {
            try
            {
                var repository = _repositoryFactory.GetRepository();
                var paginatedResponse = new PaginatedResponseModel<UserOutDto>();
                var findall = await repository.GetAllAsync(null,
                    (model.PageNumber-1)*model.ItemsPerPage,model.ItemsPerPage);
                paginatedResponse.Items = _mapper.Map<List<UserOutDto>>(findall);
                paginatedResponse.TotalItems = 5;
                paginatedResponse.TotalPages =(int)Math.Ceiling((double)paginatedResponse.TotalItems / model.ItemsPerPage);
                paginatedResponse.PageNumber = model.PageNumber;
                paginatedResponse.ItemsPerPage = model.ItemsPerPage;
                return paginatedResponse;
            }
            catch (Exception ex)
            {
                return new PaginatedResponseModel<UserOutDto>();
            }
        }

        public async Task<ResponseModel> GetByIdAsync(int id)
        {
            try
            {
                var repository = _repositoryFactory.GetRepository();
                var user = await repository.GetByIdAsync(id);
                if (user is null)
                    return Utilities.GetNoDataFoundMsg("User not found");

                return Utilities.GetSuccessMsg("",user);
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
