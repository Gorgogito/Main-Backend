using Main.Domain.Entity.Identy;
using Main.Domain.Entity.Resource;
using Main.Domain.Interface;
using Main.Infrastructure.Interface;

namespace Main.Domain.Core
{
    public class RoleDomain: IRoleDomain
    {

        private readonly IRoleRepository _repository;

        public RoleDomain(IRoleRepository repository)
        {
            _repository = repository;
        }

        #region Métodos Síncronos

        public bool Insert(Role entity)
        {
            return _repository.Insert(entity);
        }

        public bool Update(Role entity)
        {
            return _repository.Update(entity);
        }

        public bool Delete(string code)
        {
            return _repository.Delete(code);
        }

        public Role? GetById(string code)
        {
            return _repository.GetById(code);
        }

        public IEnumerable<Role>? List()
        {
            return _repository.List();
        }

        public IEnumerable<Role>? ListWithPagination(int pageNumber, int pageSize)
        {
            return _repository.ListWithPagination(pageNumber, pageSize);
        }

        #endregion

    }
}
