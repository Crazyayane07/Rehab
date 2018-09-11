using Rehab.Services;

namespace Rehab
{
    public class ServicesControler
    {
        public IAuthorizationService AuthorizationService { get; private set; }

        public ServicesControler()
        {
            AuthorizationService = new AuthorizationService();
        }
    }
}
