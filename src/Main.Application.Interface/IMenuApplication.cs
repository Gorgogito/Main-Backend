using Main.Application.DTO.Request;
using Main.Application.DTO.Response;
using Main.Cross.Common;

namespace Main.Application.Interface
{
    public interface IMenuApplication
    {

        #region Métodos Síncronos

        Response<bool> Insert(RequestDtoMenu_Insert request);
        Response<bool> Update(RequestDtoMenu_Update request);
        Response<bool> Delete(RequestDtoMenu_Delete request);
        Response<ResponseDtoMenu> GetById(RequestDtoMenu_GetById request);
        Response<IEnumerable<ResponseDtoMenu>> GetByGroupMenu(RequestDtoMenu_GetByGroupMenu request);
        Response<IEnumerable<ResponseDtoMenu>> List();
        Response<IEnumerable<ResponseDtoMenu>> ListWithPagination(RequestDtoMenu_ListWithPagination request);

        #endregion

        #region Métodos Asíncronos

        Task<Response<bool>> InsertAsync(RequestDtoMenu_Insert request);
        Task<Response<bool>> UpdateAsync(RequestDtoMenu_Update request);
        Task<Response<bool>> DeleteAsync(RequestDtoMenu_Delete request);
        Task<Response<ResponseDtoMenu>> GetByIdAsync(RequestDtoMenu_GetById request);
        Task<Response<IEnumerable<ResponseDtoMenu>>> GetByGroupMenuAsync(RequestDtoMenu_GetByGroupMenu request);
        Task<Response<IEnumerable<ResponseDtoMenu>>> ListAsync();
        Task<Response<IEnumerable<ResponseDtoMenu>>> ListWithPaginationAsync(RequestDtoMenu_ListWithPagination request);

        #endregion

    }
}
