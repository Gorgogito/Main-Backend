using Main.Domain.Entity.Resource;

namespace Main.Domain.Interface
{
    public interface IAccessControlDomain
    {

        #region Métodos Síncronos

        bool Insert(AccessControl entity);
        bool Update(AccessControl entity);
        bool Delete(string code);
        AccessControl GetById(string code);
        IEnumerable<AccessControl> GetByResource(string codeResource);
        IEnumerable<AccessControl> GetByProgram(string codeProgram);
        IEnumerable<AccessControl> ListWithPagination(int pageNumber, int pageSize);
        IEnumerable<AccessControl> List();

        #endregion

        #region Métodos Asíncronos

        Task<bool> InsertAsync(AccessControl entity);
        Task<bool> UpdateAsync(AccessControl entity);
        Task<bool> DeleteAsync(string code);
        Task<AccessControl> GetByIdAsync(string code);
        Task<IEnumerable<AccessControl>> GetByResourceAsync(string codeResource);
        Task<IEnumerable<AccessControl>> GetByProgramAsync(string codeProgram);
        Task<IEnumerable<AccessControl>> ListWithPaginationAsync(int pageNumber, int pageSize);
        Task<IEnumerable<AccessControl>> ListAsync();

        #endregion

    }
}
