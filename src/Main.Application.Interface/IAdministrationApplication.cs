using Main.Application.DTO.Request;
using Main.Application.DTO.Response;
using Main.Cross.Common;

namespace Main.Application.Interface
{
    public interface IAdministrationApplication
    {

        #region Métodos Síncronos

        Response<bool> Insert(RequestDtoAdministration_Insert request);
        Response<bool> Update(RequestDtoAdministration_Update request);
        Response<bool> Delete(RequestDtoAdministration_Delete request);
        Response<ResponseDtoAdministration> GetById(RequestDtoAdministration_GetById request);
        Response<IEnumerable<ResponseDtoAdministration>> GetByResource(RequestDtoAdministration_GetByResource request);
        Response<IEnumerable<ResponseDtoAdministration>> GetByRole(RequestDtoAdministration_GetByRole request);
        Response<IEnumerable<ResponseDtoAdministration>> List();
        Response<IEnumerable<ResponseDtoAdministration>> ListWithPagination(RequestDtoAdministration_ListWithPagination request);

        #endregion

        #region Métodos Asíncronos

        Task<Response<bool>> InsertAsync(RequestDtoAdministration_Insert request);
        Task<Response<bool>> UpdateAsync(RequestDtoAdministration_Update request);
        Task<Response<bool>> DeleteAsync(RequestDtoAdministration_Delete request);
        Task<Response<ResponseDtoAdministration>> GetByIdAsync(RequestDtoAdministration_GetById request);
        Task<Response<IEnumerable<ResponseDtoAdministration>>> GetByResourceAsync(RequestDtoAdministration_GetByResource request);
        Task<Response<IEnumerable<ResponseDtoAdministration>>> GetByRoleAsync(RequestDtoAdministration_GetByRole request);
        Task<Response<IEnumerable<ResponseDtoAdministration>>> ListAsync();
        Task<Response<IEnumerable<ResponseDtoAdministration>>> ListWithPaginationAsync(RequestDtoAdministration_ListWithPagination request);

        #endregion

    }
}
