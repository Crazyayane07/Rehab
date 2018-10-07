using System;
using Rehab.Popups;
using UnityEngine;
using UnityEngine.UI;

namespace Rehab.Manager
{
    public class MainMenu : MonoBehaviour2
    {
        public AuthorizationPanel authorizationPanel;
        public UsersListPanel usersList;
        public AddUserPopup addUserPopup;
        public SubUserPopup subUserPopup;

        public Button closeGame;
        public Button loginButton;

        public Button addUser;
        public Button subUser;

        private void Start()
        {
            SetUpAuthorizationPanel();
            SetUpUserList();
            SetUpButtons();
        }

        private void CloseGame()
        {
            Application.Quit();
        }

        private void SetUpButtons()
        {
            addUser.onClick.AddListener(ShowAddUserPopup);
            subUser.onClick.AddListener(ShowSubUserPopup);
            closeGame.onClick.AddListener(CloseGame);
            loginButton.onClick.AddListener(TryLogin);
        }

        private void TryLogin()
        {
            if (Selected.USER != null)
                Login();
        }

        private void Login()
        {
            ScenesService.LoadScene(Scenes.Scene_2_UserMenu);
        }

        private void ShowSubUserPopup()
        {
            subUserPopup.SetUp(SetUpUserList);
        }

        private void ShowAddUserPopup()
        {
            addUserPopup.SetUp(SetUpUserList);
        }

        private void SetUpUserList()
        {
            usersList.SetUp();
        }

        private void SetUpAuthorizationPanel()
        {
            authorizationPanel.SetUp();
        }
    }
}
