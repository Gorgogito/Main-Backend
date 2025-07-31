using Main.Domain.Entity.Resource;

namespace Main.Domain.Interface
{
    public interface IMenuDomain
    {

        #region Métodos Síncronos

        bool Insert(Menu entity);
        bool Update(Menu entity);
        bool Delete(string code);
        Menu GetById(string code);
        IEnumerable<Menu> GetByGroupMenu(string codeGroupMenu);
        IEnumerable<Menu> ListWithPagination(int pageNumber, int pageSize);
        IEnumerable<Menu> List();

        #endregion

        #region Métodos Asíncronos

        Task<bool> InsertAsync(Menu entity);
        Task<bool> UpdateAsync(Menu entity);
        Task<bool> DeleteAsync(string code);
        Task<Menu> GetByIdAsync(string code);
        Task<IEnumerable<Menu>> GetByGroupMenuAsync(string codeGroupMenu);
        Task<IEnumerable<Menu>> ListWithPaginationAsync(int pageNumber, int pageSize);
        Task<IEnumerable<Menu>> ListAsync();

        #endregion

    }
}
