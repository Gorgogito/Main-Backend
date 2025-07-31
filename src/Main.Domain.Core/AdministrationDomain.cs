using Main.Domain.Entity.Resource;
using Main.Infrastructure.Interface;
using Main.Domain.Interface;

namespace Main.Domain.Core
{
    public class AdministrationDomain : IAdministrationDomain
    {

        private readonly IAdministrationRepository _repository;

        public AdministrationDomain(IAdministrationRepository repository)
        {
            _repository = repository;
        }

        #region Métodos Síncronos

        public bool Insert(Administration entity)
        {
            return _repository.Insert(entity);
        }

        public bool Update(Administration entity)
        {
            return _repository.Update(entity);
        }

        public bool Delete(string codeRole, string codeResource)
        {
            return _repository.Delete(codeRole, codeResource);
        }

        public Administration GetById(string codeRole, string codeResource)
        {
            return _repository.GetById(codeRole, codeResource);
        }

        public IEnumerable<Administration> GetByResource(string codeResource)
        {
            return _repository.GetByResource(codeResource);
        }

        public IEnumerable<Administration> GetByRole(string codeProgram)
        {
            return _repository.GetByRole(codeProgram);
        }

        public IEnumerable<Administration> List()
        {
            return _repository.List();
        }

        public IEnumerable<Administration> ListWithPagination(int pageNumber, int pageSize)
        {
            return _repository.ListWithPagination(pageNumber, pageSize);
        }

        #endregion

        #region Métodos Asíncronos

        public async Task<bool> InsertAsync(Administration entity)
        {
            return await _repository.InsertAsync(entity);
        }

        public async Task<bool> UpdateAsync(Administration entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(string codeRole, string codeResource)
        {
            return await _repository.DeleteAsync(codeRole, codeResource);
        }

        public async Task<Administration> GetByIdAsync(string codeRole, string codeResource)
        {
            return await _repository.GetByIdAsync(codeRole, codeResource);
        }

        public async Task<IEnumerable<Administration>> GetByResourceAsync(string codeResource)
        {
            return await _repository.GetByResourceAsync(codeResource);
        }

        public async Task<IEnumerable<Administration>> GetByRoleAsync(string codeProgram)
        {
            return await _repository.GetByRoleAsync(codeProgram);
        }

        public async Task<IEnumerable<Administration>> ListAsync()
        {
            return await _repository.ListAsync();
        }

        public async Task<IEnumerable<Administration>> ListWithPaginationAsync(int pageNumber, int pageSize)
        {
            return await _repository.ListWithPaginationAsync(pageNumber, pageSize);
        }

        #endregion

    }
}
