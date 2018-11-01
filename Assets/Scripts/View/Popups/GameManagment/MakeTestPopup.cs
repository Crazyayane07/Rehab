using Rehab.Model.Content;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Rehab.Popups.GameManagment
{
    public class MakeTestPopup : MonoBehaviour2
    {
        public Button closeButton;
        public Button confirmButton;
        public GameToggle[] toggles;

        private List<MiniGameContent> miniGames;

        public void SetUp()
        {
            miniGames = ContentService.GetMiniGames();

            SetUpButtons();
            SetUpToggles();

            SetActive(true);
        }

        private void SetUpToggles()
        {
            for (int i = 0; i < miniGames.Count && i < toggles.Length; i++)
                toggles[i].SetUp(miniGames[i]);
        }

        private void SetUpButtons()
        {
            closeButton.onClick.AddListener(ClosePopup);
            confirmButton.onClick.AddListener(StartTest);
        }

        private void StartTest()
        {
            SetUpTest();
            ScenesService.LoadScene(Scenes.Scene_5_Test);
        }

        private void SetUpTest()
        {
            List<MiniGameContent> contents = new List<MiniGameContent>();

            for (int i = 0; i < miniGames.Count && i < toggles.Length; i++)
                if (toggles[i].toggle.isOn)
                    contents.Add(miniGames[i]);

            Selected.TEST = new Model.Test() { miniGames = contents.ToArray() };
        }

        private void ClosePopup()
        {
            SetActive(false);
        }
    }
}
