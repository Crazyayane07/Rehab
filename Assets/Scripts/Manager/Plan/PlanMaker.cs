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

        public PlanHolder holder;

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
            holder.ActivateSlots(activitiesNumber, IsReadyForAnimation, animationMode.ChangeActiveActivity);
        }

        private void IsReadyForAnimation()
        {
            editonMode.ActivateButton();
        }

        private void SetStartAnimationButton()
        {
            editonMode.startAnimation.interactable = false;
        }

        private void OnAnimationStart()
        {
            StartAnimationForActivitySlots();
            animationMode.SetUp(GetAnimationTime());
        }

        private long GetAnimationTime()
        {
            return holder.GetAnimationTime();
        }

        private void StartAnimationForActivitySlots()
        {
            holder.StartAnimationForActivitySlots();
        }
    }
}
