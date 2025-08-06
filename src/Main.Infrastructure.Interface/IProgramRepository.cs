using Main.Domain.Entity.Resource;

namespace Main.Infrastructure.Interface
{
    public interface IProgramRepository
    {

        #region Métodos Síncronos

        bool Insert(Program entity);
        bool Update(Program entity);
        bool Delete(string code);
        Program? GetById(string code);
        IEnumerable<Program>? GetByGroupMenu(string codeGroupMenu);
        IEnumerable<Program>? GetByMenu(string codeMenu);
        IEnumerable<Program>? List();
        IEnumerable<Program>? ListWithPagination(int pageNumber, int pageSize);

        #endregion

        #region Métodos Asíncronos

        Task<bool> InsertAsync(Program entity);
        Task<bool> UpdateAsync(Program entity);
        Task<bool> DeleteAsync(string code);
        Task<Program?> GetByIdAsync(string code);
        Task<IEnumerable<Program>?> GetByGroupMenuAsync(string codeGroupMenu);
        Task<IEnumerable<Program>?> GetByMenuAsync(string codeMenu);
        Task<IEnumerable<Program>?> ListAsync();
        Task<IEnumerable<Program>?> ListWithPaginationAsync(int pageNumber, int pageSize);

        #endregion

    }
}
