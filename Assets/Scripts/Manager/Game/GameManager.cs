using Rehab.Popups.GameManagment;
using UnityEngine.UI;

namespace Rehab.Manager
{
    public class GameManager : MonoBehaviour2
    {
        public Button backToMainMenu;
        public GameButton[] gameButtons;

        private void Start()
        {
            SetUpButtons();
            SetUpGameButtons();
        }

        private void SetUpGameButtons()
        {
            backToMainMenu.onClick.AddListener(BackToMainMenu);
        }

        private void BackToMainMenu()
        {
            ScenesService.LoadScene(Scenes.Scene_2_UserMenu);
        }

        private void SetUpButtons()
        {
            var miniGames = ContentService.GetMiniGames();

            for (int i = 0; i < miniGames.Count && i < gameButtons.Length; i++)
                gameButtons[i].SetUp(miniGames[i]);
        }
    }
}
