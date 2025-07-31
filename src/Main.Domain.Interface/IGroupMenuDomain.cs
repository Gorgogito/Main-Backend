using Main.Domain.Entity.Resource;

namespace Main.Domain.Interface
{
    public interface IGroupMenuDomain
    {

        #region Métodos Síncronos

        bool Insert(GroupMenu entity);
        bool Update(GroupMenu entity);
        bool Delete(string code);
        GroupMenu GetById(string code);
        IEnumerable<GroupMenu> ListWithPagination(int pageNumber, int pageSize);
        IEnumerable<GroupMenu> List();

        #endregion

        #region Métodos Asíncronos

        Task<bool> InsertAsync(GroupMenu entity);
        Task<bool> UpdateAsync(GroupMenu entity);
        Task<bool> DeleteAsync(string code);
        Task<GroupMenu> GetByIdAsync(string code);
        Task<IEnumerable<GroupMenu>> ListWithPaginationAsync(int pageNumber, int pageSize);
        Task<IEnumerable<GroupMenu>> ListAsync();

        #endregion

    }
}
