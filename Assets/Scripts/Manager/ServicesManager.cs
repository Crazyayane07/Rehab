using Rehab.Services;

namespace Rehab.Manager
{
    public class ServicesManager
    {
        public IAuthorizationService AuthorizationService { get; private set; }
        public IDatabaseService DatabaseService { get; private set; }

        public ServicesManager()
        {
            AuthorizationService = new AuthorizationService();
            DatabaseService = new DatabaseService();
        }
    }
}
