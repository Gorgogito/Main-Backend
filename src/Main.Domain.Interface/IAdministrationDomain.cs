using Main.Domain.Entity.Resource;

namespace Main.Domain.Interface
{
    public interface IAdministrationDomain
    {

        #region Métodos Síncronos

        bool Insert(Administration entity);
        bool Update(Administration entity);
        bool Delete(string codeRole, string codeResource);
        Administration GetById(string codeRole, string codeResource);
        IEnumerable<Administration> GetByRole(string codeRole);
        IEnumerable<Administration> GetByResource(string codeResource);
        IEnumerable<Administration> ListWithPagination(int pageNumber, int pageSize);
        IEnumerable<Administration> List();

        #endregion

        #region Métodos Asíncronos

        Task<bool> InsertAsync(Administration entity);
        Task<bool> UpdateAsync(Administration entity);
        Task<bool> DeleteAsync(string codeRole, string codeResource);
        Task<Administration> GetByIdAsync(string codeRole, string codeResource);
        Task<IEnumerable<Administration>> GetByRoleAsync(string codeRole);
        Task<IEnumerable<Administration>> GetByResourceAsync(string codeResource);
        Task<IEnumerable<Administration>> ListWithPaginationAsync(int pageNumber, int pageSize);
        Task<IEnumerable<Administration>> ListAsync();

        #endregion

    }
}
