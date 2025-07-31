using Main.Domain.Entity.Identy;

namespace Main.Domain.Interface
{
    public interface IRoleDomain
    {

        #region Métodos Síncronos

        bool Insert(Role entity);
        bool Update(Role entity);
        bool Delete(string code);
        Role GetById(string code);
        IEnumerable<Role> ListWithPagination(int pageNumber, int pageSize);
        IEnumerable<Role> List();

        #endregion

        #region Métodos Asíncronos

        Task<bool> InsertAsync(Role entity);
        Task<bool> UpdateAsync(Role entity);
        Task<bool> DeleteAsync(string code);
        Task<Role> GetByIdAsync(string code);
        Task<IEnumerable<Role>> ListWithPaginationAsync(int pageNumber, int pageSize);
        Task<IEnumerable<Role>> ListAsync();

        #endregion

    }
}
