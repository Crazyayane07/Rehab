using Rehab.Services;
using UnityEngine;

namespace Rehab
{
    public class MonoBehaviour2 : MonoBehaviour
    {
        protected GameControler Controler { get { return GameControler.Controler; } }

        protected IAuthorizationService AuthorizationService { get { return Controler.Services.AuthorizationService; } } 
        protected IDatabaseService DatabaseService { get { return Controler.Services.DatabaseService; } }

        protected void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}
