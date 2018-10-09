using System;
using TMPro;
using UnityEngine.UI;

namespace Rehab.Manager
{
    public class UserMenu : MonoBehaviour2
    {
        public Button gamesButton;
        public Button planButton;
        public Button backButton;
        public Button scoresButton;

        public TextMeshProUGUI welcomeText;

        private void Start()
        {
            SetUpText();
            SetUpButtons();
        }

        private void SetUpButtons()
        {
            backButton.onClick.AddListener(GoBackToMainMenu);
            gamesButton.onClick.AddListener(GotToMiniGames);
            planButton.onClick.AddListener(GoToPlanMaker);
        }

        private void GotToMiniGames()
        {
            ScenesService.LoadScene(Scenes.Scene_4_MiniGames);
        }

        private void GoToPlanMaker()
        {
            ScenesService.LoadScene(Scenes.Scene_3_Plan);
        }

        private void GoBackToMainMenu()
        {
            ScenesService.LoadScene(Scenes.Scene_1_MainMenu);
        }

        private void SetUpText()
        {
            welcomeText.text = "Witaj " + Selected.USER.Name + "!";
        }
    }
}
