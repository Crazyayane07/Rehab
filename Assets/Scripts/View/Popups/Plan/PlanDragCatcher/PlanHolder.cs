
using System;
using System.Collections.Generic;

namespace Rehab.Popups.Plan
{
    public class PlanHolder : MonoBehaviour2
    {
        public ActivitySlot[] activitySlots;

        private Action onFullySetUp;

        public void ActivateSlots(int activitiesNumber, Action onFullySetUp, Action<string> onAnimationSlotStart)
        {
            this.onFullySetUp = onFullySetUp;

            for (int i = 0; i < activitiesNumber && i < activitySlots.Length; i++)
                activitySlots[i].Activate(CheckIfFullySettedUp, onAnimationSlotStart);
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

        public float[] GetTimes()
        {
            List<float> times = new List<float>();

            for (int i = 0; i < activitySlots.Length; i++)
                if (activitySlots[i].isActiveAndEnabled)
                    times.Add(activitySlots[i].GetTime());

            return times.ToArray();
        }

        public string[] GetActivityNames()
        {
            List<string> names = new List<string>();

            for (int i = 0; i < activitySlots.Length; i++)
                if (activitySlots[i].isActiveAndEnabled)
                    names.Add(activitySlots[i].GetActivityName());

            return names.ToArray();
        }

        public void StartAnimationForActivitySlots()
        {
            activitySlots[0].StartAnimation();

            for (int i = 1; i < activitySlots.Length; i++)
                if (activitySlots[i].isActiveAndEnabled)
                    activitySlots[i].SetInactiveAnimation();
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
