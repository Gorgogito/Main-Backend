using Main.Domain.Entity.Resource;

namespace Main.Infrastructure.Interface
{
    public interface IResourceRepository
    {

        #region Métodos Síncronos

        bool Insert(Resource entity);
        bool Update(Resource entity);
        bool Delete(string code);
        Resource GetById(string code);
        IEnumerable<Resource> List();
        IEnumerable<Resource> ListWithPagination(int pageNumber, int pageSize);

        #endregion

        #region Métodos Asíncronos

        Task<bool> InsertAsync(Resource entity);
        Task<bool> UpdateAsync(Resource entity);
        Task<bool> DeleteAsync(string code);
        Task<Resource> GetByIdAsync(string code);
        Task<IEnumerable<Resource>> ListAsync();
        Task<IEnumerable<Resource>> ListWithPaginationAsync(int pageNumber, int pageSize);

        #endregion

    }
}
