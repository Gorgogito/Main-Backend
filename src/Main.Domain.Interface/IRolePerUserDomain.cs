using Main.Domain.Entity.Identy;

namespace Main.Domain.Interface
{
    public interface IRolePerUserDomain
    {

        #region Métodos Síncronos

        bool Insert(RolePerUser entity);
        bool Delete(string userName, string codeRole);
        RolePerUser? GetById(string userName, string codeRole);
        IEnumerable<RolePerUser>? GetByUser(string userName);
        IEnumerable<RolePerUser>? GetByRole(string codeRole);
        IEnumerable<RolePerUser>? ListWithPagination(int pageNumber, int pageSize);
        IEnumerable<RolePerUser>? List();

        #endregion

    }
}
