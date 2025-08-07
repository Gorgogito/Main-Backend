using Main.Domain.Entity.Resource;

namespace Main.Domain.Interface
{
    public interface IResourceDomain
    {

        #region Métodos Síncronos

        bool Insert(Resource entity);
        bool Update(Resource entity);
        bool Delete(string code);
        Resource? GetById(string code);
        IEnumerable<Resource>? ListWithPagination(int pageNumber, int pageSize);
        IEnumerable<Resource>? List();

        #endregion

    }
}
