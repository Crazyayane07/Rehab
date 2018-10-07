using Rehab.Services;

namespace Rehab
{
    public class ServicesController
    {
        public IAuthorizationService AuthorizationService { get; private set; }
        public IDatabaseService DatabaseService { get; private set; }
        public IUserService UserService { get; private set; }
        public IScenesService ScenesService { get; private set; }
        public IContentService ContentService { get; private set; }
        public ITimeService TimeService { get; private set; }

        public ServicesController()
        {
            AuthorizationService = new AuthorizationService();
            DatabaseService = new DatabaseService();
            UserService = new UserService();
            ScenesService = new ScenesService();
            ContentService = new ContentService();
            TimeService = new TimeService();
        }
    }
}
