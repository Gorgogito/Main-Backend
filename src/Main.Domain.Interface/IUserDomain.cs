using Main.Domain.Entity.Identy;

namespace Main.Domain.Interface
{
    public interface IUserDomain
    {

        #region Métodos Síncronos

        bool Insert(User entity);
        bool Update(User entity);
        bool Delete(string userName);
        User GetById(string userName);
        IEnumerable<User> ListWithPagination(int pageNumber, int pageSize);
        IEnumerable<User> List();
        bool ResetPassword(User entity);

        #endregion

        #region Métodos Asíncronos

        Task<bool> InsertAsync(User entity);
        Task<bool> UpdateAsync(User entity);
        Task<bool> DeleteAsync(string userName);
        Task<User> GetByIdAsync(string userName);
        Task<IEnumerable<User>> ListWithPaginationAsync(int pageNumber, int pageSize);
        Task<IEnumerable<User>> ListAsync();

        #endregion

    }
}
