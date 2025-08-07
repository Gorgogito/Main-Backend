using Main.Application.DTO.Request;
using Main.Application.DTO.Response;
using Main.Cross.Common;

namespace Main.Application.Interface
{
    public interface IRoleApplication
    {

        #region Métodos Síncronos

        Response<bool> Insert(RequestDtoRole_Insert request);
        Response<bool> Update(RequestDtoRole_Update request);
        Response<bool> Delete(RequestDtoRole_Delete request);
        Response<ResponseDtoRole> GetById(RequestDtoRole_GetById request);
        Response<IEnumerable<ResponseDtoRole>> List();
        Response<IEnumerable<ResponseDtoRole>> ListWithPagination(RequestDtoRole_ListWithPagination request);

        #endregion

    }
}
