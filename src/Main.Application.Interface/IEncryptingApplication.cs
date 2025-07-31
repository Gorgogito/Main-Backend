using Main.Cross.Common;

namespace Main.Application.Interface
{
    public interface IEncryptingApplication
    {

        #region Métodos Síncronos

        Response<string> EncryptString(string stringValue);
        Response<string> DecryptString(string stringValue);

        #endregion

        #region Métodos Asíncronos

        Task<Response<string>> EncryptStringAsync(string stringValue);
        Task<Response<string>> DecryptStringAsync(string stringValue);

        #endregion

    }
}
