using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Rehab.Manager.Plan
{
    public class AnimationMode : MonoBehaviour2
    {
        public Button sendButton;
        public TextMeshProUGUI activeActivityName;
        public TextMeshProUGUI timeText;

        private float planTime;
        private float timePassed;

        public void SetUp(float planTime)
        {
            this.planTime = planTime*60;

            SetUpButtons();
            SetUpTimeText();

            SetActive(true);
        }

        private void Update()
        {
            if (timePassed < planTime)
            {
                timePassed += Time.deltaTime;
                SetUpTimeText();
            }
        }

        private void SetUpTimeText()
        {
            timeText.text = TimeService.TranslateTime(timePassed);
        }

        public void ChangeActiveActivity(string name)
        {
            activeActivityName.text = name;
        }

        private void SetUpButtons()
        {
            //set share button
        }
    }
}
