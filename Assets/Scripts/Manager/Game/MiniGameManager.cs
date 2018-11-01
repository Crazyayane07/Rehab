using Rehab.Model.Content;
using Rehab.Popups.Test;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using Rehab.Model;
using System;

namespace Rehab.Manager
{
    public class MiniGameManager : MonoBehaviour2
    {
        public Image[] helpers;
        public DragAnswer[] answers;
        public DragSolution[] solutions;

        public TextMeshProUGUI gameName;
        public Button quitGame;

        public ResultPopup resultPopup;

        private MiniGameContent content;
        private float gameTime;
        private Action onFinishGame;

        public void SetUp(MiniGameContent content, Action onFinishGame)
        {
            this.content = content;
            this.onFinishGame = onFinishGame;

            SetText();
            SetButton();
            SetSolutions();
            SetHelpers();
            SetAnswers();

            SetActive(false);
        }

        public void StartGame()
        {
            SetActive(true);
        }

        private void Update()
        {
            gameTime += Time.deltaTime;
        }

        private void CheckIfGameOver()
        {
            if (IsGameOver())
            {
                ShowSaveResultPopup();
                SetActive(false);
            }                
        }

        private void ShowSaveResultPopup()
        {
            resultPopup.SetUp(TimeService.TranslateTime(gameTime), content.gameName, onFinishGame);
        }

        private bool IsGameOver()
        {
            for (int i = 0; i < answers.Length; i++)
                if (!answers[i].IsSolved())
                    return false;
            return true;
        }

        private void SetAnswers()
        {
            for (int i = 0; i < content.answers.Length && i < answers.Length; i++)
                answers[i].SetUp(i, CheckIfGameOver);
        }

        private void SetSolutions()
        {
            Solution[] solutionModels = new Solution[solutions.Length];

            for (int i = 0; i < content.answers.Length && i < solutionModels.Length; i++)
                solutionModels[i] = new Solution(content.answers[i], i);
            for (int j = 0, i = content.answers.Length; j < content.fakers.Length && i < solutionModels.Length; i++, j++)
                solutionModels[i] = new Solution(content.fakers[j], i);

            Solution[] swapedArray = RandomSwapElements(solutionModels);
            for (int i = 0; i < swapedArray.Length && i < solutions.Length; i++)
                solutions[i].SetUp(swapedArray[i]);
        }

        private Solution[] RandomSwapElements(Solution[] array)
        {
            int counter = UnityEngine.Random.Range(1,10);
            int a, b;
            Solution temp;

            for(int i = 0; i < counter; i++)
            {
                a = UnityEngine.Random.Range(0, array.Length - 1);
                b = UnityEngine.Random.Range(0, array.Length - 1);

                temp = array[a];
                array[a] = array[b];
                array[b] = temp;
            }

            return array;
        }

        private void SetHelpers()
        {
            for (int i = 0; i < content.helpers.Length && i < helpers.Length; i++)
                helpers[i].sprite = content.helpers[i];
        }

        private void SetButton()
        {
            quitGame.onClick.AddListener(ReturnGamesMenu);
        }

        private void ReturnGamesMenu()
        {
            ScenesService.LoadScene(Scenes.Scene_4_MiniGames);
        }

        private void SetText()
        {
            gameName.text = content.gameName;
        }
    }
}
