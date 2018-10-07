
using System;

namespace Rehab.Popups.Plan
{
    public class PlanHolder : MonoBehaviour2
    {
        public ActivitySlot[] activitySlots;

        private Action onFullySetUp;

        public void ActivateSlots(int activitiesNumber, Action onFullySetUp)
        {
            this.onFullySetUp = onFullySetUp;

            for (int i = 0; i < activitiesNumber && i < activitySlots.Length; i++)
                activitySlots[i].Activate(CheckIfFullySettedUp);
        }

        private void CheckIfFullySettedUp()
        {
            if (AreAllActivitiesSettedUp())
                onFullySetUp();
        }

        private bool AreAllActivitiesSettedUp()
        {
            for (int i = 0; i < activitySlots.Length; i++)
                if (activitySlots[i].isActiveAndEnabled)
                    if (!activitySlots[i].IsReadyToAnimate())
                        return false;
            return true;
        }

        public long GetAnimationTime()
        {
            long time = 0;

            for (int i = 0; i < activitySlots.Length; i++)
                if (activitySlots[i].isActiveAndEnabled)
                    time += activitySlots[i].GetActivityTime();

            return time;
        }

        public void StartAnimationForActivitySlots()
        {
            for (int i = 0; i < activitySlots.Length; i++)
                if (activitySlots[i].isActiveAndEnabled)
                    activitySlots[i].StartAnimation();
        }

        public bool CanStartAnimation()
        {
            for (int i = 0; i < activitySlots.Length; i++)
                if (activitySlots[i].isActiveAndEnabled)
                    if (!activitySlots[i].IsReadyToAnimate())
                        return false;
            return true;
        }
    }
}
