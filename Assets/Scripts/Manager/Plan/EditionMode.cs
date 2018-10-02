using System;
using Rehab.Popups.Plan;
using UnityEngine.UI;

namespace Rehab.Manager.Plan
{
    public class EditionMode : MonoBehaviour2
    {
        public ActivityDrag[] activitiesDrag;
        public Button startAnimation;

        private Action onStartAnimation;

        public void SetUp(Action onStartAnimation)
        {
            this.onStartAnimation = onStartAnimation;

            SetUpActivities();
            SetUpButton();

            SetActive(true);
        }

        private void SetUpButton()
        {
            startAnimation.onClick.AddListener(StartAnimation);
        }

        private void StartAnimation()
        {
            onStartAnimation();

            SetActive(false);
        }

        private void SetUpActivities()
        {
            for (int i = 0; i < activitiesDrag.Length; i++)
                activitiesDrag[i].SetUp();
        }
    }
}
