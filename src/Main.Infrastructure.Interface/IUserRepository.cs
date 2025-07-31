using Main.Domain.Entity.Identy;

namespace Main.Infrastructure.Interface
{
    public interface IUserRepository
    {

        #region Métodos Síncronos

        bool Insert(User entity);
        bool Update(User entity);
        bool Delete(string userName);
        User GetById(string userName);
        IEnumerable<User> List();
        IEnumerable<User> ListWithPagination(int pageNumber, int pageSize);

        #endregion

        #region Métodos Asíncronos

        Task<bool> InsertAsync(User entity);
        Task<bool> UpdateAsync(User entity);
        Task<bool> DeleteAsync(string userName);
        Task<User> GetByIdAsync(string userName);
        Task<IEnumerable<User>> ListAsync();
        Task<IEnumerable<User>> ListWithPaginationAsync(int pageNumber, int pageSize);

        #endregion

    }
}