using Rehab.Model.Content;
using TMPro;
using UnityEngine.UI;

namespace Rehab.Popups.GameManagment
{
    public class InformationPanel : MonoBehaviour2
    {
        public TextMeshProUGUI gameTitle;
        public TextMeshProUGUI gameDescription;
        public Image gameImage;
        public Button startGame;

        private MiniGameContent content;

        public void SetUp(MiniGameContent content)
        {
            this.content = content;

            SetUpTexts();
            SetUpImage();
            SetUpButton();

            SetActive(true);
        }

        private void SetUpButton()
        {
            startGame.onClick.AddListener(StartGameScene);
        }

        private void StartGameScene()
        {
            Selected.TEST = new Model.Test() { miniGames = new MiniGameContent[1] { content } };
            ScenesService.LoadScene(Scenes.Scene_5_Test);
        }

        private void SetUpImage()
        {
            gameImage.sprite = content.gameImage;
        }

        private void SetUpTexts()
        {
            gameTitle.text = content.gameName;
            gameDescription.text = content.gameDescription;
        }
    }
}
