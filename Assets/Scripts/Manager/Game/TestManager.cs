using Rehab.Popups.Test;

namespace Rehab.Manager
{
    public class TestManager : MonoBehaviour2
    {
        public MiniGameManager[] boards;
        public EndTestPopup endTestPopup;

        private int games;
        private int actualGame;

        private void Start()
        {
            actualGame = 0;
            games = Selected.TEST.miniGames.Length;

            SetUpGames();
            StartGame(actualGame);
        }

        private void SetUpGames()
        {
            for (int i = 0; i < boards.Length && i < games; i++)
                boards[i].SetUp(Selected.TEST.miniGames[i], RefreshTest);
        }

        private void RefreshTest()
        {
            actualGame++;

            if (actualGame >= games)
                CloseTest();
            else
                StartGame(actualGame);
        }

        private void CloseTest()
        {
            endTestPopup.SetUp();
        }

        private void StartGame(int id)
        {
            boards[id].StartGame();
        }

    }
}
