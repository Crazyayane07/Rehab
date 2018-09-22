using Rehab.Services;

namespace Rehab
{
    public class ServicesControler
    {
        public IAuthorizationService AuthorizationService { get; private set; }
        public IDatabaseService DatabaseService { get; private set; }

        public ServicesControler()
        {
            AuthorizationService = new AuthorizationService();
            DatabaseService = new DatabaseService();
        }
    }
}
