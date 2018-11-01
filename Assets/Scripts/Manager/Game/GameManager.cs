using System;
using Rehab.Popups.GameManagment;
using UnityEngine.UI;

namespace Rehab.Manager
{
    public class GameManager : MonoBehaviour2
    {
        public Button backToMainMenu;
        public Button makeTestButton;
        public MakeTestPopup popup;

        public GameButton[] gameButtons;

        private void Start()
        {
            SetUpButtons();
            SetUpGameButtons();
        }

        private void SetUpGameButtons()
        {
            var miniGames = ContentService.GetMiniGames();

            for (int i = 0; i < miniGames.Count && i < gameButtons.Length; i++)
                gameButtons[i].SetUp(miniGames[i]);
        }

        private void BackToMainMenu()
        {
            ScenesService.LoadScene(Scenes.Scene_2_UserMenu);
        }

        private void SetUpButtons()
        {
            backToMainMenu.onClick.AddListener(BackToMainMenu);
            makeTestButton.onClick.AddListener(ShowMakeTestPopup);
        }

        private void ShowMakeTestPopup()
        {
            popup.SetUp();
        }
    }
}
