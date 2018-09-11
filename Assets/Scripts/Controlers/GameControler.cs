using UnityEngine;

namespace Rehab
{
    public class GameControler : MonoBehaviour
    {
        public static GameControler Controler { get; set; }

        public ServicesControler Services;

        private void Awake()
        {
            if (Controler != null)
                return;

            Controler = this;
            Services = new ServicesControler();
            DontDestroyOnLoad(this);
        }
    }
}
