using System;
using Rehab.Manager.Plan;
using Rehab.Popups.Plan;
using UnityEngine.UI;

namespace Rehab.Manager
{
    public class PlanMaker : MonoBehaviour2
    {
        public Button backToUserMenu;

        public AnimationMode animationMode;
        public EditionMode editonMode;
        public PlanMakerPopup popup;

        public ActivitySlot[] activitySlots;

        private void Start()
        {
            popup.SetUp(SetUpActivitySlots);
            editonMode.SetUp(OnAnimationStart);

            SetUpButtons();
        }

        private void SetUpButtons()
        {
            backToUserMenu.onClick.AddListener(BackToUserMenu);
        }

        private void BackToUserMenu()
        {
            ScenesService.LoadScene(Scenes.Scene_2_UserMenu);
        }

        public void SetUpActivitySlots(int activitiesNumber)
        {
            SetActivitySlots(activitiesNumber);
        }

        private void SetActivitySlots(int activitiesNumber)
        {
            for (int i = 0; i < activitiesNumber && i < activitySlots.Length; i++)
                activitySlots[i].SetUp();
        }

        private void OnAnimationStart()
        {
            StartAnimationForActivitySlots();
            animationMode.SetUp(GetAnimationTime());
        }

        private long GetAnimationTime()
        {
            long time = 0;

            for (int i = 0; i < activitySlots.Length; i++)
                if(activitySlots[i].isActiveAndEnabled)
                    time += activitySlots[i].GetActivityTime();

            return time;
        }

        private void StartAnimationForActivitySlots()
        {
            for (int i = 0; i < activitySlots.Length; i++)
                if (activitySlots[i].isActiveAndEnabled)
                    activitySlots[i].StartAnimation();
        }
    }
}
