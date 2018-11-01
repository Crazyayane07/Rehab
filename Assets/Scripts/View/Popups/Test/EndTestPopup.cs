using UnityEngine.UI;

namespace Rehab.Popups.Test
{
    public class EndTestPopup : MonoBehaviour2
    {
        public Button closeButton;

        public void SetUp()
        {
            SetUpButton();

            SetActive(true);
        }
        
        private void SetUpButton()
        {
            closeButton.onClick.AddListener(MoveToGameMenu);
        }

        private void MoveToGameMenu()
        {
            ScenesService.LoadScene(Scenes.Scene_4_MiniGames);
        }
    }
}
