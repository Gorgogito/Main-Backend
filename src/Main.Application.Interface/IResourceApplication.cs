using Main.Application.DTO.Request;
using Main.Application.DTO.Response;
using Main.Cross.Common;

namespace Main.Application.Interface
{
    public interface IResourceApplication
    {

        #region Métodos Síncronos

        Response<bool> Insert(RequestDtoResource_Insert request);
        Response<bool> Update(RequestDtoResource_Update request);
        Response<bool> Delete(RequestDtoResource_Delete request);
        Response<ResponseDtoResource> GetById(RequestDtoResource_GetById request);
        Response<IEnumerable<ResponseDtoResource>> List();
        Response<IEnumerable<ResponseDtoResource>> ListWithPagination(RequestDtoResource_ListWithPagination request);

        #endregion

    }
}
