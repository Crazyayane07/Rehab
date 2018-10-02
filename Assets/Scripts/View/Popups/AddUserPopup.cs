using Rehab.Model;
using System;
using TMPro;
using UnityEngine.UI;

namespace Rehab.Popups
{
    public class AddUserPopup : MonoBehaviour2
    {
        public Button close;
        public Button add;

        public TMP_InputField emailInput;
        public TMP_InputField nameInput;
        public TMP_InputField surnameInput;

        private Action refreshUsers;

        public void SetUp(Action refreshUsers)
        {
            this.refreshUsers = refreshUsers;

            SetUpButtons();

            SetActive(true);
        }

        private void SetUpButtons()
        {
            close.onClick.AddListener(Hide);
            add.onClick.AddListener(AddUser);
        }

        private void Hide()
        {
            SetActive(false);
        }

        private void AddUser()
        {
            User user = new User(emailInput.text, nameInput.text, surnameInput.text);

            DatabaseService.AddUser(user, OnSuccessAdd);
        }

        private void OnSuccessAdd()
        {
            refreshUsers();
            Hide();
        }
    }
}