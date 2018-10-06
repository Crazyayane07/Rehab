using TMPro;
using UnityEngine.UI;

namespace Rehab.Manager.Plan
{
    public class AnimationMode : MonoBehaviour2
    {
        public Button sendButton;
        public TextMeshProUGUI activeActivityName;
        public TextMeshProUGUI timeText;

        private long time;

        public void SetUp(long time)
        {
            this.time = time;

            SetUpButtons();
            SetUpTimeText();

            SetActive(true);
        }

        private void SetUpTimeText()
        {
            timeText.text = time.ToString();
        }

        public void ChangeActiveActivity(string name)
        {
            activeActivityName.text = name;
        }

        private void SetUpButtons()
        {
            //set send button
        }
    }
}
