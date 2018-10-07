using System;
using UnityEngine;
using UnityEngine.UI;

namespace Rehab.Popups.Plan
{
    public class ActivityTimer : MonoBehaviour2
    {
        public Image progressBar;
        private Action onTimerEnd;
        private float activityTime;
        private float timeLeft;

        public void SetUp(float activityTime, Action onTimerEnd)
        {
            this.onTimerEnd = onTimerEnd;
            this.activityTime = activityTime;

            timeLeft = activityTime * 60;
            progressBar.fillAmount = 0;

            SetActive(true);
        }

        private void Update()
        {
            timeLeft -= Time.deltaTime; 

            if(timeLeft <= 0)
            {
                TimerEnd();
                return;
            }

            UpdateImage();
        }

        private void UpdateImage()
        {
            float toFill = ((activityTime*60) - timeLeft) / (activityTime*60);
            progressBar.fillAmount = toFill;
        }

        private void TimerEnd()
        {
            SetActive(false);
            onTimerEnd();
        }
    }
}
