using Main.Application.DTO.Request;
using Main.Application.DTO.Response;
using Main.Cross.Common;

namespace Main.Application.Interface
{
    public interface IAccessControlApplication
    {

        #region Métodos Síncronos

        Response<bool> Insert(RequestDtoAccessControl_Insert request);
        Response<bool> Update(RequestDtoAccessControl_Update request);
        Response<bool> Delete(RequestDtoAccessControl_Delete request);
        Response<ResponseDtoAccessControl> GetById(RequestDtoAccessControl_GetById request);
        Response<IEnumerable<ResponseDtoAccessControl>> GetByResource(RequestDtoAccessControl_GetByResource request);
        Response<IEnumerable<ResponseDtoAccessControl>> GetByProgram(RequestDtoAccessControl_GetByProgram request);
        Response<IEnumerable<ResponseDtoAccessControl>> List();
        Response<IEnumerable<ResponseDtoAccessControl>> ListWithPagination(RequestDtoAccessControl_ListWithPagination request);

        #endregion

        #region Métodos Asíncronos

        Task<Response<bool>> InsertAsync(RequestDtoAccessControl_Insert request);
        Task<Response<bool>> UpdateAsync(RequestDtoAccessControl_Update request);
        Task<Response<bool>> DeleteAsync(RequestDtoAccessControl_Delete request);
        Task<Response<ResponseDtoAccessControl>> GetByIdAsync(RequestDtoAccessControl_GetById request);
        Task<Response<IEnumerable<ResponseDtoAccessControl>>> GetByResourceAsync(RequestDtoAccessControl_GetByResource request);
        Task<Response<IEnumerable<ResponseDtoAccessControl>>> GetByProgramAsync(RequestDtoAccessControl_GetByProgram request);
        Task<Response<IEnumerable<ResponseDtoAccessControl>>> ListAsync();
        Task<Response<IEnumerable<ResponseDtoAccessControl>>> ListWithPaginationAsync(RequestDtoAccessControl_ListWithPagination request);

        #endregion

    }
}
