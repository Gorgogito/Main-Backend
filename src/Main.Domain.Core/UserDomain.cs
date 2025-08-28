using Main.Domain.Entity.Identy;
using Main.Domain.Interface;
using Main.Infrastructure.Interface;

namespace Main.Domain.Core
{
    public class UserDomain : IUserDomain
    {

        private readonly IUserRepository _usersRepository;

        public UserDomain(IUserRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        #region Métodos Síncronos

        public bool Insert(User entity)
        {
            return _usersRepository.Insert(entity);
        }

        public bool Update(User entity)
        {
            return _usersRepository.Update(entity);
        }

        public bool Delete(string userName)
        {
            return _usersRepository.Delete(userName);
        }

        public User GetById(string userName)
        {
            return _usersRepository.GetById(userName);
        }

        public IEnumerable<User> List()
        {
            return _usersRepository.List();
        }

        public IEnumerable<User> ListWithPagination(int pageNumber, int pageSize)
        {
            return _usersRepository.ListWithPagination(pageNumber, pageSize);
        }

        public bool ResetPassword(User entity)
        {
            return _usersRepository.ResetPassword(entity);
        }

        #endregion

        #region Métodos Asíncronos

        public async Task<bool> InsertAsync(User entity)
        {
            return await _usersRepository.InsertAsync(entity);
        }

        public async Task<bool> UpdateAsync(User entity)
        {
            return await _usersRepository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(string userName)
        {
            return await _usersRepository.DeleteAsync(userName);
        }

        public async Task<User> GetByIdAsync(string userName)
        {
            return await _usersRepository.GetByIdAsync(userName);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _usersRepository.ListAsync();
        }

        public async Task<IEnumerable<User>> ListWithPaginationAsync(int pageNumber, int pageSize)
        {
            return await _usersRepository.ListWithPaginationAsync(pageNumber, pageSize);
        }

        #endregion

    }
}