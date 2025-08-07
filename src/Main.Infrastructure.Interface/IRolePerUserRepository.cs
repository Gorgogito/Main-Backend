using Main.Domain.Entity.Identy;

namespace Main.Infrastructure.Interface
{
    public interface IRolePerUserRepository
    {

        #region Métodos Síncronos

        bool Insert(RolePerUser entity);
        bool Delete(string userName, string codeRole);
        RolePerUser? GetById(string userName, string codeRole);
        IEnumerable<RolePerUser>? GetByUser(string userName);
        IEnumerable<RolePerUser>? GetByRole(string codeRole);
        IEnumerable<RolePerUser>? List();
        IEnumerable<RolePerUser>? ListWithPagination(int pageNumber, int pageSize);

        #endregion

    }
}
