using Main.Domain.Entity.Identy;
using Main.Domain.Interface;
using Main.Infrastructure.Interface;

namespace Main.Domain.Core
{
  public class AuthenticateDomain: IAuthenticateDomain
  {

        private readonly IAuthenticateRepository _authenticateRepository;

        public AuthenticateDomain(IAuthenticateRepository authenticateRepository)
        {
            _authenticateRepository = authenticateRepository;
        }

        public Authenticate Authenticate(string userName, string password)
        {
            return _authenticateRepository.Authenticate(userName, password);
        }

    }
}
