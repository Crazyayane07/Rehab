using System;
using TMPro;
using UnityEngine.UI;

namespace Rehab.Popups.Test
{
    public class ResultPopup : MonoBehaviour2
    {
        public TextMeshProUGUI resultText;
        public Button acceptButton;
        public Button closeButton;

        private string result;
        private string gameName;
        private DateTime finishedTime;
        private Action testRefresh;

        public void SetUp(string result, string gameName, Action testRefresh)
        {
            this.result = result;
            this.gameName = gameName;
            finishedTime = DateTime.Now;
            this.testRefresh = testRefresh;

            SetUpText();
            SetUpButtons();

            SetActive(true);
        }

        private void SetUpButtons()
        {
            acceptButton.onClick.RemoveAllListeners();
            closeButton.onClick.RemoveAllListeners();

            acceptButton.onClick.AddListener(SaveResult);
            closeButton.onClick.AddListener(DontSaveResult);
        }

        private void Hide()
        {
            SetActive(false);
        }

        private void DontSaveResult()
        {
            Hide();
            testRefresh();
        }

        private void SaveResult()
        {
            Hide();
            testRefresh();

            DatabaseService.AddResult(Selected.USER.Email, finishedTime.ToLongDateString(), gameName, result);
        }

        private void SetUpText()
        {
            resultText.text = result;
        }
    }
}
