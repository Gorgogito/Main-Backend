using Main.Domain.Entity.Resource;
using Main.Domain.Interface;
using Main.Infrastructure.Interface;

namespace Main.Domain.Core
{
    public class ProgramDomain: IProgramDomain
    {

        private readonly IProgramRepository _repository;

        public ProgramDomain(IProgramRepository repository)
        {
            _repository = repository;
        }

        #region Métodos Síncronos

        public bool Insert(Program entity)
        {
            return _repository.Insert(entity);
        }

        public bool Update(Program entity)
        {
            return _repository.Update(entity);
        }

        public bool Delete(string code)
        {
            return _repository.Delete(code);
        }

        public Program? GetById(string code)
        {
            return _repository.GetById(code);
        }

        public IEnumerable<Program>? GetByGroupMenu(string codeGroupMenu)
        {
            return _repository.GetByGroupMenu(codeGroupMenu);
        }

        public IEnumerable<Program>? GetByMenu(string codeMenu)
        {
            return _repository.GetByMenu(codeMenu);
        }

        public IEnumerable<Program>? List()
        {
            return _repository.List();
        }

        public IEnumerable<Program>? ListWithPagination(int pageNumber, int pageSize)
        {
            return _repository.ListWithPagination(pageNumber, pageSize);
        }

        #endregion

        #region Métodos Asíncronos

        public async Task<bool> InsertAsync(Program entity)
        {
            return await _repository.InsertAsync(entity);
        }

        public async Task<bool> UpdateAsync(Program entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(string code)
        {
            return await _repository.DeleteAsync(code);
        }

        public async Task<Program?> GetByIdAsync(string code)
        {
            return await _repository.GetByIdAsync(code);
        }

        public async Task<IEnumerable<Program>?> GetByGroupMenuAsync(string codeGroupMenu)
        {
            return await _repository.GetByGroupMenuAsync(codeGroupMenu);
        }

        public async Task<IEnumerable<Program>?> GetByMenuAsync(string codeMenu)
        {
            return await _repository.GetByMenuAsync(codeMenu);
        }

        public async Task<IEnumerable<Program>?> ListAsync()
        {
            return await _repository.ListAsync();
        }

        public async Task<IEnumerable<Program>?> ListWithPaginationAsync(int pageNumber, int pageSize)
        {
            return await _repository.ListWithPaginationAsync(pageNumber, pageSize);
        }

        #endregion

    }
}
