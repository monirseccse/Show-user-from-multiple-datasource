using Assignment.Model.Domain;
using Assignment.Model.RequestDto;
using Assignment.Model.ResponseDto;
using Assignment.Repositories.Factory;
using Assignment.Repositories.NoSqlRepository;
using Assignment.Repositories.RelationalRepository;
using Assignment.Utility;
using AutoMapper;
using System.Collections.Generic;
using System.Linq.Expressions;
using static Assignment.Constants.AppConstants;

namespace Assignment.Services
{
    public class UserService : IUserService
    {
        private readonly RepositoryFactory _repositoryFactory;
        private readonly IMapper _mapper;

        public UserService(RepositoryFactory repositoryFactory, IMapper mapper)
        {
            _repositoryFactory = repositoryFactory;
            _mapper = mapper;
        }

        public async Task<ResponseModel> AddAsync(UserInDto model)
        {
            try
            {
                var repository = _repositoryFactory.GetRepository();
                var entity = _mapper.Map<User>(model);
                await repository.AddAsync(entity);
                return Utilities.GetSuccessMsg(CommonMessage.SavedSuccessfully.ToString());
            }
            catch (Exception ex)
            {
                return Utilities.GetErrorMsg(ex.Message);
            }
        }

        public async Task<ResponseModel> DeleteAsync(int id)
        {
            try
            {
                var repository = _repositoryFactory.GetRepository();
                var user = await repository.GetByIdAsync(id, x => x.Contact);
                if (user is null)
                    return Utilities.GetNoDataFoundMsg("User not found");
                await repository.DeleteAsync(id);
                return Utilities.GetSuccessMsg(CommonMessage.DeletedSuccessfully.ToString());
            }
            catch (Exception ex)
            {
                return Utilities.GetErrorMsg(ex.Message);
            }
        }

        public async Task<PaginatedResponseModel<UserListOutDto>> GetAllAsync(UserListDto model)
        {
            try
            {
                var repository = _repositoryFactory.GetRepository();
                var paginatedResponse = new PaginatedResponseModel<UserListOutDto>();
                Expression<Func<User, bool>> filters = null;

                if (!string.IsNullOrWhiteSpace(model.LastName))
                {
                    filters = user => user.LastName.Contains(model.LastName);
                }

                var findall = await repository.GetAllAsync(filters,
                    (model.PageNumber-1)*model.ItemsPerPage,model.ItemsPerPage);
                paginatedResponse.Items = _mapper.Map<List<UserListOutDto>>(findall);
                paginatedResponse.TotalItems = 5;
                paginatedResponse.TotalPages =(int)Math.Ceiling((double)paginatedResponse.TotalItems / model.ItemsPerPage);
                paginatedResponse.PageNumber = model.PageNumber;
                paginatedResponse.ItemsPerPage = model.ItemsPerPage;
                return paginatedResponse;
            }
            catch (Exception ex)
            {
                return new PaginatedResponseModel<UserListOutDto>();
            }
        }

        public async Task<ResponseModel> GetByIdAsync(int id)
        {
            try
            {
                var repository = _repositoryFactory.GetRepository();
                var user = await repository.GetByIdAsync(id, x=> x.Contact, x => x.Role);
                if (user is null)
                    return Utilities.GetNoDataFoundMsg("User not found");
                var userOutDto = _mapper.Map<UserOutDto>(user);
                return Utilities.GetSuccessMsg("", userOutDto);
            }
            catch (Exception ex)
            {
                return Utilities.GetErrorMsg(ex.Message);
            }
        }

        public async Task<ResponseModel> UpdateAsync(int id, UserInDto model)
        {
            try
            {
                var repository = _repositoryFactory.GetRepository();
                var user = await repository.GetByIdAsync(id, x => x.Contact, x=> x.Role);
                if (user is null)
                    return Utilities.GetNoDataFoundMsg("User not found");
                var entity =_mapper.Map(model,user);
                await repository.UpdateAsync(entity);
                return Utilities.GetSuccessMsg(CommonMessage.UpdatedSuccessfully.ToString());

            }
            catch (Exception ex)
            {
                return Utilities.GetErrorMsg(ex.Message);
            }   
        }
    }
}
