using Assignment.Model.Domain;
using Assignment.Repositories.Factory;
using AutoMapper;

namespace Assignment.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleRepositoryFactory _repositoryFactory;
        private readonly IMapper _mapper;
        public RoleService(RoleRepositoryFactory repositoryFactory, IMapper mapper)
        {
            _repositoryFactory = repositoryFactory;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Role>> GetRoles()
        {
            var repository = _repositoryFactory.GetRepository();
            return await repository.GetRoles();
        }
    }
}
