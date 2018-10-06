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
            var activities = ContentService.GetActivities();

            for (int i = 0; i < activitiesDrag.Length && i < activities.Count; i++)
                activitiesDrag[i].SetUp(new Model.Activity(activities[i].activityName, activities[i].icon));
            for (int j = activities.Count; j < activitiesDrag.Length; j++)
                activitiesDrag[j].Hide();

        }
    }
}
