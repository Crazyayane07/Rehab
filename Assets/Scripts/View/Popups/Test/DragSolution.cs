using UnityEngine.UI;
using UnityEngine;
using System;
using Rehab.Model;

namespace Rehab.Popups.Test
{
    public class DragSolution : MonoBehaviour2
    {
        public Image solutionImage;
        private Solution solution;

        public void SetUp(Solution solution)
        {
            this.solution = solution;

            SetUpImage();
        }

        public int GetSolutionId()
        {
            return solution.SolutionId;
        }

        public Sprite GetSprite()
        {
            return solution.SolutionSprite;
        }

        private void SetUpImage()
        {
            solutionImage.sprite = solution.SolutionSprite;
        }
    }
}
