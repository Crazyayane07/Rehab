using Rehab.Popups.Archieve;
using UnityEngine.UI;

namespace Rehab.Manager
{
    public class ArchieveManager : MonoBehaviour2
    {
        public Button backButton;
        public ResultPanel[] resultPanels;

        private void Start()
        {
            SetUpButton();
            SetUpPanels();
        }

        private void SetUpButton()
        {
            backButton.onClick.AddListener(GoBackToMenu);
        }

        private void GoBackToMenu()
        {
            ScenesService.LoadScene(Scenes.Scene_2_UserMenu);
        }

        private void SetUpPanels()
        {
            var results = DatabaseService.GetUserResult(Selected.USER.Email);

            for (int i = 0; i < results.Count && i < resultPanels.Length; i++)
            {
                resultPanels[i].SetUp(results[i]);
            }
            for (int j = results.Count; j < resultPanels.Length; j++)
            {
                resultPanels[j].gameObject.SetActive(false);
            }
        }
    }
}
