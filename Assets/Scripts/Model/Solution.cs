using UnityEngine;

namespace Rehab.Model
{
    public class Solution
    {
        private Sprite solutionSprite;
        private int solutionId;

        public Sprite SolutionSprite { get { return solutionSprite; } }
        public int SolutionId { get { return solutionId; } }

        public Solution(Sprite solutionSprite, int solutionId)
        {
            this.solutionSprite = solutionSprite;
            this.solutionId = solutionId;
        }
    }
}
