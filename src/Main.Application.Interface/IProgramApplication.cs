using Main.Application.DTO.Request;
using Main.Application.DTO.Response;
using Main.Cross.Common;

namespace Main.Application.Interface
{
    public interface IProgramApplication
    {

        #region Métodos Síncronos

        Response<bool> Insert(RequestDtoProgram_Insert request);
        Response<bool> Update(RequestDtoProgram_Update request);
        Response<bool> Delete(RequestDtoProgram_Delete request);
        Response<ResponseDtoProgram> GetById(RequestDtoProgram_GetById request);
        Response<IEnumerable<ResponseDtoProgram>> GetByGroupMenu(RequestDtoProgram_GetByGroupMenu request);
        Response<IEnumerable<ResponseDtoProgram>> GetByMenu(RequestDtoProgram_GetByMenu request);
        Response<IEnumerable<ResponseDtoProgram>> List();
        Response<IEnumerable<ResponseDtoProgram>> ListWithPagination(RequestDtoProgram_ListWithPagination request);

        #endregion

        #region Métodos Asíncronos

        //Task<Response<bool>> InsertAsync(RequestDtoProgram_Insert request);
        //Task<Response<bool>> UpdateAsync(RequestDtoProgram_Update request);
        //Task<Response<bool>> DeleteAsync(RequestDtoProgram_Delete request);
        //Task<Response<ResponseDtoProgram>> GetByIdAsync(RequestDtoProgram_GetById request);
        //Task<Response<IEnumerable<ResponseDtoProgram>>> GetByGroupMenuAsync(RequestDtoProgram_GetByGroupMenu request);
        //Task<Response<IEnumerable<ResponseDtoProgram>>> GetByMenuAsync(RequestDtoProgram_GetByMenu request);
        //Task<Response<IEnumerable<ResponseDtoProgram>>> ListAsync();
        //Task<Response<IEnumerable<ResponseDtoProgram>>> ListWithPaginationAsync(RequestDtoProgram_ListWithPagination request);

        #endregion

    }
}
