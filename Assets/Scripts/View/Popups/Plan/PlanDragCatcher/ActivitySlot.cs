using System;
using Rehab.Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Rehab.Popups.Plan
{
    public class ActivitySlot : MonoBehaviour2
    {
        public TMP_InputField timeField;
        public Image activityImage;
        public ActivityTimer timer;

        public ActivitySlot neighbour;
        public Animator animator;

        private Activity activity;

        private Action onSetUp;
        private Action<string> onAnimationStart;

        public void Activate(Action onSetUp, Action<string> onAnimationStart)
        {
            this.onSetUp = onSetUp;
            this.onAnimationStart = onAnimationStart;

            SetActive(true);
        }

        public bool IsReadyToAnimate()
        {
            return activity != null && timeField.text != "";
        }

        public void SetUp(Activity activity)
        {
            this.activity = activity;

            onSetUp();
            SetUpIcon();

            timeField.onValueChanged.AddListener(OnChangeTime);
        }

        private void OnChangeTime(string time)
        {            
            onSetUp();
        }

        private void SetUpIcon()
        {
            activityImage.sprite = activity.Icon;
        }

        public long GetActivityTime()
        {
            return long.Parse(timeField.text);
        }

        public void StartAnimation()
        {
            onAnimationStart(activity.ActivityName);
            timer.SetUp(float.Parse(timeField.text), OnTimerEnd);
            timeField.interactable = false;
            animator.SetTrigger(Constans.ACTIVITY_SLOT_SHOW);
        }

        private void OnTimerEnd()
        {
            if(neighbour != null)
            {
                if (neighbour.isActiveAndEnabled)
                    neighbour.StartAnimation();
                else
                    onAnimationStart(Constans.ANIMATION_PLAN_END);
                SetInactiveAnimation();
            }
        }

        public void SetInactiveAnimation()
        {
            timeField.interactable = false;
            animator.SetTrigger(Constans.ACTIVITY_SLOT_HIDE);
        }
    }
}
