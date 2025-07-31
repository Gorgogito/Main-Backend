using Main.Domain.Entity.Identy;

namespace Main.Infrastructure.Interface
{
    public interface IAuthenticateRepository
    {

        Authenticate Authenticate(string username, string password);

    }
}
