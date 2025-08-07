using Main.Domain.Entity.Identy;
using Main.Domain.Interface;
using Main.Infrastructure.Interface;

namespace Main.Domain.Core
{
    public class RolePerUserDomain: IRolePerUserDomain
    {

        private readonly IRolePerUserRepository _repository;

        public RolePerUserDomain(IRolePerUserRepository repository)
        {
            _repository = repository;
        }

        #region Métodos Síncronos

        public bool Insert(RolePerUser entity)
        {
            return _repository.Insert(entity);
        }

        public bool Delete(string userName, string codeRole)
        {
            return _repository.Delete(userName, codeRole);
        }

        public RolePerUser? GetById(string userName, string codeRole)
        {
            return _repository.GetById(userName, codeRole);
        }

        public IEnumerable<RolePerUser>? GetByUser(string userName)
        {
            return _repository.GetByUser(userName);
        }

        public IEnumerable<RolePerUser>? GetByRole(string codeRole)
        {
            return _repository.GetByRole(codeRole);
        }

        public IEnumerable<RolePerUser>? List()
        {
            return _repository.List();
        }

        public IEnumerable<RolePerUser>? ListWithPagination(int pageNumber, int pageSize)
        {
            return _repository.ListWithPagination(pageNumber, pageSize);
        }

        #endregion

    }
}
