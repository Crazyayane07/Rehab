﻿using Rehab.Popups;
using Rehab.Popups.Panel;
using UnityEngine.UI;

namespace Rehab.SceneController
{
    public class MainMenu : MonoBehaviour2
    {
        public AuthorizationPanel authorizationPanel;
        public UsersListPanel usersList;
        //public AddUserPopup addUserPopup;
        //public SubUserPopup subUserPopup;

        public Button backButton;
        public Button loginButton;

      //  public Button addUser;
      //  public Button subUser;

        private void Start()
        {
            SetUpAuthorizationPanel();
            SetUpUserList();
            SetUpButtons();
        }

        private void SetUpButtons()
        {
            backButton.onClick.AddListener(SetUpAuthorizationPanel);

           // addUser.onClick.AddListener(ShowAddUserPopup);
          //  subUser.onClick.AddListener(ShowSubUserPopup);
        }

        private void ShowSubUserPopup()
        {
           // subUserPopup.SetUp(SetUpUserList);
        }

        private void ShowAddUserPopup()
        {
           // addUserPopup.SetUp(SetUpUserList);
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