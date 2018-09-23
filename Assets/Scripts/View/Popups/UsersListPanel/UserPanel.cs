using Rehab.Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Rehab.Popups.UsersList
{
    public class UserPanel : MonoBehaviour2
    {
        public TextMeshProUGUI emailText;
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI surnameText;
        public Button button;
        public GameObject shadow;

        private User user;

        public void SetUp(User user)
        {
            this.user = user;

            SetUpTexts();

            SetActive(true);
        }

        private void SetUpTexts()
        {
            emailText.text = user.Email;
            nameText.text = user.Name;
            surnameText.text = user.Surname;
        }

        private void SetShadow()
        {
            shadow.SetActive(user.Email == Selected.USER);
        }

    }
}
