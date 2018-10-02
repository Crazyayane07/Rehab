

namespace Rehab.Manager.Plan
{
    public class AnimationMode : MonoBehaviour2
    {
        private long time;

        public void SetUp(long time)
        {
            this.time = time;

            SetActive(true);
        }
    }
}
