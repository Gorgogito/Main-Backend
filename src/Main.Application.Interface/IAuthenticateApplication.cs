using Main.Application.DTO.Response;
using Main.Cross.Common;

namespace Main.Application.Interface
{
    public interface IAuthenticateApplication
  {

    Response<ResponseDtoAuthenticate> Authenticate(string username, string password);

  }
}
