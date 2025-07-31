using Main.Domain.Entity.Identy;

namespace Main.Infrastructure.Interface
{
    public interface IRolePerUserRepository
    {

        #region Métodos Síncronos

        bool Insert(RolePerUser entity);
        bool Update(RolePerUser entity);
        bool Delete(string userName, string codeRole);
        RolePerUser GetById(string userName, string codeRole);
        IEnumerable<RolePerUser> GetByUser(string userName);
        IEnumerable<RolePerUser> GetByRole(string codeRole);
        IEnumerable<RolePerUser> List();
        IEnumerable<RolePerUser> ListWithPagination(int pageNumber, int pageSize);

        #endregion

        #region Métodos Asíncronos

        Task<bool> InsertAsync(RolePerUser entity);
        Task<bool> UpdateAsync(RolePerUser entity);
        Task<bool> DeleteAsync(string userName, string codeRole);
        Task<RolePerUser> GetByIdAsync(string userName, string codeRole);
        Task<IEnumerable<RolePerUser>> GetByUserAsync(string userName);
        Task<IEnumerable<RolePerUser>> GetByRoleAsync(string codeRole);
        Task<IEnumerable<RolePerUser>> ListAsync();
        Task<IEnumerable<RolePerUser>> ListWithPaginationAsync(int pageNumber, int pageSize);

        #endregion

    }
}
