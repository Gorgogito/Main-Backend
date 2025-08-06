using Main.Domain.Entity.Resource;

namespace Main.Domain.Interface
{
    public interface IProgramDomain
    {

        #region Métodos Síncronos

        bool Insert(Program entity);
        bool Update(Program entity);
        bool Delete(string code);
        Program? GetById(string code);
        IEnumerable<Program>? GetByGroupMenu(string codeGroupMenu);
        IEnumerable<Program>? GetByMenu(string codeMenu);
        IEnumerable<Program>? ListWithPagination(int pageNumber, int pageSize);
        IEnumerable<Program>? List();

        #endregion

        #region Métodos Asíncronos

        Task<bool> InsertAsync(Program entity);
        Task<bool> UpdateAsync(Program entity);
        Task<bool> DeleteAsync(string code);
        Task<Program?> GetByIdAsync(string code);
        Task<IEnumerable<Program>?> GetByGroupMenuAsync(string codeGroupMenu);
        Task<IEnumerable<Program>?> GetByMenuAsync(string codeMenu);
        Task<IEnumerable<Program>?> ListWithPaginationAsync(int pageNumber, int pageSize);
        Task<IEnumerable<Program>?> ListAsync();

        #endregion

    }
}
