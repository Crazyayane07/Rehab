using Rehab.Manager;
using System;
using TMPro;
using UnityEngine.UI;

namespace Rehab.Popups
{
    public class SubUserPopup : MonoBehaviour2
    {
        public Button close;
        public Button confirm;
        public TextMeshProUGUI userToDelete;

        private Action refreshUsers;

        public void SetUp(Action refreshUsers)
        {
            this.refreshUsers = refreshUsers;

            SetUpButtons();
            SetUpText();

            SetActive(true);
        }

        private void SetUpText()
        {
            userToDelete.text = Selected.USER.Email;
        }

        private void SetUpButtons()
        {
            close.onClick.AddListener(Hide);
            confirm.onClick.AddListener(SubUser);
        }

        private void SubUser()
        {
            DatabaseService.SubUser(Selected.USER.Email, OnSuccessSubstract);
        }

        private void OnSuccessSubstract()
        {
            refreshUsers();
            Selected.USER = null;
            Hide();
        }

        private void Hide()
        {
            SetActive(false);
        }
    }
}