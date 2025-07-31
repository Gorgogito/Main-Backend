using Main.Domain.Entity.Resource;

namespace Main.Infrastructure.Interface
{
    public interface IGroupMenuRepository
    {

        #region Métodos Síncronos

        bool Insert(GroupMenu entity);
        bool Update(GroupMenu entity);
        bool Delete(string code);
        GroupMenu GetById(string code);
        IEnumerable<GroupMenu> List();
        IEnumerable<GroupMenu> ListWithPagination(int pageNumber, int pageSize);

        #endregion

        #region Métodos Asíncronos

        Task<bool> InsertAsync(GroupMenu entity);
        Task<bool> UpdateAsync(GroupMenu entity);
        Task<bool> DeleteAsync(string code);
        Task<GroupMenu> GetByIdAsync(string code);
        Task<IEnumerable<GroupMenu>> ListAsync();
        Task<IEnumerable<GroupMenu>> ListWithPaginationAsync(int pageNumber, int pageSize);

        #endregion

    }
}
