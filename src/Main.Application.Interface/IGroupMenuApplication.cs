using Main.Application.DTO.Request;
using Main.Application.DTO.Response;
using Main.Cross.Common;

namespace Main.Application.Interface
{
    public interface IGroupMenuApplication
    {

        #region Métodos Síncronos

        Response<bool> Insert(RequestDtoGroupMenu_Insert request);
        Response<bool> Update(RequestDtoGroupMenu_Update request);
        Response<bool> Delete(RequestDtoGroupMenu_Delete request);
        Response<ResponseDtoGroupMenu> GetById(RequestDtoGroupMenu_GetById request);
        Response<IEnumerable<ResponseDtoGroupMenu>> List();
        Response<IEnumerable<ResponseDtoGroupMenu>> ListWithPagination(RequestDtoGroupMenu_ListWithPagination request);

        #endregion

        #region Métodos Asíncronos

        Task<Response<bool>> InsertAsync(RequestDtoGroupMenu_Insert request);
        Task<Response<bool>> UpdateAsync(RequestDtoGroupMenu_Update request);
        Task<Response<bool>> DeleteAsync(RequestDtoGroupMenu_Delete request);
        Task<Response<ResponseDtoGroupMenu>> GetByIdAsync(RequestDtoGroupMenu_GetById request);
        Task<Response<IEnumerable<ResponseDtoGroupMenu>>> ListAsync();
        Task<Response<IEnumerable<ResponseDtoGroupMenu>>> ListWithPaginationAsync(RequestDtoGroupMenu_ListWithPagination request);

        #endregion

    }
}
