using Rehab.Manager;
using Rehab.Services.Authorization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Rehab.Popups { 

    public class AuthorizationStartPanel : MonoBehaviour
    {
        public TMP_InputField passwordField;
        public Button authorizationButton;
        public Button closeGameButton;
        public TextMeshProUGUI errorText;

        private void Start()
        {
            SetUp();
        }

        public void SetUp()
        {
            SetUpButtons();
        }

        private void SetUpButtons()
        {
            closeGameButton.onClick.AddListener(CloseGame);
            authorizationButton.onClick.AddListener(Authorize);
        }

        private void Authorize()
        {
            GameManager.DatabaseService.GetUsers();

            GameManager.AuthorizationService.Authorize(
                new AuthorizationCommands(
                    passwordField.text,
                    Hide,
                    SetError
                    ));
        }

        private void SetError(string message)
        {
            errorText.text = message;
            errorText.gameObject.SetActive(true);
        }

        private void CloseGame()
        {
            Application.Quit();
        }

        private void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
