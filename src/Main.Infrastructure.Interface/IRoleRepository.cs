using Main.Domain.Entity.Identy;

namespace Main.Infrastructure.Interface
{
    public interface IRoleRepository
    {

        #region Métodos Síncronos

        bool Insert(Role entity);
        bool Update(Role entity);
        bool Delete(string code);
        Role? GetById(string code);
        IEnumerable<Role>? List();
        IEnumerable<Role>? ListWithPagination(int pageNumber, int pageSize);

        #endregion

    }
}
