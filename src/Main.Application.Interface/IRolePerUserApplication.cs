using Main.Application.DTO.Request;
using Main.Application.DTO.Response;
using Main.Cross.Common;

namespace Main.Application.Interface
{
    public interface IRolePerUserApplication
    {

        #region Métodos Síncronos

        Response<bool> Insert(RequestDtoRolePerUser_Insert request);
        Response<bool> Delete(RequestDtoRolePerUser_Delete request);
        Response<ResponseDtoRolePerUser> GetById(RequestDtoRolePerUser_GetById request);
        Response<IEnumerable<ResponseDtoRolePerUser>>? GetByUser(RequestDtoRolePerUser_GetByUser request);
        Response<IEnumerable<ResponseDtoRolePerUser>>? GetByRole(RequestDtoRolePerUser_GetByRole request);
        Response<IEnumerable<ResponseDtoRolePerUser>> List();
        Response<IEnumerable<ResponseDtoRolePerUser>> ListWithPagination(RequestDtoRolePerUser_ListWithPagination request);

        #endregion

    }
}
