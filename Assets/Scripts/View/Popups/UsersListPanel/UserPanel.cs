using System;
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
            SetUpButton();
            Subscribe();

            SetActive(true);
        }

        private void Subscribe()
        {
            UserService.OnSelect += SetShadow;
        }

        private void OnDisable()
        {
            UserService.OnSelect -= SetShadow;
        }

        private void OnDestroy()
        {
            UserService.OnSelect -= SetShadow;
        }

        private void SetUpButton()
        {
            button.onClick.AddListener(SelectUser);
        }

        private void SelectUser()
        {
            UserService.Select(user.Email);
        }

        private void SetUpTexts()
        {
            emailText.text = user.Email;
            nameText.text = user.Name;
            surnameText.text = user.Surname;
        }

        private void SetShadow()
        {
            if(this)
                shadow.SetActive(user.Email == Selected.USER);
        }

    }
}
