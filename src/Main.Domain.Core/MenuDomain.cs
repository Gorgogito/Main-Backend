using Main.Domain.Entity.Resource;
using Main.Domain.Interface;
using Main.Infrastructure.Interface;

namespace Main.Domain.Core
{
    public class MenuDomain: IMenuDomain
    {

        private readonly IMenuRepository _repository;

        public MenuDomain(IMenuRepository repository)
        {
            _repository = repository;
        }

        #region Métodos Síncronos

        public bool Insert(Menu entity)
        {
            return _repository.Insert(entity);
        }

        public bool Update(Menu entity)
        {
            return _repository.Update(entity);
        }

        public bool Delete(string code)
        {
            return _repository.Delete(code);
        }

        public Menu GetById(string code)
        {
            return _repository.GetById(code);
        }

        public IEnumerable<Menu> GetByGroupMenu(string codeGroupMenu)
        {
            return _repository.GetByGroupMenu(codeGroupMenu);
        }

        public IEnumerable<Menu> List()
        {
            return _repository.List();
        }

        public IEnumerable<Menu> ListWithPagination(int pageNumber, int pageSize)
        {
            return _repository.ListWithPagination(pageNumber, pageSize);
        }

        #endregion

        #region Métodos Asíncronos

        public async Task<bool> InsertAsync(Menu entity)
        {
            return await _repository.InsertAsync(entity);
        }

        public async Task<bool> UpdateAsync(Menu entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(string code)
        {
            return await _repository.DeleteAsync(code);
        }

        public async Task<Menu> GetByIdAsync(string code)
        {
            return await _repository.GetByIdAsync(code);
        }

        public async Task<IEnumerable<Menu>> GetByGroupMenuAsync(string codeGroupMenu)
        {
            return await _repository.GetByGroupMenuAsync(codeGroupMenu);
        }

        public async Task<IEnumerable<Menu>> ListAsync()
        {
            return await _repository.ListAsync();
        }

        public async Task<IEnumerable<Menu>> ListWithPaginationAsync(int pageNumber, int pageSize)
        {
            return await _repository.ListWithPaginationAsync(pageNumber, pageSize);
        }

        #endregion

    }
}
