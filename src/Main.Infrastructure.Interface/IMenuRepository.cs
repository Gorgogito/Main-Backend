using Main.Domain.Entity.Resource;

namespace Main.Infrastructure.Interface
{
    public interface IMenuRepository
    {

        #region Métodos Síncronos

        bool Insert(Menu entity);
        bool Update(Menu entity);
        bool Delete(string code);
        Menu GetById(string code);
        IEnumerable<Menu> GetByGroupMenu(string codeGroupMenu);
        IEnumerable<Menu> List();
        IEnumerable<Menu> ListWithPagination(int pageNumber, int pageSize);

        #endregion

        #region Métodos Asíncronos

        Task<bool> InsertAsync(Menu entity);
        Task<bool> UpdateAsync(Menu entity);
        Task<bool> DeleteAsync(string code);
        Task<Menu> GetByIdAsync(string code);
        Task<IEnumerable<Menu>> GetByGroupMenuAsync(string codeGroupMenu);
        Task<IEnumerable<Menu>> ListAsync();
        Task<IEnumerable<Menu>> ListWithPaginationAsync(int pageNumber, int pageSize);

        #endregion

    }
}
