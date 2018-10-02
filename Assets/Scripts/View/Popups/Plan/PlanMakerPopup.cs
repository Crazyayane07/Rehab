using System;
using TMPro;
using UnityEngine.UI;

namespace Rehab.Popups.Plan
{
    public class PlanMakerPopup : MonoBehaviour2
    {
        public Button backButton;
        public Button confirmButton;
        public TMP_Dropdown dropdown;

        private Action<int> onConfirm;

        public void SetUp(Action<int> onConfirm)
        {
            this.onConfirm = onConfirm;

            SetUpButtons();

            SetActive(true);
        }

        private void SetUpButtons()
        {
            backButton.onClick.AddListener(BackToUserMenu);
            confirmButton.onClick.AddListener(StartPlanMaking);
        }

        private void StartPlanMaking()
        {
            onConfirm(dropdown.value+1);
            SetActive(false);
        }

        private void BackToUserMenu()
        {
            ScenesService.LoadScene(Scenes.Scene_1_MainMenu);
        }
    }
}
