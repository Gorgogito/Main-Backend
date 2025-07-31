using Main.Domain.Entity.Resource;
using Main.Domain.Interface;
using Main.Infrastructure.Interface;

namespace Main.Domain.Core
{
    public class AccessControlDomain : IAccessControlDomain
    {

        private readonly IAccessControlRepository _repository;

        public AccessControlDomain(IAccessControlRepository repository)
        {
            _repository = repository;
        }

        #region Métodos Síncronos

        public bool Insert(AccessControl entity)
        {
            return _repository.Insert(entity);
        }

        public bool Update(AccessControl entity)
        {
            return _repository.Update(entity);
        }

        public bool Delete(string code)
        {
            return _repository.Delete(code);
        }

        public AccessControl GetById(string code)
        {
            return _repository.GetById(code);
        }

        public IEnumerable<AccessControl> GetByResource(string codeResource)
        {
            return _repository.GetByResource(codeResource);
        }

        public IEnumerable<AccessControl> GetByProgram(string codeProgram)
        {
            return _repository.GetByProgram(codeProgram);
        }

        public IEnumerable<AccessControl> List()
        {
            return _repository.List();
        }

        public IEnumerable<AccessControl> ListWithPagination(int pageNumber, int pageSize)
        {
            return _repository.ListWithPagination(pageNumber, pageSize);
        }

        #endregion

        #region Métodos Asíncronos

        public async Task<bool> InsertAsync(AccessControl entity)
        {
            return await _repository.InsertAsync(entity);
        }

        public async Task<bool> UpdateAsync(AccessControl entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(string code)
        {
            return await _repository.DeleteAsync(code);
        }

        public async Task<AccessControl> GetByIdAsync(string code)
        {
            return await _repository.GetByIdAsync(code);
        }

        public async Task<IEnumerable<AccessControl>> GetByResourceAsync(string codeResource)
        {
            return await _repository.GetByResourceAsync(codeResource);
        }

        public async Task<IEnumerable<AccessControl>> GetByProgramAsync(string codeProgram)
        {
            return await _repository.GetByProgramAsync(codeProgram);
        }

        public async Task<IEnumerable<AccessControl>> ListAsync()
        {
            return await _repository.ListAsync();
        }

        public async Task<IEnumerable<AccessControl>> ListWithPaginationAsync(int pageNumber, int pageSize)
        {
            return await _repository.ListWithPaginationAsync(pageNumber, pageSize);
        }

        #endregion

    }
}
