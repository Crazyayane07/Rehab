using UnityEngine;

namespace Rehab
{
    public class GameController : MonoBehaviour
    {
        public static GameController Controler { get; set; }

        public ServicesController Services;

        private void Awake()
        {
            if (Controler != null)
                return;

            Controler = this;
            Services = new ServicesController();
            DontDestroyOnLoad(this);
        }
    }
}
