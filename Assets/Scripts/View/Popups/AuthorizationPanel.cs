using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Rehab.Popups
{
    public class AuthorizationPanel : MonoBehaviour2
    {
        public TMP_InputField password;
        public Button authorization;
        public Button closeGame;
        public TextMeshProUGUI error;

       /* private void Start()
        {
            PlayerPrefs.SetString(Constans.AdminPassword, Constans.AdminPassword);
        }*/

        public void SetUp()
        {
            SetUpButtons();

            SetActive(true);
        }

        private void SetUpButtons()
        {
            closeGame.onClick.AddListener(CloseGame);
            authorization.onClick.AddListener(Authorize);
        }

        private void Authorize()
        {
            UnityEngine.Debug.Log("authorize");
            AuthorizationService.Authorize(
                     password.text,
                     Hide,
                     SetError
                     );
        }

        private void SetError(string message)
        {
            error.text = message;
            error.gameObject.SetActive(true);
        }

        private void CloseGame()
        {
            Application.Quit();
        }

        private void Hide()
        {
            UnityEngine.Debug.Log("hide");
            SetActive(false);
        }
    }
}
