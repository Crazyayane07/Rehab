using Rehab.Model.Content;
using TMPro;
using UnityEngine.UI;

namespace Rehab.Popups.GameManagment
{
    public class GameToggle : MonoBehaviour2
    {
        public Toggle toggle;
        public TextMeshProUGUI gameName;

        private MiniGameContent content;

        public void SetUp(MiniGameContent content)
        {
            this.content = content;

            SetUpText();
        }

        private void SetUpText()
        {
            gameName.text = content.gameName;
        }
    }
}
