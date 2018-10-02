using Rehab.Model;
using TMPro;
using UnityEngine.UI;

namespace Rehab.Popups.Plan
{
    public class ActivitySlot : MonoBehaviour2
    {
        public TMP_InputField timeField;
        public Image activityImage;

        private Activity activity;

        public void SetUp()
        {
            SetActive(true);
        }

        public long GetActivityTime()
        {
            return long.Parse(timeField.text);
        }

        public void StartAnimation()
        {

        }
    }
}
