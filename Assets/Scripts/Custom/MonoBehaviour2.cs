using Rehab.Services;
using UnityEngine;

namespace Rehab
{
    public class MonoBehaviour2 : MonoBehaviour
    {
        protected GameController Controler { get { return GameController.Controler; } }

        protected IAuthorizationService AuthorizationService { get { return Controler.Services.AuthorizationService; } }
        protected IDatabaseService DatabaseService { get { return Controler.Services.DatabaseService; } }
        protected IUserService UserService { get { return Controler.Services.UserService; } }
        protected IScenesService ScenesService { get { return Controler.Services.ScenesService; } }
        protected IContentService ContentService { get { return Controler.Services.ContentService; } }
        protected ITimeService TimeService { get { return Controler.Services.TimeService; } }

        protected void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}
