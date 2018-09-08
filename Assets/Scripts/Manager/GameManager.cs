using Rehab.Services;
using UnityEngine;

namespace Rehab.Manager
{
    public class GameManager : MonoBehaviour
    {
        public static IAuthorizationService AuthorizationService { get { return Services.AuthorizationService; } }
        public static IDatabaseService DatabaseService { get { return Services.DatabaseService; } }

        public static ServicesManager Services;

        private static bool created = false;

        private void Awake()
        {
            if (!created)
            {
                DontDestroyOnLoad(this.gameObject);
                created = true;

                Services = new ServicesManager();
            }
        }
    }
}
