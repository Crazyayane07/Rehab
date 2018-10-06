using Rehab.Model;
using UnityEngine.UI;

namespace Rehab.Popups.Plan
{
    public class ActivityDrag : MonoBehaviour2
    {
        public Image icon;
        private Activity activity;

        public void SetUp(Activity activity)
        {
            this.activity = activity;

            SetUpIcon();
            SetActive(true);
        }

        private void SetUpIcon()
        {
            icon.sprite = activity.Icon;
        }

        public void Hide()
        {
            SetActive(false);
        }
    }
}
