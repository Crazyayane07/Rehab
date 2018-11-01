using UnityEngine.UI;
using UnityEngine;
using System;

namespace Rehab.Popups.Test
{
    public class DragAnswer : MonoBehaviour2
    {
        public Image answerImage;

        private int answerId;
        private bool solved;
        private Action onSolved;

        public void SetUp(int answerId, Action onSolved)
        {
            this.answerId = answerId;
            this.onSolved = onSolved;

            solved = false;
        }

        public void TryMatch(DragSolution dragSolution)
        {
            if(answerId == dragSolution.GetSolutionId() && !solved)
            {
                solved = true;
                SetImage(dragSolution.GetSprite());
                dragSolution.gameObject.SetActive(false);
                onSolved();
            }
        }

        private void SetImage(Sprite sprite)
        {
            answerImage.sprite = sprite;
        }

        public bool IsSolved()
        {
            return solved;
        }
    }
}
