using Main.Domain.Entity.Identy;

namespace Main.Domain.Interface
{
    public interface IRoleDomain
    {

        #region Métodos Síncronos

        bool Insert(Role entity);
        bool Update(Role entity);
        bool Delete(string code);
        Role? GetById(string code);
        IEnumerable<Role>? ListWithPagination(int pageNumber, int pageSize);
        IEnumerable<Role>? List();

        #endregion

    }
}
