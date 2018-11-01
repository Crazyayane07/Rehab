using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Rehab.Manager.Plan
{
    public class AnimationMode : MonoBehaviour2
    {
        public Button sendButton;
        public Animator sendTextAnimator;
        public TextMeshProUGUI activeActivityName;
        public TextMeshProUGUI timeText;

        private float planTime;
        private float timePassed;

        private string[] activities;
        private float[] times;

        public void SetUp(float planTime, string[] activities, float[] times)
        {
            this.planTime = planTime * 60;
            this.times = times;
            this.activities = activities;

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
            sendButton.onClick.AddListener(SharePlan);
        }

        private void SharePlan()
        {
            ShareService.SendEmail(activities, times, SetSendTextAnimation);
        }

        private void SetSendTextAnimation()
        {
            sendTextAnimator.SetTrigger(Constans.SEND_TEXT_ANIMATION_TRIGGER);
        }
    }
}
