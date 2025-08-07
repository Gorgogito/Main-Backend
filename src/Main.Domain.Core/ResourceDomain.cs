using Main.Domain.Entity.Resource;
using Main.Domain.Interface;
using Main.Infrastructure.Interface;

namespace Main.Domain.Core
{
    public class ResourceDomain: IResourceDomain
    {

        private readonly IResourceRepository _repository;

        public ResourceDomain(IResourceRepository repository)
        {
            _repository = repository;
        }

        #region Métodos Síncronos

        public bool Insert(Resource entity)
        {
            return _repository.Insert(entity);
        }

        public bool Update(Resource entity)
        {
            return _repository.Update(entity);
        }

        public bool Delete(string code)
        {
            return _repository.Delete(code);
        }

        public Resource? GetById(string code)
        {
            return _repository.GetById(code);
        }

        public IEnumerable<Resource>? List()
        {
            return _repository.List();
        }

        public IEnumerable<Resource>? ListWithPagination(int pageNumber, int pageSize)
        {
            return _repository.ListWithPagination(pageNumber, pageSize);
        }

        #endregion

    }
}
