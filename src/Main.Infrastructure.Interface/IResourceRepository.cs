using Main.Domain.Entity.Resource;

namespace Main.Infrastructure.Interface
{
    public interface IResourceRepository
    {

        #region Métodos Síncronos

        bool Insert(Resource entity);
        bool Update(Resource entity);
        bool Delete(string code);
        Resource? GetById(string code);
        IEnumerable<Resource>? List();
        IEnumerable<Resource>? ListWithPagination(int pageNumber, int pageSize);

        #endregion

    }
}
