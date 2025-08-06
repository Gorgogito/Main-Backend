using Main.Domain.Entity.Resource;
using Main.Domain.Interface;
using Main.Infrastructure.Interface;

namespace Main.Domain.Core
{
    public class GroupMenuDomain: IGroupMenuDomain
    {

        private readonly IGroupMenuRepository _repository;

        public GroupMenuDomain(IGroupMenuRepository repository)
        {
            _repository = repository;
        }

        #region Métodos Síncronos

        public bool Insert(GroupMenu entity)
        {
            return _repository.Insert(entity);
        }

        public bool Update(GroupMenu entity)
        {
            return _repository.Update(entity);
        }

        public bool Delete(string code)
        {
            return _repository.Delete(code);
        }

        public GroupMenu GetById(string code)
        {
            return _repository.GetById(code);
        }

        public IEnumerable<GroupMenu> List()
        {
            return _repository.List();
        }

        public IEnumerable<GroupMenu> ListWithPagination(int pageNumber, int pageSize)
        {
            return _repository.ListWithPagination(pageNumber, pageSize);
        }

        #endregion

        #region Métodos Asíncronos

        public async Task<bool> InsertAsync(GroupMenu entity)
        {
            return await _repository.InsertAsync(entity);
        }

        public async Task<bool> UpdateAsync(GroupMenu entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(string code)
        {
            return await _repository.DeleteAsync(code);
        }

        public async Task<GroupMenu> GetByIdAsync(string code)
        {
            return await _repository.GetByIdAsync(code);
        }

        public async Task<IEnumerable<GroupMenu>> ListAsync()
        {
            return await _repository.ListAsync();
        }

        public async Task<IEnumerable<GroupMenu>> ListWithPaginationAsync(int pageNumber, int pageSize)
        {
            return await _repository.ListWithPaginationAsync(pageNumber, pageSize);
        }

        #endregion

    }
}
