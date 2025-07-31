using Main.Domain.Entity.Identy;

namespace Main.Domain.Interface
{
  public interface IAuthenticateDomain
  {

    Authenticate Authenticate(string username, string password);

  }
}
