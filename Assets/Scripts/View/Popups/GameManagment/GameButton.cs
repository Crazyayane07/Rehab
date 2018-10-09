using Rehab.Model.Content;
using TMPro;
using UnityEngine.UI;

namespace Rehab.Popups.GameManagment
{
    public class GameButton : MonoBehaviour2
    {
        public Button infoButton;
        public TextMeshProUGUI buttonText;
        public InformationPanel informationPanel;

        private MiniGameContent content;

        public void SetUp(MiniGameContent content)
        {
            this.content = content;

            SetUpText();
            SetUpButton();
        }

        private void SetUpButton()
        {
            infoButton.onClick.AddListener(ShowInfoPanel);
        }

        private void ShowInfoPanel()
        {
            informationPanel.SetUp(content);
        }

        private void SetUpText()
        {
            buttonText.text = content.gameName;
        }
    }
}
