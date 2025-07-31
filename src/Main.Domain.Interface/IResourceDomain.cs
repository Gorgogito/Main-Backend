using Main.Domain.Entity.Resource;

namespace Main.Domain.Interface
{
    public interface IResourceDomain
    {

        #region Métodos Síncronos

        bool Insert(Resource entity);
        bool Update(Resource entity);
        bool Delete(string code);
        Resource GetById(string code);
        IEnumerable<Resource> ListWithPagination(int pageNumber, int pageSize);
        IEnumerable<Resource> List();

        #endregion

        #region Métodos Asíncronos

        Task<bool> InsertAsync(Resource entity);
        Task<bool> UpdateAsync(Resource entity);
        Task<bool> DeleteAsync(string code);
        Task<Resource> GetByIdAsync(string code);
        Task<IEnumerable<Resource>> ListWithPaginationAsync(int pageNumber, int pageSize);
        Task<IEnumerable<Resource>> ListAsync();

        #endregion

    }
}
